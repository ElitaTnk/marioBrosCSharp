using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MarioPixel
{
    public class Mario:HealtySprite
    {
        public enum states{ normal, saltando, camina }

        public states State { get; set; }

        public Texture2D VidaObj;

        
        public Mario(Point? location = null, Point? speed = null)
        {
            if (location != null)
                Location = location.Value;
            if (speed != null)
                Speed = speed.Value;

            images.Add(states.normal, Game1.Instance.Content.Load<Texture2D>("mario-quieto"));
            images.Add(states.saltando, Game1.Instance.Content.Load<Texture2D>("mario"));
            images.Add(states.camina, Game1.Instance.Content.Load<Texture2D>("mario-caminando"));

            selectedImage = State;
            Health = 100;
        

    }


        bool saltando;
        bool caminando;
        int posYAnterior;
        int posXAnterior;


        public override void Update(GameTime gameTime)
        {
            float dT = (float)gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            int x = Location.X;
            int y = Location.Y;


            if (x > Game1.Instance.graphics.GraphicsDevice.Viewport.Width + Size.X)
                x = -Size.X;

            //saltar
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && saltando == false)
            {
                posYAnterior = y;
                saltando = true;
                State = states.saltando;
                selectedImage = states.saltando;
                y -= 100;
            }

            if (saltando)
            {
                y++;
                if (y == posYAnterior)
                {

                    y += Speed.Y * (int)dT;
                    saltando = false;
                    State = states.normal;
                    selectedImage = states.normal;
                }
            }

            //adelante
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                posXAnterior = x + 12;
                caminando = true;
                State = states.camina;
                selectedImage = states.camina;
                x += Speed.X;
            }

            if (caminando)
            {
                x++;
                if (x > posXAnterior + Speed.X )
                {
                    if (!saltando)
                    {
                        caminando = false;
                        State = states.normal;
                        selectedImage = states.normal;
                    }
                    else {
                        caminando = false;
                        State = states.saltando;
                        selectedImage = states.saltando;
                    }
                    
                }
            }

            //atras
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                posXAnterior = x - 12;
                caminando = true;
                State = states.camina;
                selectedImage = states.camina;
                x -= Speed.X ;
            }

            if (caminando)
            {
                x++;
                if (x < posXAnterior - Speed.X)
                {
                    if (!saltando)
                    {
                        caminando = false;
                        State = states.normal;
                        selectedImage = states.normal;
                    }
                    else
                    {
                        caminando = false;
                        State = states.saltando;
                        selectedImage = states.saltando;
                    }
                }
            }

            ValidateLocation(ref x, ref y);
            Location = new Point(x, y);


            //vida
            
            if (Health <= 0)
            {
                //pierde
                Game1.Instance.newSprites.Add(this);
                Game1.Instance.Exit(); 
                return;
            }

            if (Health > 0)
                VidaObj = new Texture2D(Game1.Instance.graphics.GraphicsDevice, Health, 10);
            else
                VidaObj = new Texture2D(Game1.Instance.graphics.GraphicsDevice, 1, 10);

            Color[] data = new Color[Health * 10];
            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.Green;
            VidaObj.SetData(data);
        }

        protected  void ValidateLocation(ref int x, ref int y)
        {

            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            if (x > Game1.Instance.GraphicsDevice.Viewport
                .Width - 100)
                x = Game1.Instance.GraphicsDevice.Viewport
                    .Width - 100;
            if (y > Game1.Instance.GraphicsDevice.Viewport
                .Height - 100)
                y = Game1.Instance.GraphicsDevice.Viewport
                    .Height - 100;
          
        }


        public override void Draw(GameTime gameTime)
        {
          

            Vector2 coor = new Vector2(0,0);
            

            Game1.Instance.spriteBatch.Draw(VidaObj, coor, Color.White);
            base.Draw(gameTime);
        }

    }
}
