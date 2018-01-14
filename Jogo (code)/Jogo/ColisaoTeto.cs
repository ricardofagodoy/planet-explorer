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

public class ColisaoTeto : Base
{
    public Mapa m;
    public Personagem p;

    public ColisaoTeto(Game jogo, Personagem p, Mapa m)
        : base(jogo)
    {
        this.m = m;
        this.p = p;
    }

    public override void Update(GameTime gameTime)
    {

            for (int i = 0; i < m.map[0].getMap().GetLength(0); i++)
            {
                for (int j = 0; j < m.map[0].getMap().GetLength(1); j++)
                {
                    if (Colidiu(new Vector2((m.x + (j * 25) + 1.001f),
                                        (((m.y + (i * 25) + 10)))),
                                        new Vector2(((m.x + (j * 25)) + 25 - 0.001f),
                                        ((m.y + (i * 25)) + 25))))
                    {
                        if (m.tiles[m.map[0].getMap()[i, j]].collision == TileCollision.Impassable)
                        {
                            if (((p.sprite_animado.pos.Y) <= ((m.y + ((i) * 25) + 25))) && ((p.sprite_animado.pos.Y) >= ((m.y + ((i) * 25) + 12))))
                            {
                                Camera.podepular = 0;
                                Camera.jumpTime = 2f;
                            }
                        }
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
