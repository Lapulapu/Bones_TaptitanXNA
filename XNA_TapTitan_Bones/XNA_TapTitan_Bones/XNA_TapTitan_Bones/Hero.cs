using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNA_TapTitan_Bones
{
    public class Hero
    {
        #region Properties
        Vector2 playerPosition;
        Texture2D player;
        ContentManager content;
        Level level;

        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }


        public void LoadContent()
        {

            player = content.Load<Texture2D>("AyyLmao/termon_attack.fw");
            bike = content.Load<Texture2D>("AyyLmao/termon_attack2.fw");

            idleAnimation = new Animation(player, 0.1f, true);
            bikeAnimation = new Animation(player, 0.1f, true);

            int positionX = (Level.windowWidth / 2) - (player.Width / 2);
            int positionY = (Level.windowHeight / 2) - (player.Height / 4);
            playerPosition = new Vector2((float)positionX, (float)positionY);
            spritePlayer.PlayAnimation(idleAnimation);

        }
        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                playerPosition.X = 400;
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("AyyLmao/termon_attack2.fw"), 0.1f, true));

            }
            if (level.mouseState.RightButton == ButtonState.Pressed)
            {
                playerPosition.X = 400;
                spritePlayer.PlayAnimation(idleAnimation);
            }


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, Color.White);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
        }

        public Animation bikeAnimation { get; set; }

        public Texture2D bike { get; set; }
    }
}
