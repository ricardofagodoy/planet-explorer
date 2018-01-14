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

public class SpriteAnimadoMonstro : Sprite
{
    public Vector2 FrameCoordinates { get; set; }
    public Vector2 FrameSize { get; set; }

    int CurrentFrame;
    public int msPerFrame;
    int TimeSinceLastUpdate;
    public float speed;

    public Vector2 direcao;


    public SpriteAnimadoMonstro(Texture2D textura, Vector2 pos, float speed, Vector2 frameSize, int msPerFrame)
        : base(textura, pos, speed)
    {
        CurrentFrame = 0;
        FrameSize = frameSize;
        this.msPerFrame = msPerFrame;
        direcao.X = -1;
        direcao.Y = 1;
        this.speed = speed;
    }

    public void Update(GameTime gameTime)
    {     
            TimeSinceLastUpdate += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastUpdate > msPerFrame)
            {
                TimeSinceLastUpdate -= msPerFrame;
                    if (CurrentFrame == FrameCoordinates.X)
                    {
                    if (direcao.X == 0)
                    pos.Y = 1000;
                        CurrentFrame = 0;
                    }
                    else
                    CurrentFrame++;
            }

            if (Camera.atualiza)
            {
                pos.X += Camera.Cam.X;
            }
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(textura, pos, new Rectangle((int)(CurrentFrame * FrameSize.X), (int)(FrameCoordinates.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y), Color.White, 0, new Vector2(0, 0), 1, 0, 0);
        spriteBatch.End();
    }


}
