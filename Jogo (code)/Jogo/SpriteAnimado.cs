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

    public class SpriteAnimado : Sprite
    {
         public Vector2 FrameCoordinates { get; set; }
         public Vector2 FrameSize;

        int CurrentFrame;
        public int msPerFrame;
        int TimeSinceLastUpdate;

        public bool Movendo { get; set; }
        public bool Pulando { get; set; }
        public Vector2 Direcao;


        public SpriteAnimado(Texture2D textura, Vector2 pos, float speed,Vector2 frameSize, int msPerFrame) : base(textura,pos,speed)
        {
            FrameSize = frameSize;
            this.msPerFrame = msPerFrame;

            Movendo = false;
            Pulando = false;
            Direcao = new Vector2(1, 0);
        }

        public void Update(GameTime gameTime)
        {
          
            if (Movendo)
            {
                if (Camera.direcao.X != 0)
                Camera.atualiza = true;


                TimeSinceLastUpdate += gameTime.ElapsedGameTime.Milliseconds;

                if (TimeSinceLastUpdate > msPerFrame)
                {
                    TimeSinceLastUpdate -= msPerFrame;

                    if (CurrentFrame == FrameCoordinates.X)
                    {
                        if (!Camera.nasce)
                        {
                            Camera.moveu = true;
                            Camera.nasce = true;
                        }

                       CurrentFrame = 1;
                    }
                    else
                    CurrentFrame++;
                }
            }
            else
            {
                Camera.atualiza = false;
                CurrentFrame = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(textura,pos, new Rectangle((int)(CurrentFrame * FrameSize.X), (int)(FrameCoordinates.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y), Color.White, 0, new Vector2(0, 0), 1,0,0);
            spriteBatch.End();
        }


    }
