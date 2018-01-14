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

    class ColisaoEsquerdaMonstro : Base
    {
        Mapa m;
        MonstroAnimado p;
        Personagem per;


        public ColisaoEsquerdaMonstro(Game jogo, Mapa m, MonstroAnimado p, Personagem per)
            : base(jogo)
        {
        this.m = m;
        this.p = p;
        this.per = per;
       
        }


    public override void Update(GameTime gameTime)
    {
        if (p.spr.direcao.X != 0)
        {
            if (( per.sprite_animado.pos.X + 40 >= p.spr.pos.X ) && ( per.sprite_animado.pos.X + 20 <= p.spr.pos.X ))
            {
                if ((p.spr.pos.Y >= per.sprite_animado.pos.Y - 20) && (p.spr.pos.Y <= per.sprite_animado.pos.Y + 40))
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

            for (int i = 0; i < m.map[0].getMap().GetLength(0); i++)
            {
                for (int j = (int)Camera.posizao; j < Camera.fracao_mapa; j++)
                {
                    if (Colidiu(new Vector2((m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X) + (m.tiles[m.map[0].getMap()[i, j]].size.X)),
                        (m.y + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y))),
                        new Vector2(((m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X)) + (m.tiles[m.map[0].getMap()[i, j]].size.X)),
                        ((m.y - 1 + (i * m.tiles[m.map[0].getMap()[i, j]].size.Y)) + (m.tiles[m.map[0].getMap()[i, j]].size.Y)))))
                    {
                        if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Impassable)
                        {

                            if (((p.spr.pos.X) <= (m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X) + m.tiles[m.map[0].getMap()[i, j]].size.X)) && ((p.spr.pos.X)) >= (m.x + (j * m.tiles[m.map[0].getMap()[i, j]].size.X + m.tiles[m.map[0].getMap()[i, j]].size.X - 10)))
                            {
                                p.spr.direcao.X = 1;

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
        float left, top, bottom,right;
        float left2, right2, top2, bottom2;

        left = (p.spr.pos.X);

        top = p.spr.pos.Y;
        bottom = p.spr.pos.Y + 47;

        left2 = min.X;           

        right2 = max.X;     

        top2 = min.Y;

        right = p.spr.pos.X + 46;

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
