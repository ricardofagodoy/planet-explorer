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

class carrega_fase : Base
{
    List<MonstroAnimado> monstros;
    List<ColisaoChaoMonstro> Colisao_Chao_Monstro;
    List<ColisaoDireitaMonstro> Colisao_Direita_Monstro;
    List<ColisaoEsquerdaMonstro> Colisao_Esquerda_Monstro;


    Personagem Heroi;
    Mapa Mapa;
    Fundo Fundo;
    Gravidade Gravidade;
    ColisaoChao Colisao_Chao;
    ColisaoTeto Colisao_Teto;
    ColisaoEsquerda Colisao_Esquerda;
    ColisaoDireita Colisao_Direita;
    Pular pu;

    ExibeVida Exibe_Vida;
    ExibePontos Exibe_Pontos;

    Foguete fog;

    public carrega_fase(Game jogo)
        : base(jogo)
    {
        Heroi = new Personagem(jogo, new SpriteAnimado(jogo.Content.Load<Texture2D>(@"imagens\nascendo"),
                new Vector2(400, 100), 5, new Vector2(45, 50), 100), Camera.vida);



        Fundo = new Fundo(jogo, jogo.Content.Load<Texture2D>(@"imagens\background"), 0);

        if (Camera.fase == 2)
        {
            fog = new Foguete(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\nave"),
          new Vector2(8750 + Camera.mapa_checkpoint, 318), 1, new Vector2(136, 150), 250));

            Mapa = new Mapa(jogo);

            monstros = new List<MonstroAnimado>();

            // supercomeço

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(1390 + Camera.mapa_checkpoint, 450), 4, new Vector2(55, 50), 250), 1, 1, 300));       

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(1700 + Camera.mapa_checkpoint, 450), 2, new Vector2(55, 50), 250), 1, 1, 200));

            // fimsupercomeco

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
           new Vector2(2400 + Camera.mapa_checkpoint, 450), 2, new Vector2(55, 50), 250), 1, 1, 180));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
           new Vector2(3590 + Camera.mapa_checkpoint, 450), 9, new Vector2(55, 50), 250), 1, 0, 180));

            // ponte
          
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
           new Vector2(3800 + Camera.mapa_checkpoint, 450), 2, new Vector2(55, 50), 250), 1, 1, 10));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
           new Vector2(3900 + Camera.mapa_checkpoint, 450), 2, new Vector2(55, 50), 250), 1, 1, 10));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
           new Vector2(4000 + Camera.mapa_checkpoint, 450), 2, new Vector2(55, 50), 250), 1, 1, 10));

            // resto

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
          new Vector2(5750 + Camera.mapa_checkpoint, 150), 50, new Vector2(55, 50), 250), 1, 1, 85));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
          new Vector2(5950 + Camera.mapa_checkpoint, 350), 4, new Vector2(55, 50), 250), 1, 1, 50));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
          new Vector2(7500 + Camera.mapa_checkpoint, 450), 4, new Vector2(55, 50), 250), 1, 1, 100));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
new Vector2(7600 + Camera.mapa_checkpoint, 450), 4, new Vector2(55, 50), 250), 1, 1, 100));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
new Vector2(7700 + Camera.mapa_checkpoint, 450), 4, new Vector2(55, 50), 250), 1, 1, 100));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
new Vector2(7800 + Camera.mapa_checkpoint, 450), 4, new Vector2(55, 50), 250), 1, 1, 100));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
new Vector2(8650 + Camera.mapa_checkpoint, 450), 17, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
new Vector2(8500 + Camera.mapa_checkpoint, 450), 17, new Vector2(55, 50), 250), 1, 0, 0));



            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
