using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_TapTitan_Bones
{
    public class Animation
    {
        public Texture2D texture;

        public float frameTime;

        public bool isLooping;

        public int FrameCount
        {
            get { return texture.Width / FrameWidth; }
        }

        public int FrameWidth { get { return texture.Width/7; } }
        public int FrameHeight { get { return texture.Height; } }

        public Animation(Texture2D texture, float frameTime, bool isLooping)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            this.isLooping = isLooping;
        }
    }
}
