using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionsGame
{
    public abstract class FabricBase: Updatable
    {
        //miembro compartido por todas las Fabric's
        protected static Random rnd;

        public FabricBase()
        {
            if (rnd == null)    //lo instancio solo la primera vez
                rnd = new Random();
        }

        public abstract void Update(GameTime gameTime);


    }
}
