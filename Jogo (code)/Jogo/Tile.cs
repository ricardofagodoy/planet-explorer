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

        public enum TileCollision
        {
            Passable,
            Impassable,
            Item
        };

        public class Tile
        {
            public Texture2D textura;
            public TileCollision collision;
            public readonly Vector2 size;

            public Tile(Texture2D texture, TileCollision collision)
            {
                this.textura = texture;
                this.collision = collision;
                this.size = new Vector2(this.textura.Width, this.textura.Height);
            }
        }
