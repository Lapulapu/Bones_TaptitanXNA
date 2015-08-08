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
    public class Support
    {
        #region Properties
        Vector2 suppPosition;
        Texture2D supp1;
        ContentManager content;
        Level level;

        Animation idleAnimation;
        AnimationPlayer spritesupp;
        #endregion

        public Support(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }


        public void LoadContent()
        {

            supp1 = content.Load<Texture2D>("AyyLmao/agumon_jump.fw");
            supp2 = content.Load<Texture2D>("AyyLmao/agumon_attack.fw");

            idleAnimation = new Animation(supp1, 0.1f, true);

            int positionX = (Level.windowWidth / 2) - (supp1.Width / 2);
            int positionY = (Level.windowHeight / 2) - (supp1.Height / 3);
            suppPosition = new Vector2((float)positionX, (float)positionY);
            spritesupp.PlayAnimation(idleAnimation);

        }
        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                suppPosition.X = 300;
                spritesupp.PlayAnimation(new Animation(content.Load<Texture2D>("AyyLmao/agumon_attack.fw"), 0.1f, true));

            }
            if (level.mouseState.RightButton == ButtonState.Pressed)
            {
                suppPosition.X = 300;
                spritesupp.PlayAnimation(idleAnimation);
            }


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(supp, suppPosition, Color.White);
            spritesupp.Draw(gameTime, spriteBatch, suppPosition, SpriteEffects.None);
        }

        public Animation bikeAnimation { get; set; }

        public Texture2D bike { get; set; }

        public Texture2D supp2 { get; set; }
    }
}
