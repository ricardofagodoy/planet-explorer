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

    public class Monstro : Base
    {
        public Sprite spr { get; set; }
        public int vida;


        public Monstro(Game jogo, Sprite spr, int vida) : base(jogo)
        {
            this.spr = spr;
            this.vida = vida;
        }

        protected void movimento()
        {

        }

        public override void Update(GameTime gameTime)
        {
            this.movimento();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spr.Draw(sprite);
        }


    }
