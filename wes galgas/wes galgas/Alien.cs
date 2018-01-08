using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Alien : Sprite
    {
        public bool powerup;
        public Alien(Texture2D image,Vector2 Position ,bool powerup)
            :base(image,Position)
        {
            this.powerup = powerup;
        }

        public bool hit (Rectangle lazerhitbox)
        {
            if (lazerhitbox.Intersects(Hitbox))
            {
                return true;
            }

            return false;
        }
        
        public void move (int x)
        {
            position.X -= x;
        }

        public bool hitScreen (int screenwidth)
        {
            if (position.X < 0)
            {
                return true;
            }
            if (position.X > screenwidth - Hitbox.Width)
            {
                return true;
            }
            
            return false;
        }
        
        public void moveDown ()
        {
            position.Y += 10;
        }
        
    }
}
