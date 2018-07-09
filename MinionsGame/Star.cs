using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MarioPixel
{
    public class Star : MultiImageSprite
    {


        public Star(Point location)
        {
            Location = location;
            images.Add(0, Game1.Instance.Content.Load<Texture2D>("star"));
            selectedImage = 0;
            Size = new Point(50, 50);

        }


        public override void Update(GameTime gameTime)
        {

            //caida
            int X = Location.X;
            int Y = Location.Y;
            Y++;


            //destruyo el que se sale de pantalla
            if (Y > 2 * Game1.Instance.graphics.GraphicsDevice.Viewport.Height)
            {
                Game1.Instance.newSprites.Add(this);
                return;
            }

            Location = new Point(X, Y);    //actualizo su posicion

            foreach (var item in Game1.Instance.Sprites)
            {
                if (item is Mario)
                {
                    Mario mario = item as Mario;
                    if (Rectangle.Intersects(mario.Rectangle))
                    {
                       
                        Game1.Score = Game1.Score + 50;
                        Game1.Instance.newSprites.Add(this);
                        return;
                    }
                }
            }
        }
        
    }
}
