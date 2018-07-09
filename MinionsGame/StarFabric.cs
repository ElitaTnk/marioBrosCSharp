using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioPixel
{
    public class StarFabric : FabricBase
    {

        TimeSpan tiempoanterior;
        TimeSpan tiempoUtil = TimeSpan.FromMilliseconds(2000);

        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tiempoanterior).Seconds > 1.5)
            {
                Star Estrellitas = new Star(new Point(rnd.Next(
                    Game1.Instance.graphics.GraphicsDevice.Viewport.Width
                    ), 0));
                Game1.Instance.newSprites.Add(Estrellitas);
                tiempoanterior = gameTime.TotalGameTime;
    
            }
            
        }
    }
}
