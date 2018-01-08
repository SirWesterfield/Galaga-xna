using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace wes_galgas
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ship ship;
        Background fail;
        Background background;
        Background win;
        List<Lazer> lazer = new List<Lazer>();
        List<AlienLazer> Alazer = new List<AlienLazer>();
        List<Alien> alien = new List<Alien>();
        List<Powerup> power = new List<Powerup>();
        List<littleship> smallship = new List<littleship>();
        List<Ball> ball = new List<Ball>();
        KeyboardState prevKs;
        int alienX = 1;
        TimeSpan Wait;
        TimeSpan Time;
        Random random = new Random();
        bool Alive = true;
        bool congrats = false;
        bool Begin = false;
        int waitTime = 1000;
        TimeSpan wait2;
        TimeSpan Time2;
        bool invincible = false;
        int waittime2 = 5000;
        int wave = 1;
        SpriteFont font;
        Boss boss;
        bool bossfight = false;
        int bosshit = 0;
        TimeSpan bosswait;
        TimeSpan bosstime;
        bool rapid = false;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            win = new Background(Content.Load<Texture2D>("win"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            background = new Background(Content.Load<Texture2D>("background"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            fail = new Background(Content.Load<Texture2D>("gameover"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2),  new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            ship = new Ship(Content.Load<Texture2D>("ship"), new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height - 70), 10, 10);
            
                for (int x = 10; x< 100; x += 40)
                {
                    smallship.Add(new littleship(Content.Load<Texture2D>("shiphealth"), new Vector2(x, GraphicsDevice.Viewport.Height - 40)));
                    
                }
            
            for (int y = 50; y < GraphicsDevice.Viewport.Height / 2; y += 50)
            {
                for (int x = 100; x < GraphicsDevice.Viewport.Width; x += 60)
                {
                    alien.Add(new Alien(Content.Load<Texture2D>("alien"), new Vector2(GraphicsDevice.Viewport.Width - x, y), false));
                }
            }

            Wait = TimeSpan.FromMilliseconds(waitTime);
            wait2 = TimeSpan.FromMilliseconds(waittime2);
            bosswait = TimeSpan.FromMilliseconds(1000);
        }


        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            
            Time2 += gameTime.ElapsedGameTime;
            Time += gameTime.ElapsedGameTime;
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.W)&&alien.Count>0)
            {
                alien.Remove(alien[0]);
            }
            if (ks.IsKeyDown(Keys.B))
            {
                alien.Clear();
                wave++;
            }
            
            {
                if (ks.IsKeyDown(Keys.R) && prevKs.IsKeyUp(Keys.R)&& Alive == false)
                {
                    waitTime = 1000;
                    waittime2 = 5000;
                    Alive = true;
                    invincible = false;
                    power.Clear();
                    congrats = false;
                    Begin = false;
                    ship.reset(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height - 70);
                    Alazer.Clear();
                    lazer.Clear();
                    alien.Clear();
                    bossfight = false;
                    bosshit = 0;
                    wave = 1;
                    ball.Clear();
                    for (int x = 10; x < 100; x += 40)
                    {
                        smallship.Add(new littleship(Content.Load<Texture2D>("shiphealth"), new Vector2(x, GraphicsDevice.Viewport.Height - 40)));

                    }
                    for (int y = 50; y < GraphicsDevice.Viewport.Height / 2; y += 50)
                    {
                        for (int x = 100; x < GraphicsDevice.Viewport.Width; x += 60)
                        {

                            alien.Add(new Alien(Content.Load<Texture2D>("alien"), new Vector2(GraphicsDevice.Viewport.Width - x, y), false));
                        }
                    }

                }
            }
            if (Alive || congrats == false)
            {
            if (smallship.Count > 3)
            {
                smallship.Remove(smallship[smallship.Count - 1]);
            }
                if (alien.Count == 0 && bossfight == false)
                {
                    ship.reset(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height - 70);
                    wave++;
                    int randnum = random.Next(0, 10);
                    if (randnum == 0)
                    {
                        waitTime = 600;
                        bossfight = true;
                        boss = new Boss(Content.Load<Texture2D>("evilship"), new Vector2(GraphicsDevice.Viewport.Width / 2, 50), Color.White, false, 50);
                        
                    }
                    else
                    {
                        for (int y = 50; y < GraphicsDevice.Viewport.Height / 2; y += 50)
                        {
                            for (int x = 100; x < GraphicsDevice.Viewport.Width; x += 60)
                            {

                                alien.Add(new Alien(Content.Load<Texture2D>("alien"), new Vector2(GraphicsDevice.Viewport.Width - x, y), false));
                            }
                        }
                    }

                    waitTime -= 100;

                    Begin = false;
                    invincible = false;
                    lazer.Clear();
                    Alazer.Clear();
                    power.Clear();
                    ball.Clear();
                }
                if (ks.IsKeyDown(Keys.Left))
                {
                    ship.Left();
                }
                if (ks.IsKeyDown(Keys.Right))
                {
                    ship.Right();
                }
                if (ks.IsKeyDown(Keys.Up))
                {
                    ship.Up();
                }
                if (ks.IsKeyDown(Keys.Down))
                {
                    ship.Down();
                }
                for (int balli = 0; balli < ball.Count; balli++)
                {
                    for (int lazeri = 0; lazeri < lazer.Count; lazeri++)
                    {
                        if (ball[balli].hit(lazer[lazeri].Hitbox))
                        {
                            lazer.Remove(lazer[lazeri]);

                        }
                    }
                }
                if (ks.IsKeyDown(Keys.Space) /*&& prevKs.IsKeyUp(Keys.Space)*/)
                {
                    Begin = true;
                    lazer.Add(new Lazer(Content.Load<Texture2D>("lazer"), new Vector2(ship.position.X + ship.Hitbox.Width / 2 - 5, ship.position.Y)));
                }
                for (int i = 0; i < Alazer.Count; i++)
                {

                    if (ship.hit(Alazer[i].Hitbox))
                    {
                        if (invincible == false)
                        {
                            if (smallship.Count > 0)
                            {
                                smallship.Remove(smallship[smallship.Count - 1]);
                            }
                            else
                            {
                                Alive = false;
                            }
                        }
                        Alazer.Remove(Alazer[i]);

                    }
                    
                }

                
                if (Time > Wait && alien.Count > 0 && Begin)
                {
                    Time = TimeSpan.Zero;
                    int radalien = random.Next(0, alien.Count);
                    Alazer.Add(new AlienLazer(Content.Load<Texture2D>("Alienlazer"), new Vector2(alien[radalien].position.X + alien[radalien].Hitbox.Width / 2 - 5, alien[radalien].position.Y), Color.White));

                    if (ball.Count > 0)
                    {
                        int ballfire = random.Next(0, ball.Count);
                        Alazer.Add(new AlienLazer(Content.Load<Texture2D>("Alienlazer"), new Vector2(ball[ballfire].position.X + ball[ballfire].Hitbox.Width / 2 - 5, ball[ballfire].position.Y), Color.White));
                    }
                }
                
                if (bossfight == false)
                {
                    for (int i = 0; i < Alazer.Count; i++)
                    {

                        Alazer[i].fire(-5);
                    }
                }
                for (int i = 0; i < lazer.Count; i++)
                {
                    lazer[i].fire(5);
                }
                ship.Bounds(GraphicsDevice.Viewport.Height,GraphicsDevice.Viewport.Width);
                
                prevKs = ks;
                int lazers = lazer.Count;
                for (int i = 0; i < lazers; i++)
                {
                    for (int ii = 0; ii < alien.Count; ii++)
                    {
                        if (alien[ii].hit(lazer[i].Hitbox))
                        {
                            int randnum = random.Next(0, 100);
                            if (randnum == 0)
                            {
                                power.Add(new Powerup(Content.Load<Texture2D>("powerup"), new Vector2(alien[ii].position.X, alien[ii].position.Y), Color.White));
                                
                            }
                            if (randnum > 95)
                            {
                                ball.Add(new Ball(Content.Load<Texture2D>("ball"), Vector2.One, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 2, 2));
                            }
                            alien.Remove(alien[ii]);
                            lazer.Remove(lazer[i]);

                            break;
                        }

                    }
                    lazers = lazer.Count;
                }

                for (int i = 0; i < alien.Count; i++)
                {
                    alien[i].move(alienX);
                    if (alien[i].hitScreen(GraphicsDevice.Viewport.Width))
                    {

                        alienX *= -1;

                    }

                }


                for (int i = 0;i<alien.Count;i++)
                {
                    if (ship.hit(alien[i].Hitbox))
                    {
                        if (invincible == false)
                        {
                            if (smallship.Count > 0)
                            {
                                smallship.Remove(smallship[smallship.Count - 1]);
                            }
                            else
                            {
                                Alive = false;
                            }
                        }
                       
                        
                            alien.Remove(alien[i]);
                        
                    }
                }
                for (int i = 0; i < power.Count; i++)
                {
                    power[i].movedown();

                    if (power.Count > 0 && power[i].intersect(ship.Hitbox))
                    {
                        invincible = true;
                        power.Remove(power[i]);
                    }
                }
                for (int i = 0; i < ball.Count; i++)
                {
                    if (ball[i].screenhitx())
                    {
                        ball[i].xspeed *= -1;
                    }
                    if (ball[i].screenhitmiddle(GraphicsDevice.Viewport.Height/2+50))
                    {
                        ball[i].yspeed *= -1;
                    }
                    ball[i].move();
                }
                
                if (bossfight)
                {

                    if (boss.position.X < ship.position.X)
                    {

                        boss.moveright();
                    }
                    if (boss.position.X > ship.position.X)
                    {

                        boss.moveleft();
                    }
                    
                    for (int i = 0; i < lazer.Count; i++)
                    {
                        if (boss.hit(lazer[i].Hitbox))
                        {
                            bosshit++;
                            boss.health--;
                            lazer.Remove(lazer[i]);
                            int randnum = random.Next(0, 10);
                            if (randnum == 0)
                            {
                                ball.Add(new Ball(Content.Load<Texture2D>("ball"), Vector2.One, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 5, 5));
                            }

                            
                        }
                    }
                    if (bosshit == 10)
                    {
                        waitTime = 100;
                        bosshit = 0;
                        rapid = true;
                        ball.Clear();
                    }
                    if (rapid)
                    {
                        bosstime += gameTime.ElapsedGameTime;
                    }
                    if (bosstime > bosswait && rapid)
                    {
                        bosstime = TimeSpan.Zero;
                        waitTime = 600;
                        rapid = false;
                    }

                    for (int i = 0; i < Alazer.Count; i++)
                    {
                        Alazer[i].fire(-10);
                    }
                    if (Time > Wait && Begin)
                    {
                        Time = TimeSpan.Zero;

                        Alazer.Add(new AlienLazer(Content.Load<Texture2D>("Alienlazer"), new Vector2(boss.position.X + boss.Hitbox.Width / 2 - 5, boss.position.Y), Color.White));
                    }
                    if (boss.health < 1)
                    {
                        bossfight = false;
                        waitTime = 1000;
                    }
                }
            }               
                Wait = TimeSpan.FromMilliseconds(waitTime);
                wait2 = TimeSpan.FromMilliseconds(waittime2);
            //if (ks.IsKeyDown(Keys.R) && prevKs.IsKeyUp(Keys.R))
            
            
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (Alive == false)
            {
                fail.Draw(spriteBatch, Color.White);
                spriteBatch.DrawString(font, "Press R to Play Again", new Vector2(330, 100), Color.CadetBlue);
            }
            if (Alive || congrats)
            {
                
                

                if (bossfight == false)
                {
                    background.Draw(spriteBatch, Color.White);
                }
                else
                {
                    background.Draw(spriteBatch, Color.Red);
                }
                for (int i = 0; i < ball.Count; i++)
                {
                    if (bossfight)
                    {
                        ball[i].Draw(spriteBatch, Color.DarkRed);
                    }
                    else
                    {
                        ball[i].Draw(spriteBatch, Color.LightGreen);
                    }
                }
                for (int i = 0; i < smallship.Count;i++)
                {
                    smallship[i].Draw(spriteBatch, Color.Gray);
                }
                for (int i = 0; i < power.Count; i++)
                {
                    power[i].Draw(spriteBatch, Color.White);
                }
                if (bossfight == true)
                {
                    boss.Draw(spriteBatch, Color.White);
                }
                if (invincible == false)
                {
                    ship.Draw(spriteBatch, Color.White);
                }
                else
                {
                    ship.Draw(spriteBatch, Color.CornflowerBlue);
                }

                for (int i = 0; i < lazer.Count; i++)
                {
                    lazer[i].Draw(spriteBatch, Color.White);
                }
                for (int i = 0; i < Alazer.Count; i++)
                {
                    if (bossfight == false)
                    {
                        Alazer[i].Draw(spriteBatch, Color.White);
                    }
                    if (bossfight)
                    {
                        Alazer[i].Draw(spriteBatch, Color.Red);
                    }
               }
                
                for (int i = 0; i < alien.Count; i++)
                {
                    alien[i].Draw(spriteBatch, Color.OliveDrab);
                }
                

                spriteBatch.DrawString(font, $"Wave: {wave}", Vector2.One, Color.SaddleBrown);
                if (bossfight)
                {
                    spriteBatch.DrawString(font, $"BossHealth: {boss.health}", new Vector2(500, 0), Color.SaddleBrown);
                }

            }
            if (congrats == true)
            {
                win.Draw(spriteBatch, Color.White);
                spriteBatch.DrawString(font, "Press R to Play Again", new Vector2(330, 100), Color.LightGreen);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
