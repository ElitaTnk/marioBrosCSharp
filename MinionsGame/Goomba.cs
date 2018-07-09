using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPixel
{
    public class Goomba : MultiImageSprite
    {

        public Goomba(Point location)
        {
            Location = location;
            images.Add(0, Game1.Instance.Content.Load<Texture2D>("goomba"));
            selectedImage = 0;
            Size = new Point(50, 50);
        }


        public override void Update(GameTime gameTime)
        {

            int x = Location.X;
            int y = Location.Y;

            x--;
            //destruyo el que se sale de pantalla
            if (y > 2 * Game1.Instance.graphics.GraphicsDevice.Viewport.Height ||
                x > 2 * Game1.Instance.graphics.GraphicsDevice.Viewport.Width)
            {
                Game1.Instance.newSprites.Add(this);
                return;
            }

            Location = new Point(x, y);    //actualizo su posicion

            foreach (var item in Game1.Instance.Sprites)
            {
                if (item is Mario)
                {
                    Mario mario = item as Mario;
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
