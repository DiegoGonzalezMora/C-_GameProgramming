using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TeddyMineExplosion;

namespace ProgrammingAssignment5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int Windows_Width = 800;
        const int Windows_Height = 600;

        Texture2D mineSprite;
        List<Mine> mines;

        Texture2D bearSprite;
        List<TeddyBear> bears;

        private ButtonState PreviousButtonState;
        Random rand = new Random();

        float spawnDelayTimeMilliSeconds;
        int elapsedSpawnDelayMilliseconds;

        Texture2D explosionSprite;
        List<Explosion> explosions;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            graphics.PreferredBackBufferWidth = Windows_Width;
            graphics.PreferredBackBufferHeight = Windows_Height;
            IsMouseVisible = true;

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
            mineSprite = Content.Load<Texture2D>(@"Graphics/mine");
            mines = new List<Mine>();

            bearSprite = Content.Load<Texture2D>(@"Graphics/teddyBear");
            bears = new List<TeddyBear>();

            spawnDelayTimeMilliSeconds = (float)(rand.Next(1000, 3000));
            elapsedSpawnDelayMilliseconds = 0;
            bears.Add(new TeddyBear(bearSprite, new Vector2((float)(rand.NextDouble() - 0.5), (float)(rand.NextDouble() - 0.5)), Windows_Width, Windows_Height));

            explosionSprite = Content.Load<Texture2D>(@"Graphics/explosion");
            explosions = new List<Explosion>();
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
                PreviousButtonState == ButtonState.Pressed)
            {
                mines.Add(new Mine(mineSprite, mouse.X, mouse.Y));
            }
            PreviousButtonState = mouse.LeftButton;
            elapsedSpawnDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedSpawnDelayMilliseconds >= spawnDelayTimeMilliSeconds)
            {
                elapsedSpawnDelayMilliseconds = 0;
                spawnDelayTimeMilliSeconds = (float)(rand.Next(1000, 3000));
                bears.Add(new TeddyBear(
                            bearSprite,
                            new Vector2((float)(rand.NextDouble() - 0.5), (float)(rand.NextDouble() - 0.5)), Windows_Width, Windows_Height));
            }
            for (int i = 0; i < bears.Count; i++)
            {
                bears[i].Update(gameTime);
            }

            //Collision and explosions

            for (int j = bears.Count - 1; j >= 0; j--)
            {
                for (int i = mines.Count - 1; i >= 0; i--)
                {
                    if (bears[j].CollisionRectangle.Intersects(mines[i].CollisionRectangle))
                    {
                        bears[j].Active = false;
                        mines[i].Active = false;
                        explosions.Add(new Explosion(explosionSprite,
                            mines[i].CollisionRectangle.X,
                            mines[i].CollisionRectangle.Y));

                        mines.RemoveAt(i);
                        bears.RemoveAt(j);
                        i = 0;
                    }
                }
            }


            foreach (Explosion explosion in explosions)
            {
                explosion.Update(gameTime);
            }
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
            for (int i = 0; i < mines.Count; i++)
            {
                mines[i].Draw(spriteBatch);
            }
            for (int i = 0; i < bears.Count; i++)
            {
                bears[i].Draw(spriteBatch);
            }
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}