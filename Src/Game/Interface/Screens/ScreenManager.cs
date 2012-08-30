using Microsoft.Xna.Framework.Content;

namespace Game.Interface.Screens
{
    public class ScreenManager
    {
        private static ScreenManager _screenInstance;
        private IScreen _screen;

        private ScreenManager(Game game)
        {
            _screen = new MainMenu(game, this);
        }

        public void SwapScreen(IScreen screen)
        {
            _screen = screen;
        }

        public IScreen GetScreen()
        {
            return _screen;
        }

        public static ScreenManager Instance(Game game)
        {
            return _screenInstance ?? (_screenInstance = new ScreenManager(game));
        }
    }
}
