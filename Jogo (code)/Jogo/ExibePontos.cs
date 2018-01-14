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


    public class ExibePontos : Base
    {
        SpriteFont fonte;
        Texture2D moeda;

        public ExibePontos(Game jogo) : base(jogo)
        {
            fonte = jogo.Content.Load<SpriteFont>(@"fontes\basica");
            moeda = jogo.Content.Load<Texture2D>(@"imagens\item2");
        }

        public override void Update(GameTime gameTime)
        {
            if (Camera.moedas > 99)
            {
                Camera.vida++;
                Camera.moedas = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sprite.Begin();
            sprite.DrawString(fonte, "Pontos: " + Camera.pontos + "", new Vector2(550, 10), Color.White);
            sprite.DrawString(fonte, "x " + Camera.moedas + "", new Vector2(380, 10), Color.White);
            sprite.Draw(moeda, new Vector2(355, 15), Color.White);
            sprite.End();
        }

    }

