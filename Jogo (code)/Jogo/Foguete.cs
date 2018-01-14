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

    public class Foguete : Base
    {

    SpriteAnimadoMonstro fog;
    double tempo;

    public Foguete(Game jogo, SpriteAnimadoMonstro fog) : base(jogo)
    {
        this.fog = fog;
        tempo = 0;

    }

    public override void Update(GameTime gameTime)
    {

        if (Camera.foguete)
        {
            tempo += gameTime.ElapsedGameTime.Milliseconds;

            if (tempo > 0.1)
            {
                fog.pos.Y -= 2f;
                tempo = 0;
                fog.FrameCoordinates = new Vector2(1, 1);
            }
        }

        if (fog.pos.Y < -400)
        {
            Camera.fracao_mapa = 835 / 25 + 7;
            Camera.posizao = 7;
            Camera.mapa_checkpoint = -175;
            Camera.moedas = 0;
            Camera.foguete = false;
            Camera.stagemsg = true;
            Camera.Cam.X = 0;
            Camera.fase++;

            Camera.passadefase = true;
        }

        fog.Update(gameTime);
        
    }

    public override void Draw(GameTime gameTime)
    {
        fog.Draw(sprite);
        base.Draw(gameTime);
    }

    }
