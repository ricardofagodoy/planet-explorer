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

public class ColisaoChao : Base
{
    public Mapa m;
    public Personagem p;

    public ColisaoChao(Game jogo, Mapa m, Personagem p)
        : base(jogo)
    {
        this.m = m;
        this.p = p;
    }

    public override void Update(GameTime gameTime)
    {
        Camera.direcao.Y = 1;

        for (int i = 0; i < m.map[0].getMap().GetLength(0); i++)
        {
            for (int j = (int)(Camera.posizao + 1.5f); j < Camera.fracao_mapa + 1.5f; j++)
            {
                if (Colidiu(new Vector2((m.x + 1.01f + (j * m.tiles[m.map[0].getMap()[i, j]].size.X)),
                    (m.y - 2 + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y))),
                    new Vector2(((m.x - 1 + (j * m.tiles[m.map[0].getMap()[i, j]].size.X)) + (m.tiles[m.map[0].getMap()[i, j]].size.X)),
                    ((m.y + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y)) + (m.tiles[m.map[0].getMap()[i, j]].size.Y)))))
                {
                    if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Impassable)
                    {
                        if (((p.sprite_animado.pos.Y + 50) >= ((m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y)))) && ((p.sprite_animado.pos.Y + 50) <= ((m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y) + 8))))
                        {
                            if (m.map[0].getMap()[i, j] == 1)
                                m.map[0].getMap()[i, j] = 0;
                            else
                            {
                                p.sprite_animado.pos.Y = m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y) - 50;

                                if (!Camera.moveu)
                                    Camera.nasce = false;

                                Camera.direcao.Y = 0;
                                Camera.Speed = 1;
                                Camera.grav = false;


                                //jogo.Components.Remove(pu);
                               // jogo.Components.Add(pu);
                                p.sprite_animado.Pulando = false;
                                Camera.podepular = 1;
                                Camera.ground = true;
                            }
                        }
                    }

                    // parede secreta

                    if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Passable)
                    {
                        if (m.map[0].getMap()[i, j] == 1)
                            m.map[0].getMap()[i, j] = 0;

                        if (m.map[0].getMap()[i, j] == 15)
                            m.map[0].getMap()[i, j] = 0;

                        if (m.map[0].getMap()[i, j] == 11)
                        {
                            m.map[0].getMap()[i, j] = 3;

                            if (((p.sprite_animado.pos.Y + 50) >= ((m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y)))) && ((p.sprite_animado.pos.Y + 50) <= ((m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y) + 8))))
                            {
                                p.sprite_animado.pos.Y = m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y) - 50;

                                if (!Camera.moveu)
                                    Camera.nasce = false;

                                Camera.direcao.Y = 0;
                                Camera.Speed = 1;

                                p.sprite_animado.Pulando = false;
                                Camera.podepular = 1;
                                Camera.ground = true;
                            }
                        }
                    }
                    //

                }

            }
        }
        base.Update(gameTime);
    }

    public bool Colidiu(Vector2 min, Vector2 max)
    {
        float left, right, top, bottom;
        float left2, right2, top2, bottom2;

        left = (p.sprite_animado.pos.X);
        right = p.sprite_animado.pos.X + 36;

        top = p.sprite_animado.pos.Y;
        bottom = p.sprite_animado.pos.Y + 50;

        left2 = min.X;

        right2 = max.X;

        top2 = min.Y;

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
