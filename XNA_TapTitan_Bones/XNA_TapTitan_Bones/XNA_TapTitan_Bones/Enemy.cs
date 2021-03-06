﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNA_TapTitan_Bones
{
    public class Enemy
    {
        #region Properties
        Vector2 enemyPosition;
        Texture2D enemy;
        ContentManager content;
        Level level;

        Animation idleAnimation;
        AnimationPlayer spriteenemy;
        #endregion

        public Enemy(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }


        public void LoadContent()
        {

            enemy = content.Load<Texture2D>("AyyLmao/gallantmon_attack.fw");
            enemy2 = content.Load<Texture2D>("AyyLmao/gallantmon_attack2.fw");

            idleAnimation = new Animation(enemy, 0.1f, true);

            int positionX = (Level.windowWidth / 2) - (enemy.Width / 2);
            int positionY = (Level.windowHeight / 2) - (enemy.Height / 3);
            enemyPosition = new Vector2((float)positionX, (float)positionY);
            spriteenemy.PlayAnimation(idleAnimation);

        }
        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                enemyPosition.X = 500;
                spriteenemy.PlayAnimation(new Animation(content.Load<Texture2D>("AyyLmao/gallantmon_attack.fw"), 0.1f, true));

            }
            if (level.mouseState.RightButton == ButtonState.Pressed)
            {
                enemyPosition.X = 500;
                spriteenemy.PlayAnimation(idleAnimation);
            }


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(supp, suppPosition, Color.White);
            spriteenemy.Draw(gameTime, spriteBatch, enemyPosition, SpriteEffects.None);
        }

        public Animation bikeAnimation { get; set; }

        public Texture2D bike { get; set; }

        public Texture2D supp2 { get; set; }

        public Texture2D enemy2 { get; set; }
    }
}
