using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Emit;
using System;
using System.Collections.Generic;

namespace Monogame_1___Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D backgroundTexture, beachBallTexture, umbrellaTexture, castleTexture, seagullTexture, chairTexture;
        Rectangle window, seagullRect, beachBallRect, umbrellaRect, castleRect, chairRect;
        SpriteFont titleFont;

        Random generator;
        List<Texture2D> seagullTextures;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            this.Window.Title = "Beach Day!";
            generator = new Random();

            seagullRect = new Rectangle(generator.Next(100, 681), generator.Next(10, 100), 120, 95);
            umbrellaRect = new Rectangle(-80, 150, 400, 400);
            beachBallRect = new Rectangle(300, 250, 80, 70);
            chairRect = new Rectangle(60, 325, 200, 200);

            
            seagullTextures = new List<Texture2D>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("Images/beachBackground");

            for (int i = 1; i <= 7; i++)
            {
                seagullTextures.Add(Content.Load<Texture2D>("Images/seagull_" + i));
            }
            umbrellaTexture = Content.Load<Texture2D>("Images/umbrella");
            seagullTexture = seagullTextures[generator.Next(seagullTextures.Count)];
            beachBallTexture = Content.Load<Texture2D>("Images/beachBall");
            chairTexture = Content.Load<Texture2D>("Images/chair");

            titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, window, Color.White);

            _spriteBatch.DrawString(titleFont, "Beach", new Vector2(110, 10), Color.Black);

            _spriteBatch.Draw(seagullTexture, seagullRect, Color.White);
            _spriteBatch.Draw(beachBallTexture, beachBallRect, Color.White);

            _spriteBatch.Draw(umbrellaTexture, umbrellaRect, null, Color.White, 0.05f,new Vector2(0,0), SpriteEffects.None, 0f); //need to fix rotation and vector...
            _spriteBatch.Draw(chairTexture, chairRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
