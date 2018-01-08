using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Boss : Alien
    {
        public int health;
        public Boss(Texture2D image, Vector2 position, Color tint, bool powerup,int health)
            :base(image,position,powerup)
        {
            this.health = health;
        }

       
       public void moveright ()
        {
            position.X+=4;
        }
        public void moveleft ()
        {
            position.X-=4;
        }
        public void terror (Rectangle ship)
        {
            position.X = ship.X;
        }


    }
}
