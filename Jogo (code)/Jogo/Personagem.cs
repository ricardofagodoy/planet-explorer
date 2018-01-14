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

    public class Personagem : Base
    {
        public SpriteAnimado sprite_animado {get;set;}
        Sprite morre;
        private int inc;
        public int Vida { get; set; }
       public double tempo, tempo_armadura;
       public int x;


        public Personagem(Game jogo, SpriteAnimado sprite, int vida) : base(jogo)
        {
            inc = 0;
            this.Vida = vida;
            sprite_animado = sprite;
            morre = new Sprite(jogo.Content.Load<Texture2D>(@"imagens\morrendo"), sprite_animado.pos, 1);
            tempo = 0;
            tempo_armadura = 10;
            x = 1;
        }

        public override void Update(GameTime gameTime)
        {
            sprite_animado.Movendo = false;
            Camera.direcao.X = 0;

            if (Camera.morreu == true)
            {

                Camera.atualiza = false;

                for (int i = 0; i < 15; i++)
                {
                    tempo += gameTime.ElapsedGameTime.TotalSeconds;

                    if (tempo > 0.2)
                    {
                        if (inc < 20)
                            morre.pos.Y -= 5;
                        else
                            morre.pos.Y += 5;

                        inc++;
                        tempo = 0;
                    }

                }


            }
            else
            {
                morre.pos = sprite_animado.pos;

                if (!Camera.nasce)
                {
                    sprite_animado.Movendo = true;
                    sprite_animado.FrameCoordinates = new Vector2(5, 0);
                }

                if ((Camera.moveu) && (!Camera.armadura))
                    this.sprite_animado.textura = (jogo.Content.Load<Texture2D>(@"imagens\spriteprincipal"));

                if (Camera.armadura)
                {
                    tempo_armadura -= gameTime.ElapsedGameTime.TotalSeconds;

                    if (tempo_armadura <= 4)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipal");
                    if (tempo_armadura <= 3.5)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipalarmadura");
                    if (tempo_armadura <= 3)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipal");
                    if (tempo_armadura <= 2.5)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipalarmadura");
                    if (tempo_armadura <= 2)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipal");
                    if (tempo_armadura <= 1.5)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipalarmadura");
                    if (tempo_armadura <= 1)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipal");
                    if (tempo_armadura <= 0.5)
                        sprite_animado.textura = jogo.Content.Load<Texture2D>(@"imagens\spriteprincipalarmadura"); 
                    if (tempo_armadura <= 0)
                        Camera.armadura = false;
                    
                }


                if ((Keyboard.GetState().IsKeyDown(Keys.P) || (Keyboard.GetState().IsKeyDown(Keys.Escape)) && (Camera.pause == false)))
                {
                    Camera.pause = true;
                    Pause p = new Pause(jogo);
                    jogo.Components.Add(p);
                }

                if ((Camera.moveu) && (!Camera.pause) && (!Camera.foguete))
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        x = -1;
                            sprite_animado.FrameCoordinates = new Vector2(8, 1);
                        sprite_animado.Movendo = true;
                        Camera.Cam.X = sprite_animado.Speed;
                        Camera.direcao.X = -1;
                    }


                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        x = 1;
                            sprite_animado.FrameCoordinates = new Vector2(8, 0);
                        sprite_animado.Movendo = true;
                        Camera.Cam.X = -sprite_animado.Speed;
                        Camera.direcao.X = 1;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Up) || (Camera.direcao.Y == 1))
                    {
                            if (x == 1)
                            sprite_animado.FrameCoordinates = new Vector2(8, 3);
                            if (x == -1)
                                sprite_animado.FrameCoordinates = new Vector2(8, 2);

                            sprite_animado.Movendo = true;
                            Camera.atualiza = false;
                    }


                }
                    sprite_animado.Update(gameTime);
                    base.Update(gameTime);

                }
            }

        public override void Draw(GameTime gameTime)
        {

            if (Camera.morreu == true)
                morre.Draw(sprite);            

                this.sprite_animado.Draw(sprite);
                base.Draw(gameTime);
            
        }


    }
