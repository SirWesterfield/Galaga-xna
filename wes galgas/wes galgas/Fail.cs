using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Background : Sprite
    {
        Rectangle screensize;
        
        public Background(Texture2D image, Vector2 position, Rectangle screensize)
            :base(image,position)
        {
            this.screensize = screensize;
            
        }

        public override void Draw (SpriteBatch spritebatch, Color tint)
        {
            spritebatch.Draw(image, screensize, tint);
        }

    }
}
