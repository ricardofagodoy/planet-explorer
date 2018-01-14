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


    public class ExibeVida : Base
    {
        SpriteFont fonte;
        Texture2D vidd;

        public ExibeVida(Game jogo) : base(jogo)
        {
            fonte = jogo.Content.Load<SpriteFont>(@"fontes\basica");
            vidd = jogo.Content.Load<Texture2D>(@"imagens\vidd");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sprite.Begin();
            sprite.Draw(vidd, new Vector2(170, 10), Color.White);
            sprite.DrawString(fonte, "x " + Camera.vida + "", new Vector2(200, 10), Color.White);
            sprite.End();
        }

    }

