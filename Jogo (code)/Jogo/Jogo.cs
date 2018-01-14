using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

public class jogo : Game
{
    GraphicsDeviceManager graficos;
    SpriteBatch sprite;
    // Simples menu
    Texture2D fundo, cursor, opcoes, onn, off, onnoff, onnoff2,cursoropcoes, Stage, ajuda, ajuda2, ajudas, afr, info,h1,h2,h3,f;
    SpriteFont fonte;
    State Estado;
    Song b, fase, fase2, fase3;
    double y2, y, tempo,tempo2;
    bool jafez = false;
    carrega_fase carrega;

    int parte_hist = 1;


    // Construtor
    public jogo()
    {
        graficos = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        y = 227; tempo = 0.0;
        Estado = State.AFR;
    }


    protected override void Initialize()
    {
        Window.Title = "AFR - Planet Explorer";

        sprite = new SpriteBatch(GraphicsDevice);
        Services.AddService(typeof(SpriteBatch), sprite);
        carrega = new carrega_fase(this);

        base.Initialize();
    }
    protected override void LoadContent()
    {
        fundo = Content.Load<Texture2D>(@"imagens\menu");
        cursor = Content.Load<Texture2D>(@"imagens\cursor");
        fonte = Content.Load<SpriteFont>(@"fontes\basica");
        opcoes = Content.Load<Texture2D>(@"imagens\opcoes");
        cursoropcoes = Content.Load<Texture2D>(@"imagens\cursoropcoes");
        ajuda = Content.Load<Texture2D>(@"imagens\ajuda");
        ajuda2 = Content.Load<Texture2D>(@"imagens\ajuda2");
        onn = Content.Load<Texture2D>(@"imagens\onn");
        off = Content.Load<Texture2D>(@"imagens\off");
        afr = Content.Load<Texture2D>(@"imagens\afr");
        info = Content.Load<Texture2D>(@"imagens\infoPlanetExplorer");
        ajudas = ajuda;
        b = Content.Load<Song>(@"sons\b");
        fase = Content.Load<Song>(@"sons\fase");
        fase2 = Content.Load<Song>(@"sons\fase2");
        fase3 = Content.Load<Song>(@"sons\fase3");
        onnoff = off;
        onnoff2 = onn;
        Stage = Content.Load<Texture2D>(@"imagens\Stage");
        h1 = Content.Load<Texture2D>(@"imagens\h1");
        h2 = Content.Load<Texture2D>(@"imagens\h2");
        h3 = Content.Load<Texture2D>(@"imagens\h3");
        f = Content.Load<Texture2D>(@"imagens\venceu");
        y = 210;
        y2 = 227;
        tempo = 0;

    }

    protected override void UnloadContent()
    { }

    public void setGraficos()
    {
        graficos.ToggleFullScreen();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();

        switch (Estado)
        {

            case State.AFR:
              tempo += gameTime.ElapsedGameTime.TotalSeconds;

              if (tempo > 2.2)
              {
                  tempo = 0;
                  Estado = State.info;
              }
              break;

            case State.info:
              tempo += gameTime.ElapsedGameTime.TotalSeconds;

              if (tempo > 3)
              {
                      tempo = 0;
                      Estado = State.Menu;

                      if (MediaPlayer.State == MediaState.Stopped)
                      { 
                          MediaPlayer.Play(b);
                          MediaPlayer.Pause(); 
                      }
                      
              }
              break;

            case State.Menu:
              if (MediaPlayer.State == MediaState.Paused)
                  MediaPlayer.Play(b); 

                tempo += gameTime.ElapsedGameTime.TotalSeconds;

                if (tempo > 0.25)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        y2 += 45;
                        if (y2 > 407) y2 = 227;

                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        y2 -= 45;
                        if (y2 < 227) y2 = 407;

                    }

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {

                            switch ((int)y2)
                            {
                                case 227: Camera.fase = 0; carrega = new carrega_fase(this); Estado = State.Hist; MediaPlayer.Stop(); break;
                                case 272: Estado = State.Carregar; MediaPlayer.Stop(); break;
                                case 317: Estado = State.Opcoes; break;
                                case 362: Estado = State.Ajuda; break;
                                case 407: Estado = State.Sair; break;
                            }

                        }
                    

                    tempo = 0;
                }
                break;


