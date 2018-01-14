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


    public static class Camera
    {
        public static float Speed = 1;
        public static Vector2 Cam = new Vector2(0,0);
        public static bool atualiza = false;
        public static Vector2 direcao = new Vector2(0,1);
        public static Vector2 direcao_monstro = new Vector2(0, 1);

        public static bool morreu = false;
        public static bool nasce = true;
        public static bool moveu = false;
        public static bool mudo = false;
        public static int fase = 0;
        public static int vida = 5;
        public static int pontos = 0;
        public static int moedas = 0;

        public static bool armadura = false;

        public static float jumpTime = 0;

        public static int podepular = 1;

        public static bool grav = true;

        public static float mapa_checkpoint = -175;
        public static float fracao_mapa_checkpoint = 0;
        public static float posizao_checkpoint = 0;

        public static bool refaz = false;
        public static bool passadefase = false;

        public static bool pause = false;
        public static bool ground = true;

        public static float fracao_mapa = 835 / 25 + 7 ;
        public static float posizao = 7;

        public static bool foguete = false;
        public static bool stagemsg = false;
        public static bool estadomenu = false;
        public static bool fimdejogo = false;
    }

