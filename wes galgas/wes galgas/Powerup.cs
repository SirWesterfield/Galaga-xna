using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Powerup : Sprite
    {
        
        public Powerup (Texture2D image, Vector2 position, Color tint)
            :base(image,position)
        {
            
        }


        public bool intersect(Rectangle hitbx)
        {
            if (Hitbox.Intersects(hitbx))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void movedown ()
        {
            position.Y++;
        }



    }
}
