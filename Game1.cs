﻿using Microsoft.Xna.Framework;
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

        Texture2D backgroundTexture, beachBallTexture, umbrellaTexture, castleTexture, seagullTexture, chairTexture, boatTexture, crabTexture, beachBoyTexture, beachGirlTexture;
        Rectangle window, seagullRect, beachBallRect, umbrellaRect, castleRect, chairRect, boatRect, crabRect, beachBoyRect, beachGirlRect;
        SpriteFont titleFont;

        Random generator;
        List<Texture2D> seagullTextures;

        float umbrellaRotation, boatOpacity;

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
            umbrellaRect = new Rectangle(50, 150, 176, 200); 
            beachBallRect = new Rectangle(300, 250, 80, 70);
            chairRect = new Rectangle(80, 280, 150, 150);
            castleRect = new Rectangle(550, 200, 150, 150);
            boatRect = new Rectangle(generator.Next(200, 750),125,50,50);
            crabRect = new Rectangle(0,430,110,60);
            beachBoyRect = new Rectangle(); // Need to position
            beachGirlRect = new Rectangle(); // Need to position

            umbrellaRotation = (float)generator.NextDouble(); //Need to change and see about specifying what angle of rotation... Goes a bit too far
            boatOpacity = (float)generator.NextDouble();


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
            castleTexture = Content.Load<Texture2D>("Images/sandcastle");
            boatTexture = Content.Load<Texture2D>("Images/boat");
            crabTexture = Content.Load<Texture2D>("Images/coolCrab");
            beachBoyTexture = Content.Load<Texture2D>("Images/beachBoy");
            beachGirlTexture = Content.Load<Texture2D>("Images/beachGirl");

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
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, window, Color.White);

            _spriteBatch.DrawString(titleFont, "Fun in the sun!", new Vector2(150, 450), Color.Black);

            _spriteBatch.Draw(seagullTexture, seagullRect, null, Color.White, 0f, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0f);
            _spriteBatch.Draw(castleTexture, castleRect, Color.White);
            _spriteBatch.Draw(beachBallTexture, beachBallRect, Color.White);
            _spriteBatch.Draw(boatTexture, boatRect, null, Color.White * boatOpacity, 0f, new Vector2(0,0), SpriteEffects.None, 0f);

            _spriteBatch.Draw(umbrellaTexture, umbrellaRect, null, Color.White, umbrellaRotation,new Vector2(0,0), SpriteEffects.None, 0f); //0.35 works... 
            _spriteBatch.Draw(chairTexture, chairRect, Color.White);
            _spriteBatch.Draw(crabTexture, crabRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
