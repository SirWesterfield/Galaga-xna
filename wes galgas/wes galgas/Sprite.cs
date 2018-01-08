using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Sprite
    {
        public Texture2D image;
        public Vector2 position;
        


        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            }


        }

        public Sprite (Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;
            
        }

        public virtual void Draw (SpriteBatch spritebatch, Color tint)
        {
            spritebatch.Draw(image, position, tint);
            
        }
        
    }
}
