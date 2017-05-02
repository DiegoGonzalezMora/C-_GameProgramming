using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RubberChickenGame
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

        const int NumChickens = 20;
        const int ChickenDamage = 50;

        // sprites saved for efficiency
        Texture2D chickenSprite;
        Texture2D bearSprite;
        Texture2D explosionSpriteStrip;

        // game entities
        List<RubberChicken> chickens = new List<RubberChicken>(NumChickens);
        List<TeddyBear> bears = new List<TeddyBear>();
        List<Explosion> explosions = new List<Explosion>();

        // teddy bear spawn support
        const float TeddyBearSpeed = 0.1f;
        const int TotalSpawnMilliseconds = 2000;
        int elapsedSpawnMilliseconds = 0;
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set resolution and make mouse visible
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

            // load assets
            chickenSprite = Content.Load<Texture2D>(@"graphics\rubberchicken");
            bearSprite = Content.Load<Texture2D>(@"graphics\teddybear");
            explosionSpriteStrip = Content.Load<Texture2D>(@"graphics\explosion");

            // spawn initial rubber chickens
            SpawnInitialRubberChickens();
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

            // update game entities
            MouseState mouse = Mouse.GetState();
            foreach (RubberChicken chicken in chickens)
            {
                // NOTE: changed rubber chicken speed to float for finer granularity
                chicken.Update(gameTime, mouse);
            }
            foreach (TeddyBear bear in bears)
            {
                bear.Update(gameTime);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Update(gameTime);
            }

            // check for collisions between chickens and teddies
            // NOTE: Using nested loops. Need outer for loop because we might add chickens
            for (int i = 0; i < chickens.Count; i++)
            {
                foreach (TeddyBear bear in bears)
                {
                    if (chickens[i].Active &&
                        bear.Active &&
                        chickens[i].CollisionRectangle.Intersects(bear.CollisionRectangle))
                    {
                        // detected collision, apply damage to bear and explode as appropriate
                        // NOTE: Added health field and TakeDamage methods to TeddyBear 
                        bear.TakeDamage(chickens[i].Damage);
                        if (!bear.Active)
                        {
                            // NOTE: Changed explosion class to start playing on creation
                            explosions.Add(new Explosion(explosionSpriteStrip,
                                bear.CollisionRectangle.Center.X,
                                bear.CollisionRectangle.Center.Y));
                        }

                        // explode chicken and spawn new chicken at start location of this one
                        // NOTE: Cool bug when I tried testing with above in place but not this code
                        // NOTE: Added GetChickenStartY here (duplicated code in multiple places)
                        chickens[i].Active = false;
                        explosions.Add(new Explosion(explosionSpriteStrip,
                            chickens[i].CollisionRectangle.Center.X,
                            chickens[i].CollisionRectangle.Center.Y));
                        chickens.Add(new RubberChicken(chickenSprite,
                            new Vector2(chickens[i].CollisionRectangle.Center.X,
                                GetChickenStartY()),
                                ChickenDamage));
                    }
                }
            }

            // spawn teddy as appropriate
            elapsedSpawnMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedSpawnMilliseconds >= TotalSpawnMilliseconds)
            {
                elapsedSpawnMilliseconds = 0;

                // NOTE: Added a new constructor for providing sprite and velocity
                // NOTE: TeddyBear constructors should be cleaned up!
                // NOTE: Turned off teddy bouncing for this game
                bears.Add(new TeddyBear(bearSprite,
                    rand.Next(WindowWidth - bearSprite.Width + 1),
                    -bearSprite.Height / 2,
                    new Vector2(0, TeddyBearSpeed),
                    WindowWidth, WindowHeight));
            }

            // check for chicken leaving window
            foreach (RubberChicken chicken in chickens)
            {
                if (chicken.CollisionRectangle.Bottom < 0)
                {
                    // NOTE: Added Reset method to RubberChicken
                    chicken.Reset(GetChickenStartY());
                }
            }

            // check for teddy leaving window
            foreach (TeddyBear bear in bears)
            {
                if (bear.CollisionRectangle.Top > WindowHeight)
                {
                    bear.Active = false;
                }
            }

            // clean out dead chickens
            for (int i = chickens.Count - 1; i >= 0; i--)
            {
                if (!chickens[i].Active)
                {
                    chickens.RemoveAt(i);
                }
            }

            // clean out dead teddies
            for (int i = bears.Count - 1; i >= 0; i--)
            {
                if (!bears[i].Active)
                {
                    bears.RemoveAt(i);
                }
            }

            // clean out dead explosions
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                if (!explosions[i].Active)
                {
                    explosions.RemoveAt(i);
                }
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

            // draw game entities
            spriteBatch.Begin();
            foreach (RubberChicken chicken in chickens)
            {
                chicken.Draw(spriteBatch);
            }
            foreach (TeddyBear bear in bears)
            {
                bear.Draw(spriteBatch);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        #region Private methods

        /// <summary>
        /// Spawns the initial row of rubber chickens
        /// </summary>
        private void SpawnInitialRubberChickens()
        {
            // use rubber chicken width for horizontal placement
            int xSpacing = WindowWidth / NumChickens;
            int currentX = xSpacing / 2;

            // spawn the chickens
            int y = GetChickenStartY();
            for (int i = 0; i < NumChickens; i++)
            {
                chickens.Add(new RubberChicken(chickenSprite,
                    new Vector2(currentX, y), ChickenDamage));
                currentX += xSpacing;
            }
        }

        /// <summary>
        /// Gets the starting y location for the center of rubber chickens
        /// </summary>
        /// <returns>the startting y location</returns>
        private int GetChickenStartY()
        {
            return WindowHeight - chickenSprite.Height / 2;
        }

        #endregion
    }
}
