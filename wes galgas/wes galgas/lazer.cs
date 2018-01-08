using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Lazer : Sprite
    {
        
        public Lazer(Texture2D image, Vector2 Position)
            :base(image,Position)
        {

        }
        public void fire(int y)
        {            
                position.Y -= y;
        }

        public bool offscreen(int screenheight)
        {
            if (position.Y>screenheight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
