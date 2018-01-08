using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Ship : Sprite
    {
        int xspeed;
        int yspeed;
        
        public Ship (Texture2D image, Vector2 position,int xspeed,int yspeed)
            :base(image,position)
        {
            this.xspeed = xspeed;
            this.yspeed = yspeed;
        }


        
        public void Left ()
        {
            position.X-=xspeed;
        }
        public void Right ()
        {
            position.X+=xspeed;
        }
        public void Up ()
        {
            position.Y -= yspeed;
        }
        public void Down ()
        {
            position.Y += yspeed;
        }
       public void Bounds(int screenheight,int screenwidth)
        {
            
            
            if (position.Y + Hitbox.Width > screenheight)
            {
                position.Y = screenheight - Hitbox.Height;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X + Hitbox.Width > screenwidth)
            {
                position.X = screenwidth - Hitbox.Width;
            }
        }
        
        public bool hit (Rectangle AlazerHitbox)
        {
            if (AlazerHitbox.Intersects(Hitbox))
            {
                return true;
            }
            return false;
        }
        public void reset (int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

    }
}
