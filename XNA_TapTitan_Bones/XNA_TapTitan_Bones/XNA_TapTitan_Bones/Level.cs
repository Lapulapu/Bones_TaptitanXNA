using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA_TapTitan_Bones
{
    public class Level
    {
        public static int windowWidth = 800;
        public static int windowHeight = 580;
        #region Properties
        ContentManager content;

        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;


        Hero hero;
        Support supp;
        Enemy enemy;


        SpriteFont damageStringFont;

        Button playButton;
        int damageNumber;
        #endregion

        public Level(ContentManager content)
        {
            this.content = content;

            hero = new Hero(content, this);

            supp = new Support(content, this);

            enemy = new Enemy(content, this);
        }

        public void LoadContent()
        {
            background = content.Load<Texture2D>("AyyLmao/sound");
            
            damageStringFont = content.Load<SpriteFont>("SpriteFont1");
            playButton = new Button(content, "AyyLmao/buton", new Vector2(325,100));
            
            hero.LoadContent();
            supp.LoadContent();
            enemy.LoadContent();

        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;

            hero.Update(gameTime);
            supp.Update(gameTime);
            enemy.Update(gameTime);

            oldMouseState = mouseState;
            if(playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 1;
            }
            playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            hero.Draw(gameTime, spriteBatch);
            supp.Draw(gameTime, spriteBatch);
            enemy.Draw(gameTime, spriteBatch);
            playButton.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(damageStringFont, damageNumber+"Damage", Vector2.Zero, Color.Wheat);
            if(true)
            {

            }
        }
    }
}
