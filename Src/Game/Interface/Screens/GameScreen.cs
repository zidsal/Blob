using Game.Interface.Screens.GameGui;
using Game.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Interface.Screens
{
    public class GameScreen : IScreen
    {
        private readonly Game _game;
        private readonly ScreenManager _screen;
        private readonly InputManager _input = new InputManager();
        private readonly GameWorld _world = new GameWorld();
        private InteractionMenu _playerMenu;
        private readonly string[] _playerMenuOptions = {"Move", "Attack", "Info", "Cancel"};

        public GameScreen(Game game, ScreenManager screen)
        {
            _game = game;
            _screen = screen;
            Initialize(_game.Content);
        }

        public void Initialize(ContentManager content)
        {
            _world.Initialize(content);
            _playerMenu = new InteractionMenu(_playerMenuOptions, content);

            //give the heros there onclick interaction
            _world.GetPlayer().OnClickEvent += PlayerInteraction;
        }

        public void Update(GameTime gameTime)
        {
            _input.Update(Keyboard.GetState());
            _world.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _world.Draw(spriteBatch);
            DrawUi(spriteBatch);
        }

        private void Quit()
        {
            _screen.SwapScreen(new MainMenu(_game, _screen));
        }

        private void DrawUi(SpriteBatch spriteBatch)
        {
            _playerMenu.Draw(spriteBatch);
        }

        private void PlayerInteraction()
        {
            _playerMenu.Visible = true;
        }

    }
}
