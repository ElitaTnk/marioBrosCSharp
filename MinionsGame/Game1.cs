using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace MarioPixel
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics { get; private set; }

        public SpriteBatch spriteBatch { get; private set; }

        public static Game1 Instance { get; private set; }
        public SpriteFont MainFont;

        internal List<Updatable> Sprites { get; private set; }
        internal List<Updatable> newSprites { get; private set; }

        private Song cancion;

        bool pausa;
        TimeSpan t_anterior;

        private Texture2D background;
        
        static int score = 0;

        public static int Score
        {
            get { return score; }
            set { score = value; }
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Instance = this;
            Sprites = new List<Updatable>();
            newSprites = new List<Updatable>();
        }

        
        protected override void Initialize()
        {
            cancion = Content.Load<Song>("super-mario-bros");
            MediaPlayer.Play(cancion);

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MainFont = this.Content.Load<SpriteFont>("Fonts/Stats");


            Sprites.Add(new Mario(new Point(0,310), new Point(12,20)));
            Sprites.Add(new EnemyFabric());
            Sprites.Add(new StarFabric());

            background = Content.Load<Texture2D>("fondo"); 
            

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        

          protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var item in Sprites)
            {
                item.Update(gameTime);
            }

            //agrego los nuevos sprites
            foreach (var item in newSprites)
            {
                if (Sprites.Contains(item))
                    Sprites.Remove(item);
                else
                    Sprites.Add(item);
            }
            newSprites.Clear();     //borro los nuevos sprites

            //pausa
            if (gameTime.TotalGameTime.Subtract(t_anterior) >
                new TimeSpan(0, 0, 0, 0, 100))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    pausa = !pausa;
                    t_anterior = gameTime.TotalGameTime;
                }
            }



            if (pausa)
                return;


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

           
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            foreach (var item in Sprites)
            {
                Sprite aux = item as Sprite;
                if (aux != null)
                    aux.Draw(gameTime);
            }
            


            spriteBatch.DrawString(MainFont, score.ToString(),
                new Vector2(10, 40), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
