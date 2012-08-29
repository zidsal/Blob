using System;
using Game.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens
{
    public class GameScreen : IScreen
    {
        private readonly Player _player = new Player("zidsal", 0, Vector2.One);

        public GameScreen(ContentManager content)
        {
            Initialize(content);
        }

        public void Initialize(ContentManager content)
        {
            _player.Initialize(content); 
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
        }
    }
}
