using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MinionsGame
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
            int x = Location.X;
            int y = Location.Y;

            x--;
            //destruyo el que se sale de pantalla
            if (y > 2 * Game1.Instance.graphics.GraphicsDevice.Viewport.Height || x > 2 * Game1.Instance.graphics.GraphicsDevice.Viewport.Width)
            {
                Game1.Instance.newSprites.Add(this);
                return;
            }

            

            Location = new Point(x,y);    //actualizo su posicion

            foreach (var item in Game1.Instance.Sprites)
            {
                if (item is Minion)
                {
                    Minion mario = item as Minion;
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
