using Game.Interface.Screens.GameGui;
using Game.World;
using Game.World.Entities;
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

        //player menu gui control
        private InteractionMenu _blobMenu;
        private readonly string[] _blobMenuOptions = { "Inspect", "Cancel"};

        public GameScreen(Game game, ScreenManager screen)
        {
            _game = game;
            _screen = screen;
            Initialize(_game.Content);
        }

        public void Initialize(ContentManager content)
        {
            _world.Initialize(content);
            _blobMenu = new InteractionMenu(_blobMenuOptions, content);

            //give the heros there onclick interaction with the interactionMenu
            foreach(var blob in _world.GetBlobs())
            {
                blob.OnClickEvent += PlayerInteraction;
            }

            _blobMenu.OnClickEvent += MenuInteraction;
        }

        public void Update(GameTime gameTime)
        {
            _input.Update(Keyboard.GetState());
            _blobMenu.Update(gameTime);
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
            _blobMenu.Draw(spriteBatch);
        }

        private void PlayerInteraction(Skeleton skeleton)
        {
            if(_blobMenu.Visible)
            {
                _blobMenu.HideMenu();
            }
            else
            {
                _blobMenu.ShowMenu(skeleton.Location.X + 24, skeleton.Location.Y);
            }
        }

        private void MenuInteraction(InteractionMenuEventArgs e)
        {
            if (e.Option == _blobMenuOptions[3])
            {
                _blobMenu.HideMenu();
            }
        }
    }
}
