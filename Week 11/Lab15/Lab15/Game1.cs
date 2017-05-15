using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Lab15
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WindowWidth = 800;
        const int WindowHeight = 600;

        SoundEffect upLeft;
        SoundEffect upRight;
        SoundEffect lowLeft;
        SoundEffect lowRight;

        ButtonState previousButtonState = ButtonState.Released;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

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

            // TODO: use this.Content to load your game content here
            upLeft = Content.Load<SoundEffect>("upperLeft");
            upRight = Content.Load<SoundEffect>("upperRight");
            lowLeft = Content.Load<SoundEffect>("lowerLeft");
            lowRight = Content.Load<SoundEffect>("lowerright");
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
            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Released &&
                previousButtonState == ButtonState.Pressed)
            {
                if (mouse.Position.X < WindowWidth / 2 && mouse.Position.Y < WindowHeight / 2)
                    upLeft.Play();
                else if (mouse.Position.X > WindowWidth / 2 && mouse.Position.Y < WindowHeight / 2)
                    upRight.Play();
                else if (mouse.Position.X < WindowWidth / 2 && mouse.Position.Y > WindowHeight / 2)
                    lowLeft.Play();
                else if (mouse.Position.X > WindowWidth / 2 && mouse.Position.Y > WindowHeight / 2)
                    lowRight.Play();
            }
            previousButtonState = mouse.LeftButton;

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

            base.Draw(gameTime);
        }
    }
}
