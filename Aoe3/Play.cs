using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aoe3
{
    class Play : AScene
    {
        public Map map { get; private set; } = new Map();
        public override void Load(GraphicsDeviceManager graphics, ContentManager Content)
        {
           // if (!UnitsTextures.IsLoaded) UnitsTextures.Load(Content);

           

            map.maptiles = Content.Load<Texture2D>("groundcells");
            //map.buildingtiles = Content.Load<Texture2D>("Textures/Game/buildingtiles");

            

            


            
        }

        enum TextureSPlay
        {
            cur,
            Interface,
            Pixel,
            Menu,
            ProfileEmpty,
            Frame,
            Health,
            Resourses,
            BtnAttack,
            BtnWalk
        }
        private Scenes CheckPress() 
        {
            return 0;
        }

        public override Scenes Update(GameTime gameTime)
        {
            map.Update(gameTime);
            //CheckMapMove();
            //CheckFocusMove();
            return CheckPress();
        }

        public override void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            SpriteBatch _spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            _spriteBatch.Begin();

            map.DrawMain(_spriteBatch, components[(int)TextureSPlay.Pixel]);
        }
        }

}
