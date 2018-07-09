using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioPixel
{
    public abstract class MultiImageSprite: Sprite
    {

        protected Dictionary<object, Texture2D> images;
        protected object selectedImage;

        public MultiImageSprite()
        {
            images = new Dictionary<object, Texture2D>();

        }

        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(
                                images[selectedImage],
                                Rectangle, 
                                Color.White);
        }


    }
}
