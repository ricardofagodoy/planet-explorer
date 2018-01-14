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

    public class Pause : Base
    {
    SpriteFont fonte;
    Texture2D pausegame;
    Texture2D cursorpause;
    float y;
    double tempo;

    public Pause(Game jogo) : base(jogo)
    {
        fonte = jogo.Content.Load<SpriteFont>(@"fontes\basica");
        pausegame = jogo.Content.Load<Texture2D>(@"imagens\pausegame");
        cursorpause = jogo.Content.Load<Texture2D>(@"imagens\cursorpause");
        tempo = 0;
        y = 252;
    }

    public override void Update(GameTime gameTime)
    {
        if (Camera.pause)
        {
            tempo += gameTime.ElapsedGameTime.TotalSeconds;

            if (tempo > 0.25)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    y += 29;
                    if (y > 310) y = 252;

                    tempo = 0;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                  y -= 29;
                   if (y < 252) y = 310;

                   tempo = 0;

                }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    switch ((int)y)
                    {
                        case 252: 
                            Camera.pause = false;
                            jogo.Components.Remove(this);
                            break;
                        case 281:
                            TextWriter tw = new StreamWriter("nocab32.DLL");
                            tw.Write(Camera.fase);
                            tw.Close();
                            Camera.pause = false;
                            jogo.Components.Remove(this);
                            break;
                        case 310:
                            MediaPlayer.Pause();
                            Camera.estadomenu = true;
                            jogo.Components.Remove(this);
                            break;
                    }

                    
                }

                
        }

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        sprite.Begin();

        if (Camera.pause)
        {
            sprite.Draw(pausegame, new Vector2(250, 200), Color.White);
            sprite.Draw(cursorpause, new Vector2(260, y), Color.White);
        }
        
        sprite.End();

        base.Draw(gameTime);
    }
    }

