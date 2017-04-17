using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        const int WindowWidth = 800;
        const int WindowHeight = 600;

        //Mine support
        List<Mine> mines = new List<Mine>();
        Texture2D mineSprite;
        // spawning support
        int TotalSpawnDelayMilliseconds = 1000;
        int elapsedSpawnDelayMilliseconds = 0;

        //Bear support 
        List<TeddyBear> bears = new List<TeddyBear>();
        Random rand = new Random();
        Texture2D bearSprite;
        TeddyBear teddyBear;

        //Explosion support
        List<Explosion> explosions = new List<Explosion>();
        Texture2D explosionSprite;
        Explosion explosion;

        // click processing
        bool leftClickStarted = false;
        bool leftButtonReleased = true;

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

            // TODO: use this.Content to load your game content here
            mineSprite = Content.Load<Texture2D>(@"graphics/mine");
            bearSprite = Content.Load<Texture2D>(@"graphics/teddybear");
            explosionSprite = Content.Load<Texture2D>(@"graphics/explosion");
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

            // check for right click started
            if (mouse.LeftButton == ButtonState.Pressed &&
                leftButtonReleased)
            {
                leftClickStarted = true;
                leftButtonReleased = false;
            }
            else if (mouse.LeftButton == ButtonState.Released)
            {
                leftButtonReleased = true;

                // if right click finished, add new pickup to list
                if (leftClickStarted)
                {
                    leftClickStarted = false;
                    
                    //add a new mine to the end of the list of mines
                    mines.Add(new Mine(mineSprite, mouse.X, mouse.Y));
                }
            }

            TotalSpawnDelayMilliseconds = rand.Next(1000, 3001);

            // spawn teddies as appropriate
            elapsedSpawnDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedSpawnDelayMilliseconds >= TotalSpawnDelayMilliseconds)
            {
                elapsedSpawnDelayMilliseconds = 0;

                teddyBear = new TeddyBear(bearSprite, new Vector2((float)(-0.5 + rand.NextDouble()), 
                                            (float)(-0.5 + rand.NextDouble())), WindowWidth, WindowHeight);
                bears.Add(teddyBear);
            }

            // update and blow up teddy bears
            foreach (TeddyBear teddyBear in bears)
            {
                teddyBear.Update(gameTime);


                // check for collision between collecting teddy and mine
                foreach (Mine mine in mines)
                {
                    if (mine.CollisionRectangle.Intersects(teddyBear.CollisionRectangle))
                    {
                        teddyBear.Active = false;
                        mine.Active = false;

                        explosion = new Explosion(explosionSprite, teddyBear.CollisionRectangle.X,
                            teddyBear.CollisionRectangle.Y);

                        explosions.Add(explosion);
                    }
                }
            }

            // update explosions
            foreach (Explosion explosion in explosions)
            {
                explosion.Update(gameTime);
            }

            // remove not playing explosion from the list. Shouldn't this remove the sprite? o.O
           /* for (int i = explosions.Count - 1; i >= 0; i--)
            {
                if (!explosions[i].Playing)
                    explosions.RemoveAt(i);
            }*/

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
            foreach (Mine mine in mines)
            {
                mine.Draw(spriteBatch);
            }
            foreach (TeddyBear teddyBear in bears)
            {
                teddyBear.Draw(spriteBatch);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
