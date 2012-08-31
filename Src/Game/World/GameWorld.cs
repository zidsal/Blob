using Game.Entities;
using Game.World.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.World
{
   public class GameWorld
    {
        private readonly Player _player = new Player("zidsal", 0, Vector2.One);

        public void Initialize(ContentManager content)
        {
            _player.Initialize(content);
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
        }
    }
}
