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

    class ColisaoDireita : Base
    {
        Mapa m;
        Personagem p;

        public ColisaoDireita(Game jogo, Mapa m, Personagem p)
            : base(jogo)
        {
        this.m = m;
        this.p = p;
        }


    public override void Update(GameTime gameTime)
    {
        for (int i = 0; i < m.map[0].getMap().GetLength(0); i++)
        {
            for (int j = (int) (Camera.posizao); j < Camera.fracao_mapa; j++)
            {
                if (Colidiu(new Vector2((m.x  + (j * m.tiles[m.map[0].getMap()[i, j]].size.X)),
                    (m.y + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y))),
                    new Vector2(((m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X))),
                    ((m.y-1 + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y)) + (m.tiles[m.map[0].getMap()[i, j]].size.Y)))))
                {
                    if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Impassable)
                    {

                        if ((Camera.direcao.X == 1) && ((435) >= (m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X-2))) && ((435) <= (m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X + 2))))
                        {
                            Camera.Cam.X = 0;
                            p.sprite_animado.Movendo = false;
                        }


                    }

                    if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Item)
                    {
                        if (m.map[0].getMap()[i, j] == 4)
                        {
                            m.map[0].getMap()[i, j] = 0;
                            Camera.vida++;
                            Camera.pontos += 30;
                        }

                        if (m.map[0].getMap()[i, j] == 10)
                        {
                            Camera.armadura = true;
                            p.tempo_armadura = 10;
                            p.sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipalarmadura");
                        }

                        if (m.map[0].getMap()[i, j] == 13)
                        {
                            m.map[0].getMap()[i + 1, j] = 0;
                            m.map[0].getMap()[i, j] = 0;
                            Camera.pontos += 1000;
                            Camera.fimdejogo = true;
                        }

                        if (m.map[0].getMap()[i, j] == 5)
                        {
                            m.map[0].getMap()[i, j] = 0;
                            Camera.pontos += 5;
                            Camera.moedas++;
                        }

                        if (m.map[0].getMap()[i, j] == 6)
                        {
                            m.map[0].getMap()[i, j] = 7;
                            Camera.mapa_checkpoint = m.x;
                            Camera.posizao_checkpoint = Camera.posizao;
                            Camera.fracao_mapa_checkpoint = Camera.fracao_mapa;
                            Camera.pontos += 50;
                        }

                        if (m.map[0].getMap()[i, j] == 8)
                        {
                            m.map[0].getMap()[i, j] = 0;
                            Camera.pontos += 100;
                            Camera.foguete = true;
                            p.sprite_animado.pos.Y = -100;
                        }
                    }
                                   
                }
           
            }
        }
 
        base.Update(gameTime);
    }

    private bool Colidiu(Vector2 min, Vector2 max)
    {
        float right, top, bottom,left;
        float left2, right2, top2, bottom2;

        right = p.sprite_animado.pos.X + 35;

        top = p.sprite_animado.pos.Y;
        bottom = p.sprite_animado.pos.Y + 48;

        left2 = min.X;           

        right2 = max.X;     

        top2 = min.Y;

        left = (p.sprite_animado.pos.X);

        bottom2 = max.Y;

        if (bottom < top2)
            return (false);

        if (top > bottom2)
            return (false);

        if (right < left2)
            return (false);

        if (left > right2)
            return (false);

        return (true);
    }

    public override void Draw(GameTime gameTime)
    {
            base.Draw(gameTime);
    }

    }
