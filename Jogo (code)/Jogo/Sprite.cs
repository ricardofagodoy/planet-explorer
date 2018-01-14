using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.IO;

    public class Sprite
    {
        public Texture2D textura;
        public Vector2 pos;
        protected float velocidade;


        public float Speed
        {
            get { return velocidade; }
            set { velocidade = value; }
        }

        public Sprite(Texture2D textura, Vector2 pos, float speed)
        {
            this.textura = textura;
            this.pos = pos;
            this.velocidade = speed;
        }

        public virtual void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(textura,pos,Color.White);
            sprite.End();

            
        }



    }
