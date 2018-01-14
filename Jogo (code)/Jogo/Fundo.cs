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

    public class Fundo : Base
    {
        Texture2D textura;  
        float x;

        public Fundo(Game jogo, Texture2D textura, float x) : base(jogo)
        {
            this.textura = textura;
            this.x = x;
        }

        public override void Update(GameTime gameTime)
        {
            if (Camera.atualiza == true)
              x += Camera.Cam.X;

            if (x< 0) x = 800;
            if ( x > 800) x = 0;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sprite.Begin();
            sprite.Draw(textura, new Vector2(x,0), Color.White);
            sprite.Draw(textura, new Vector2((x-800),0), Color.White);
            sprite.End();

            base.Draw(gameTime);
        }

    }
