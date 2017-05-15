using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab16
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D texture;
        Rectangle drawRectangle;

        const int WindowWidth = 800;
        const int WindowHeight = 600;

        public const int PIXEL_MOVEMENT = 5;

        int count = 0;
        string offScreenCount;
        const string OFF_SCREEN_STRING_PREFIX = "Times the image went off the screen: ";
        bool outside;

        SpriteFont Arial20;
        Vector2 fontPos = new Vector2(20, 20);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set resolution
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
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
            texture = Content.Load<Texture2D>("Elfen Lied");
            Arial20 = Content.Load<SpriteFont>("Arial20");
            drawRectangle = new Rectangle(WindowHeight/2 - texture.Height/2, WindowWidth/2 - texture.Width/2, texture.Width, texture.Height);
            offScreenCount = GetOffScreenCount(count);

            // TODO: use this.Content to load your game content here
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
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Up))
                drawRectangle.Y -= PIXEL_MOVEMENT;

            if (keyboard.IsKeyDown(Keys.Down))
                drawRectangle.Y += PIXEL_MOVEMENT;

            if (keyboard.IsKeyDown(Keys.Left))
                drawRectangle.X -= PIXEL_MOVEMENT;

            if (keyboard.IsKeyDown(Keys.Right))
                drawRectangle.X += PIXEL_MOVEMENT;

            if (drawRectangle.X > WindowWidth || drawRectangle.X + drawRectangle.Width < 0 || drawRectangle.Y > WindowHeight || drawRectangle.Y + drawRectangle.Height < 0)
            {
                if (!outside)
                {
                    count++;
                    offScreenCount = GetOffScreenCount(count);
                    outside = true;
                }
            }
            else
                outside = false;

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
            // draws teddy bears
            spriteBatch.Begin();

            spriteBatch.Draw(texture, drawRectangle, Color.Wheat);
            spriteBatch.DrawString(Arial20, offScreenCount, fontPos, Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private string GetOffScreenCount(int count)
        {
            return OFF_SCREEN_STRING_PREFIX + count;
        }
    }

}
