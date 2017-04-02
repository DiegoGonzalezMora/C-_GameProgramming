using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExplodingTeddies;
using System;

namespace Lab11
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int WindowWidth = 800;
        public const int WindowHeight = 600;

        TeddyBear teddy;
        Explosion explosion;

        Random rdn = new Random();

        // click support
        ButtonState previousLeftButtonState = ButtonState.Released;
        ButtonState previousMiddleButtonState = ButtonState.Released;
        ButtonState previousRightButtonState = ButtonState.Released;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            teddy = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear", 
                300, 200, new Vector2((float)rdn.NextDouble() * (float)0.5, (float)rdn.NextDouble() * (float)0.5) );

            explosion = new Explosion(Content, @"graphics/explosion");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            teddy.Update(gameTime);
            explosion.Update(gameTime);
            MouseState mouse = Mouse.GetState();

            int x = mouse.Position.X;
            int y = mouse.Position.Y;

            if (teddy.DrawRectangle.Contains(x, y) && mouse.LeftButton == ButtonState.Released &&
                previousLeftButtonState == ButtonState.Pressed) {
                teddy.Active = false;
                explosion.Play(teddy.DrawRectangle.X, teddy.DrawRectangle.Y);
            }

            if (previousMiddleButtonState == ButtonState.Pressed) {
                teddy = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear",
                    300, 200, new Vector2((float)rdn.NextDouble() * (float)0.5, (float)rdn.NextDouble() * (float)0.5));
            }

            if (previousRightButtonState == ButtonState.Pressed)
            {
                explosion.Play(teddy.DrawRectangle.X, teddy.DrawRectangle.Y);
                teddy = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear",
                    300, 200, new Vector2((float)rdn.NextDouble() * (float)0.5, (float)rdn.NextDouble() * (float)0.5));
            }


            previousLeftButtonState = mouse.LeftButton;
            previousMiddleButtonState = mouse.MiddleButton;
            previousRightButtonState = mouse.RightButton;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            teddy.Draw(spriteBatch);
            explosion.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
