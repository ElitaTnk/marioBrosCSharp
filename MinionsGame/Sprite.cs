using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MinionsGame
{
    public abstract class Sprite:Updatable
    {
        protected static Random rnd;
        protected Texture2D texture2D;
        public static SpriteFont MainFont { get; private set; }
        public Rectangle Frame { get; protected set; }

        #region propiedades

        public Point Location { get; set; }

        public Point Size { get; protected set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Location, Size); }
        }

        public Point Speed { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Sprite()
        {
            if (rnd == null)
                rnd = new Random();

            Size = new Point(100, 100);
            Location = new Point(rnd.Next(500), rnd.Next(500));
            Speed = new Point(rnd.Next(5), 0);
            MainFont = Game1.Instance.Content.Load<SpriteFont>("superfont");

        }

        public abstract void Update(GameTime gameTime);


        public virtual void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(texture2D,
                                Rectangle, Color.White);
        }


    }
}
