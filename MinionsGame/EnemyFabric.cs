using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioPixel
{
    public class EnemyFabric : FabricBase
    {

        TimeSpan tiempoanterior;
        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tiempoanterior).Seconds > 2)
            {
                Goomba goomba = new Goomba(new Point(Game1.Instance.graphics.GraphicsDevice.Viewport.Width,
                    Game1.Instance.graphics.GraphicsDevice.Viewport.Height - Game1.Instance.graphics.GraphicsDevice.Viewport.Height/4)); 
                Game1.Instance.newSprites.Add(goomba);
                tiempoanterior = gameTime.TotalGameTime;
            }


        }
    }
}
