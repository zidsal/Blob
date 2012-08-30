using Game.Entities;
using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens
{
    public class GameScreen : IScreen
    {
        private readonly Player _player = new Player("zidsal", 0, Vector2.One);
        private readonly Game _game;
        private readonly ScreenManager _screen;

        public GameScreen(Game game, ScreenManager screen)
        {
            _game = game;
            _screen = screen;
            Initialize(_game.Content);
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

        private void Quit()
        {
            _screen.SwapScreen(new MainMenu(_game, _screen));
        }
    }
}
