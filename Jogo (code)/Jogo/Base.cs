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


public class Base : DrawableGameComponent
{
    protected Game jogo;
    protected SpriteBatch sprite;

    public Base(Game jogo)
        : base(jogo)
    {
        this.jogo = jogo;
        this.sprite = (SpriteBatch)jogo.Services.GetService(typeof(SpriteBatch));
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}