            case State.Hist:

                 tempo += gameTime.ElapsedGameTime.TotalSeconds;

                 if (parte_hist > 3)
                 {
                     Estado = State.Jogo;
                     tempo = 0;
                 }
                 if (tempo > 0.5)
                 {
                     if (Keyboard.GetState().IsKeyDown(Keys.Enter) ||(Keyboard.GetState().IsKeyDown(Keys.Right)))
                     {
                         parte_hist += 1;
                         tempo = 0;
                     }
                 }

                if (parte_hist == 2)
                {
                    if (tempo > 0.5)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) || (Keyboard.GetState().IsKeyDown(Keys.Right)))
                            parte_hist = 3;
                            tempo = 0;
                    }
               }

                if (parte_hist == 3)
                {
                    if (tempo > 0.5)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) || (Keyboard.GetState().IsKeyDown(Keys.Right)))
                        {
                            Estado = State.Jogo;
                            tempo = 0;
                        }
                    }
                }


            break;

            case State.Fim:
            carrega.refaz();
            Camera.grav = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                Estado = State.Menu;

            break;

            case State.Nada:

            if (Camera.fimdejogo)
                Estado = State.Fim;

                if (Camera.estadomenu)
                {
                    Camera.fimdejogo = false;
                    Camera.armadura = false;
                    Camera.grav = true;
                    carrega.refaz();
                    Camera.nasce = true;
                    Camera.moveu = false;
                    Camera.morreu = false;
                    Camera.Speed = 1;
                    Camera.fracao_mapa = 835 / 25 + 7;
                    Camera.posizao = 7;
                    Camera.Cam.X = 0;
                    Camera.estadomenu = false;
                    Camera.pause = false;
                    Camera.vida = 5;
                    Camera.mapa_checkpoint = -175;
                    Camera.pontos = 0;
                    Camera.moedas = 0;
                    carrega = new carrega_fase(this);
                    Estado = State.Menu;
                }

                if (Camera.passadefase)
                {
                    MediaPlayer.Stop();
                    if (jafez == false)
                    {
                        Camera.grav = true;
                        carrega.refaz();
                        jafez = true;
                    }

                    tempo2 += gameTime.ElapsedGameTime.TotalSeconds;
                    if (tempo2 > 3)
                    {
                        tempo2 = 0;
                        Camera.stagemsg = false;
                        carrega = new carrega_fase(this);
                        carrega.carrega();
                        Camera.nasce = true;
                        Camera.moveu = false;
                        Camera.morreu = false;
                        Camera.Speed = 1;
                        Camera.passadefase = false;

                        if (Camera.mapa_checkpoint == -175)
                        {
                            Camera.fracao_mapa = 835 / 25 + 7;
                            Camera.posizao = 7;
                        }
                        else
                        {
                            Camera.fracao_mapa = Camera.fracao_mapa_checkpoint;
                            Camera.posizao = Camera.posizao_checkpoint;
                        }
                        jafez = false;
                    }
                }

                if (Camera.refaz)
                {
                    Camera.grav = true;
                        carrega.refaz();
                        carrega = new carrega_fase(this);
                        carrega.carrega();
                        Camera.nasce = true;
                        Camera.moveu = false;
                        Camera.morreu = false;
                        Camera.Speed = 1;
                        
                        Camera.refaz = false;

                        if (Camera.mapa_checkpoint == -175)
                        {
                            Camera.fracao_mapa = 835 / 25 + 7;
                            Camera.posizao = 7;
                        }
                        else
                        {
                            Camera.fracao_mapa = Camera.fracao_mapa_checkpoint;
                            Camera.posizao = Camera.posizao_checkpoint;
                        }
                    }
                break;

            case State.Jogo:
                
                if (!Camera.mudo)
                {
                    MediaPlayer.Stop();

                        if (Camera.fase == 0)
                        {
                            if (MediaPlayer.State == MediaState.Stopped) {MediaPlayer.Play(fase); }      
                        }

                        if (Camera.fase == 1)
                        {
                            if (MediaPlayer.State == MediaState.Stopped) {MediaPlayer.Play(fase2); }
                            
                        }

                        if (Camera.fase == 2)
                        {
                            if (MediaPlayer.State == MediaState.Stopped) { MediaPlayer.Play(fase3); }
                        }
                        if (Camera.fase == 3)
                        {
                            if (MediaPlayer.State == MediaState.Stopped) { MediaPlayer.Play(fase); }   
                        }


                }
                
                tempo2 += gameTime.ElapsedGameTime.TotalSeconds;             
                Camera.stagemsg = true;

                if (tempo2 > 3)
                {
                    tempo2 = 0;
                    Camera.stagemsg = false;
                    carrega.carrega();
                    Estado = State.Nada;
                }

                break;

            case State.Carregar:
                TextReader tr = new StreamReader("nocab32.DLL");
                Camera.fase = Convert.ToInt32(tr.ReadLine());
                tr.Close();
                carrega = new carrega_fase(this);
                Estado = State.Jogo;
                break;

            case State.Opcoes:

                tempo += gameTime.ElapsedGameTime.TotalSeconds;

                if (tempo > 0.15)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        y += 100;
                        if (y > 410)
                            y = 210;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        y -= 100;
                        if (y < 210)
                            y = 410;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {

                        if (y == 210)
                        {
                            graficos.ToggleFullScreen();
                            if (onnoff == onn)
                                onnoff = off;
                            else
                                onnoff = onn;
                        }
                        if (y == 310)
                        {
                            if (onnoff2 == onn)
                            {
                                onnoff2 = off;
                                Camera.mudo = true;
                                MediaPlayer.Stop();
                            }

                            else
                            {
                                onnoff2 = onn;
                                MediaPlayer.Resume();
                                Camera.mudo = false;
                            }
                        }
                     
                        if (y == 410)
                        {
                            Estado = State.Menu;
                        }
                    }

                    tempo = 0;
                }


                break;

            case State.Ajuda:

                tempo += gameTime.ElapsedGameTime.TotalSeconds;

                if (tempo > 0.3)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        ajudas = ajuda2;

                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        ajudas = ajuda;

                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        Estado = State.Menu;

                    tempo = 0;
                }
                break;

            case State.Sair:
                this.Exit();
                break;
        }

        base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        if (Estado == State.AFR)
        {
            sprite.Begin();
            sprite.Draw(afr, Vector2.Zero, Color.White);
            sprite.End();
        }

        if (Estado == State.info)
        {
            sprite.Begin();
            sprite.Draw(info, Vector2.Zero, Color.White);
            sprite.End();
        }

        if (Estado == State.Menu)
        {
            sprite.Begin();
            sprite.Draw(fundo, Vector2.Zero, Color.White);
            sprite.Draw(cursor, new Vector2(220, (float)y2), Color.White);
            sprite.End();
        }

        if (Estado == State.Opcoes)
        {

            sprite.Begin();
            sprite.Draw(opcoes, Vector2.Zero, Color.White);
            sprite.Draw(cursoropcoes, new Vector2(12, (float)y), Color.White);
            sprite.Draw(onnoff, new Vector2(600, 220), Color.White);
            sprite.Draw(onnoff2, new Vector2(600, 337), Color.White);
            sprite.End();
        }

        if (Estado == State.Ajuda)
        {

            sprite.Begin();
            sprite.Draw(ajudas, Vector2.Zero, Color.White);
            sprite.End();
        }

        if (Camera.stagemsg)
        {
            sprite.Begin();
            sprite.Draw(Stage, Vector2.Zero, Color.White);
            if (Camera.fase == 3)
            sprite.DrawString(fonte, "              Final", new Vector2(300, 300), Color.White);
            else
                sprite.DrawString(fonte, "             x " + (Camera.fase + 1) + "", new Vector2(300, 300), Color.White);
            sprite.End();
        }

        if (Estado == State.Hist)
        {
            sprite.Begin();
            if (parte_hist == 1)
              sprite.Draw(h1, Vector2.Zero, Color.White);
            if (parte_hist == 2)
                sprite.Draw(h2, Vector2.Zero, Color.White);
            if (parte_hist == 3)
                sprite.Draw(h3, Vector2.Zero, Color.White);
            sprite.End();
        }

        if (Estado == State.Fim)
       {
            sprite.Begin();      
            sprite.Draw(f, Vector2.Zero, Color.White);
            sprite.End();
        }

        base.Draw(gameTime);
    }
}