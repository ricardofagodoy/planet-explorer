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
using System.Threading;

public class Pular : Base
{
    Personagem p;
    Mapa m;
   // Song pulo;
    double tempo;


    public Pular(Game jogo, Personagem p, Mapa m)
        : base(jogo)
    {
        this.p = p;
        this.m = m;
        Camera.jumpTime = 0;
        tempo = 0;
     //   pulo = jogo.Content.Load<Song>(@"sons\pulo");
    }

    public override void Update(GameTime gameTime)
    {
        tempo += gameTime.ElapsedGameTime.TotalSeconds;
        if (((Keyboard.GetState().IsKeyDown(Keys.Up)) || (Keyboard.GetState().IsKeyDown(Keys.LeftControl))) && (!Camera.pause))
        {
            if (tempo > 2)
            {
                if ((Camera.moveu) && (!Camera.pause) && (!Camera.foguete) && (!Camera.nasce))
                {
                    
                    if (Camera.direcao.X == -1)
                        p.sprite_animado.FrameCoordinates = new Vector2(8, 2);
                    if (Camera.direcao.X == 1)
                        p.sprite_animado.FrameCoordinates = new Vector2(8, 3);
                    if (Camera.direcao.X == 0)
                        p.sprite_animado.FrameCoordinates = new Vector2(8, 3);

                }
                }
                tempo = 0;

                Camera.jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                p.sprite_animado.Pulando = true;
                    if (Camera.jumpTime <= 0.1f)
                    {
                        for (int c = 0; c < 63; c++)
                        {
                            p.sprite_animado.pos.Y -= 0.3f * Camera.podepular;
                            p.sprite_animado.Movendo = true;

                           // MediaPlayer.Play(pulo);

                        }
                    }

                    if (Camera.ground)
                    {
                        Camera.jumpTime = 0;
                        Camera.ground = false;
                    }

                    
        }

                base.Update(gameTime);
            
       
    }
}

            
