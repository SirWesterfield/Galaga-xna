using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Ball : Sprite
    {
        int screenwidth;
        int screenheight;
        public int xspeed;
        public int yspeed;
        bool bounce = true;
        public Ball (Texture2D image, Vector2 position, int screenwidth, int screenheight, int xspeed, int yspeed)
            :base(image,position)
        {
            this.screenwidth = screenwidth;
            this.screenheight = screenheight;
            this.xspeed = xspeed;
            this.yspeed = yspeed;
        }

        public bool screenhitx ()
        {
            if (position.X< 0|| position.X + Hitbox.Width> screenwidth)
            {
                return true;
            }
                return false;
        }
        
        public bool screenhitmiddle(int screenmiddle)
        {
            if ( position.Y + Hitbox.Height > screenmiddle)
            {
                bounce = false;
                return true;
            }
            return false;
        }
        public void move ()
        {
            position.X += xspeed;
            if (bounce)
            {
                position.Y += yspeed;
            }
        }
        public bool hit (Rectangle ohitbox)
        {
            if (Hitbox.Intersects(ohitbox))
            {
               
                return true;
            }
            return false;
        }

    }
}
