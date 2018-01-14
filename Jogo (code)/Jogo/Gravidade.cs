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

    class Gravidade : DrawableGameComponent
    {
        double Time;
        Personagem p;
        List<MonstroAnimado> m;
        Game jogo;
        Mensagem me;

        bool vdd;


        public Gravidade(Game jogo, Personagem p, List<MonstroAnimado> m) : base(jogo)
        {
            Time = 0;

            this.jogo = jogo;
            this.p = p;
            this.m = m;
            me = new Mensagem(jogo, "Pressione ENTER para recomecar");
            vdd = true;

        }

        public override void Update(GameTime gameTime)
        {
            if (Camera.morreu)
            {
                if (vdd)
                {
                    jogo.Components.Add(me);
                    vdd = false;
                }
            }
            else
            {
                if (p.sprite_animado.pos.Y >= 601)
                {
                    Camera.vida--;
                    Camera.armadura = false;
                    Camera.morreu = true;
                    Camera.moveu = false;
                    Camera.Cam.X = 0;
                }
            }
            if ((!Camera.pause) && (!Camera.foguete))
            {

                for (int i = 0; i < 20; i++)
                {
                    Time += gameTime.ElapsedGameTime.TotalSeconds;

                    if (Time > 0.2)
                    {
                        if (Camera.grav)
                            p.sprite_animado.pos.Y += Camera.direcao.Y * 5f;
                        else
                        p.sprite_animado.pos.Y += Camera.direcao.Y*1.5f;

                        for (int u = 0; u < m.Count; u++)
                        {
                            m[u].spr.pos.Y += (m[u].gravidade * m[u].spr.direcao.Y);
                            m[u].gravidade += m[u].gravidade * 0.01f;
                        }


                        Time = 0;
                    }
                }
            }


                                                         
            base.Update(gameTime);
        }
    }

