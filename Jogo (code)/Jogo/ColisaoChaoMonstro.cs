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

public class ColisaoChaoMonstro : Base
{
    public Mapa m;
    public MonstroAnimado p;
    public Personagem per;
    public Song roido;

    public ColisaoChaoMonstro(Game jogo, Mapa m, MonstroAnimado p, Personagem per)
        : base(jogo)
    {
        this.m = m;
        this.p = p;
        this.per = per;
    }

    public override void Update(GameTime gameTime)
    {
        if ( p.spr.direcao.X != 0)
        {
        if ((per.sprite_animado.pos.X >= p.spr.pos.X - 39) && (per.sprite_animado.pos.X <= p.spr.pos.X + 39))
        {
            if ((per.sprite_animado.pos.Y >= p.spr.pos.Y - 45) && (per.sprite_animado.pos.Y <= p.spr.pos.Y - 41))
            {   
                p.spr.direcao.X = 0;
                Camera.Speed = 1;
                per.sprite_animado.Pulando = true;
                Camera.pontos += 15;

                if (!Camera.armadura)
                for (int i = 0; i < 150; i++)
                {
                    per.sprite_animado.pos.Y -= 0.35f;
                    per.sprite_animado.Movendo = true;
                }

            }

            if ((per.sprite_animado.pos.Y <= p.spr.pos.Y + 50) && (per.sprite_animado.pos.Y >= p.spr.pos.Y+2))
            {
                if (!Camera.armadura)
                {
                    Camera.vida--;
                    per.sprite_animado.pos.Y = 801;
                    Camera.morreu = true;
                    Camera.Cam.X = 0;
                }
                else
                    p.spr.direcao.X = 0;
            }
        }
        }
        if (p.spr.direcao.X != 0)
        {
            p.spr.direcao.Y = 1;

            for (int i = 0; i < m.map[0].getMap().GetLength(0); i++)
            {
                for (int j = (int)(Camera.posizao); j < Camera.fracao_mapa; j++)
                {
                    if (Colidiu(new Vector2((m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X)),
                        (m.y + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y))),
                        new Vector2(((m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X)) + (m.tiles[m.map[0].getMap()[i, j]].size.X)),
                        ((m.y + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y)) + (m.tiles[m.map[0].getMap()[i, j]].size.Y)))))
                    {
                        if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Impassable)
                        {
                            if (((p.spr.pos.Y + 49) >= ((m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y)))) && ((p.spr.pos.Y + 42) <= ((m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y)))))
                            {
                                p.spr.pos.Y = m.y + ((i) * m.tiles[m.map[0].getMap()[i, j]].size.Y) - 49;
                                p.spr.direcao.Y = 0;

                                if ((p.spr.pos.X > 0) && (p.spr.pos.X < 800))
                                    p.gravidade = 1;
                                else
                                {
                                    p.gravidade = 0;
                                }
                            }
                        }

                    }

                }
            }
        }
        

        base.Update(gameTime);
    }

    private bool Colidiu(Vector2 min, Vector2 max)
    {
        float left, right, top, bottom;
        float left2, right2, top2, bottom2;

        left = (p.spr.pos.X) + 10;
        right = p.spr.pos.X + 45;

        top = p.spr.pos.Y;
        bottom = p.spr.pos.Y + 49;

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
