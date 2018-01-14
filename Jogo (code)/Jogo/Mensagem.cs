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

public class Mensagem : Base
{
    string msg;
    SpriteFont fonte;
    Texture2D gameover;
    double tempo;

    public Mensagem(Game jogo, string msg)
        : base(jogo)
    {
        fonte = jogo.Content.Load<SpriteFont>(@"fontes\basica");
        gameover = jogo.Content.Load<Texture2D>(@"imagens\gameovers");
        tempo = 0;
        this.msg = msg;
    }

    public override void Update(GameTime gameTime)
    {
        if ((Camera.morreu) && (Keyboard.GetState().IsKeyDown(Keys.Enter)) )
        {
            if (Camera.vida < 1)
            {
                Camera.vida = 5;
                Camera.fracao_mapa = 835 / 25 + 7;
                Camera.posizao = 7;
                Camera.mapa_checkpoint = -175;
                Camera.pontos = 0;
                Camera.moedas = 0;
            }

            Camera.refaz = true;
            jogo.Components.Remove(this);
        }

        if (Camera.pause && (Keyboard.GetState().IsKeyDown(Keys.Enter)))
        {
            tempo = 0;

            while (Camera.pause)
            {
                tempo += gameTime.ElapsedGameTime.TotalSeconds;

                if (tempo > 2)
                {
                    Camera.pause = false;
                    jogo.Components.Remove(this);
                    tempo = 0;
                }
            }

        }


        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        sprite.Begin();
        
        if (Camera.vida < 1)
            sprite.Draw(gameover, Vector2.Zero, Color.White);
        else
           sprite.DrawString(fonte,msg, new Vector2(220, 300), Color.White);

        sprite.End();

        base.Draw(gameTime);
    }



}
