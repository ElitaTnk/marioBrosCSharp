using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPixel
{
    public abstract class HealtySprite: MultiImageSprite
    {

        /// <summary>
        /// La cantidad de vida que tiene un Sprite
        /// </summary>
        public virtual int Health { get; set; }


    }
}
