using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MinionsGame
{
    public class Phantom : MultiImageSprite
    {

        public Phantom(Point location)
        {
            Location = location;
            images.Add(0, Game1.Instance.Content.Load<Texture2D>("goomba"));
            selectedImage = 0;
            Size = new Point(50, 50);
        }


        public override void Update(GameTime gameTime)
        {
           //caida
            int Y = Location.Y;
            Y++;      
            

            //destruyo el que se sale de pantalla
            if (Y > 2 * Game1.Instance.graphics.GraphicsDevice.Viewport.Height)
            {
                Game1.Instance.newSprites.Add(this);
                return;
            }

            Location = new Point(Location.X, Y);    //actualizo su posicion

            foreach (var item in Game1.Instance.Sprites)
            {
                if (item is Minion)
                {
                    Minion mario = item as Minion;
                    if (Rectangle.Intersects(mario.Rectangle))
                    {
                        //hubo colision, descuento vida y 
                        //destruyo el enemigo
                        mario.Health -= 20;
                        Game1.Instance.newSprites.Add(this);
                        return;
                    }
                }
            }
        }
    }
}