new Vector2(8350 + Camera.mapa_checkpoint, 50), 10, new Vector2(55, 50), 250), 1, 2, 50));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
new Vector2(8400 + Camera.mapa_checkpoint, 50), 10, new Vector2(55, 50), 250), 1, 2, 50));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
new Vector2(8500 + Camera.mapa_checkpoint, 50), 10, new Vector2(55, 50), 250), 1, 2, 50));


            Colisao_Chao_Monstro = new List<ColisaoChaoMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Chao_Monstro.Add(new ColisaoChaoMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Direita_Monstro = new List<ColisaoDireitaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Direita_Monstro.Add(new ColisaoDireitaMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Esquerda_Monstro = new List<ColisaoEsquerdaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Esquerda_Monstro.Add(new ColisaoEsquerdaMonstro(jogo, Mapa, monstros[i], Heroi));

            Gravidade = new Gravidade(jogo, Heroi, monstros);
        }

        if (Camera.fase == 3)
        {
            Mapa = new Mapa(jogo);
            monstros = new List<MonstroAnimado>();

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(1000, 280), 5, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(1200, 280), 5, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(1400, 80), 5, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(1600, 280), 5, new Vector2(55, 50), 250), 1, 0, 0));
            
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
   new Vector2(2000, 280), 5, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
   new Vector2(2100, 280), 5, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(1300, 80), 7, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(1500, 80), 8, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(1700, 280), 5, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
   new Vector2(1900, 280), 10, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
   new Vector2(2000, 280), 10, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
              new Vector2(1050, 280), 6, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(1250, 280), 50, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(1450, 80), 4, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(1650, 280), 16, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
   new Vector2(2050, 280), 7, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
   new Vector2(2150, 280), 1, new Vector2(55, 50), 250), 1, 0, 0));


            Colisao_Chao_Monstro = new List<ColisaoChaoMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Chao_Monstro.Add(new ColisaoChaoMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Direita_Monstro = new List<ColisaoDireitaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Direita_Monstro.Add(new ColisaoDireitaMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Esquerda_Monstro = new List<ColisaoEsquerdaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Esquerda_Monstro.Add(new ColisaoEsquerdaMonstro(jogo, Mapa, monstros[i], Heroi));

            Gravidade = new Gravidade(jogo, Heroi, monstros);
        }


        if (Camera.fase == 1)
        {
            fog = new Foguete(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\nave"),
          new Vector2(7650 + Camera.mapa_checkpoint, 318), 1, new Vector2(136, 150), 250));

            Mapa = new Mapa(jogo);

            monstros = new List<MonstroAnimado>();



            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(975 + Camera.mapa_checkpoint, 380), 1, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(1937 + Camera.mapa_checkpoint, 400), 2, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(2200 + Camera.mapa_checkpoint, 400), 2, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(2680 + Camera.mapa_checkpoint, 470), 1, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(3450 + Camera.mapa_checkpoint, 400), 8, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
              new Vector2(3700 + Camera.mapa_checkpoint, 305), 3, new Vector2(55, 50), 250), 1, 1, 90));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
              new Vector2(3900 + Camera.mapa_checkpoint, 305), 4, new Vector2(55, 50), 250), 1, 1, 90));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(4125 + Camera.mapa_checkpoint, 400), 3, new Vector2(55, 50), 250), 1, 1, 40));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(4400 + Camera.mapa_checkpoint, 420), 1, new Vector2(55, 50), 250), 1, 1, 50));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(4900 + Camera.mapa_checkpoint, 400), 14, new Vector2(55, 50), 250), 1, 0, 0));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(5812 + Camera.mapa_checkpoint, 500), 2, new Vector2(55, 50), 250), 1, 1, 100));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro1"),
               new Vector2(5900 + Camera.mapa_checkpoint, 490), 2, new Vector2(55, 50), 250), 1, 1, 100));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
               new Vector2(6625 + Camera.mapa_checkpoint, 400), 2, new Vector2(55, 50), 250), 1, 1, 130));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
              new Vector2(6625 + Camera.mapa_checkpoint, 400), 2, new Vector2(55, 50), 250), 1, 1, 130));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
             new Vector2(6625 + Camera.mapa_checkpoint, 400), 2, new Vector2(55, 50), 250), 1, 1, 130));

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro3"),
             new Vector2(6625 + Camera.mapa_checkpoint, 400), 2, new Vector2(55, 50), 250), 1, 1, 130));

            Colisao_Chao_Monstro = new List<ColisaoChaoMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Chao_Monstro.Add(new ColisaoChaoMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Direita_Monstro = new List<ColisaoDireitaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Direita_Monstro.Add(new ColisaoDireitaMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Esquerda_Monstro = new List<ColisaoEsquerdaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Esquerda_Monstro.Add(new ColisaoEsquerdaMonstro(jogo, Mapa, monstros[i], Heroi));


            Gravidade = new Gravidade(jogo, Heroi, monstros);
        }

        if (Camera.fase == 0)
        {
            fog = new Foguete(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\nave"),
          new Vector2(7650 + Camera.mapa_checkpoint, 318), 1, new Vector2(136, 150), 250));

            Mapa = new Mapa(jogo);

            monstros = new List<MonstroAnimado>();

            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(2800 + Camera.mapa_checkpoint, 440), 1, new Vector2(55, 50), 250), 1, 0, 0));
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(3180 + Camera.mapa_checkpoint, 420), 1, new Vector2(55, 50), 250), 1, 0, 0));
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
                  new Vector2(4950 + Camera.mapa_checkpoint, 420), 3, new Vector2(55, 50), 250), 1, 0, 0));
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(5800 + Camera.mapa_checkpoint, 390), 5, new Vector2(55, 50), 250), 1, 1, 150));
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
               new Vector2(6200 + Camera.mapa_checkpoint, 420), 5, new Vector2(55, 50), 250), 1, 0, 0));
            monstros.Add(new MonstroAnimado(jogo, new SpriteAnimadoMonstro(jogo.Content.Load<Texture2D>(@"imagens\monstro2"),
                    new Vector2(7250 + Camera.mapa_checkpoint, 420), 5, new Vector2(55, 50), 250), 1, 0, 0));


            Colisao_Chao_Monstro = new List<ColisaoChaoMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Chao_Monstro.Add(new ColisaoChaoMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Direita_Monstro = new List<ColisaoDireitaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Direita_Monstro.Add(new ColisaoDireitaMonstro(jogo, Mapa, monstros[i], Heroi));


            Colisao_Esquerda_Monstro = new List<ColisaoEsquerdaMonstro>();

            for (int i = 0; i < monstros.Count; i++)
                Colisao_Esquerda_Monstro.Add(new ColisaoEsquerdaMonstro(jogo, Mapa, monstros[i], Heroi));

            Gravidade = new Gravidade(jogo, Heroi, monstros);

        }

        Colisao_Chao = new ColisaoChao(jogo, Mapa, Heroi); 
        Colisao_Esquerda = new ColisaoEsquerda(jogo, Mapa, Heroi);
        Colisao_Direita = new ColisaoDireita(jogo, Mapa, Heroi);
        Colisao_Teto = new ColisaoTeto(jogo, Heroi, Mapa); 
        Exibe_Vida = new ExibeVida(jogo);
        Exibe_Pontos = new ExibePontos(jogo);
        pu = new Pular(jogo, Heroi, Mapa);
    }

    public void refaz()
    {
        jogo.Components.Remove(Colisao_Teto);
        jogo.Components.Remove(pu);
        jogo.Components.Remove(Fundo);
        jogo.Components.Remove(Mapa);
        jogo.Components.Remove(Heroi);
        jogo.Components.Remove(Colisao_Chao);
        jogo.Components.Remove(Colisao_Esquerda);
        jogo.Components.Remove(Colisao_Direita);
        jogo.Components.Remove(Gravidade);
        jogo.Components.Remove(Exibe_Vida);
        jogo.Components.Remove(Exibe_Pontos);
        jogo.Components.Remove(fog);

        for (int i = 0; i < monstros.Count; i++)
        {
            jogo.Components.Remove(monstros[i]);
            jogo.Components.Remove(Colisao_Chao_Monstro[i]);
            jogo.Components.Remove(Colisao_Direita_Monstro[i]);
            jogo.Components.Remove(Colisao_Esquerda_Monstro[i]);
        }
    }

    public void carrega()
    {
        jogo.Components.Add(Colisao_Teto);
            jogo.Components.Add(pu);
            jogo.Components.Add(Fundo);
            jogo.Components.Add(Mapa);
            jogo.Components.Add(fog);
            jogo.Components.Add(Heroi);
            jogo.Components.Add(Colisao_Chao);
            jogo.Components.Add(Colisao_Esquerda);
            jogo.Components.Add(Colisao_Direita);
            jogo.Components.Add(Gravidade);
            jogo.Components.Add(Exibe_Vida);
            jogo.Components.Add(Exibe_Pontos);


            Mapa.x = Camera.mapa_checkpoint;


            for (int i = 0; i < monstros.Count; i++)
            {
                jogo.Components.Add(monstros[i]);
                jogo.Components.Add(Colisao_Chao_Monstro[i]);
                jogo.Components.Add(Colisao_Direita_Monstro[i]);
                jogo.Components.Add(Colisao_Esquerda_Monstro[i]);
            }

    }

}



