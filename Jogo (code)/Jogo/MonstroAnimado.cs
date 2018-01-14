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

public class MonstroAnimado : Base
{
    public SpriteAnimadoMonstro spr { get; set; }
    public int vida;
    double tempo;
    double alcance, tipo,andou;
    public bool andar; 

    public float gravidade {get; set;}


    public MonstroAnimado(Game jogo, SpriteAnimadoMonstro spr, int vida, double tipo, double alcance)
        : base(jogo)
    {
        this.spr = spr;
        this.vida = vida;
        tempo = 0.2;
        this.alcance = alcance;
        this.tipo = tipo;
        gravidade = 0;
        andar = false;
        andou = 0;
    }

    protected void movimento()
    {

    }

    public override void Update(GameTime gameTime)
    {
        if (!Camera.pause)
        {
            if (tipo == 1)
            {
                gravidade = 0;

                tempo += gameTime.ElapsedGameTime.TotalSeconds;

                if (tempo >= 0.02)
                {
                    spr.pos.X += spr.speed * spr.direcao.X;
                    andou++;

                    if (andou >= alcance)
                    {
                        spr.direcao.X *= -1;
                        andou = 0;
                    }

                    tempo = 0;
                }
            }

            if (!andar)
                if ((spr.pos.X <= 800) && (spr.pos.X >= 0))
                {
                    andar = true;
                    gravidade = 1;
                }

            if (andar)
            {
                if ((spr.pos.X > 800) || (spr.pos.X < -55))
                {
                    andar = false;
                    gravidade = 0;
                }

                if (tipo == 0)
                {
                    tempo += gameTime.ElapsedGameTime.TotalSeconds;

                    if (tempo >= 0.02)
                    {
                        spr.pos.X += spr.speed * spr.direcao.X;
                        tempo = 0;
                    }

                }

                if (tipo == 2)
                {
                    gravidade = 0.1f;

                    tempo += gameTime.ElapsedGameTime.TotalSeconds;

                    if (tempo >= 0.02)
                    {
                        spr.pos.X += spr.speed * spr.direcao.X;
                        andou++;

                        if (andou >= alcance)
                        {
                            spr.direcao.X *= -1;
                            andou = 0;
                        }

                        tempo = 0;
                    }
                }
            }

            if (spr.direcao.X == -1)
                spr.FrameCoordinates = new Vector2(2, 1);
            if (spr.direcao.X == 1)
                spr.FrameCoordinates = new Vector2(2, 0);
            if (spr.direcao.X == 0)
            {
                spr.msPerFrame = 170;
                spr.FrameCoordinates = new Vector2(5, 2);
            }
            spr.Update(gameTime);
            base.Update(gameTime);
        }
    }

    public override void Draw(GameTime gameTime)
    {
        if ((spr.pos.X <= 800) && (spr.pos.X >= 0))
            spr.Draw(sprite);

            base.Draw(gameTime);
    }


}
