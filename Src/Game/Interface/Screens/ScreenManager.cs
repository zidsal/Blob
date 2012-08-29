using Microsoft.Xna.Framework.Content;

namespace Game.Interface.Screens
{
    public class ScreenManager
    {
        private static ScreenManager _screenInstance;
        private IScreen _screen;

        private ScreenManager(ContentManager content)
        {
            _screen = new MainMenu(content);
        }

        public void SwapScreen(IScreen screen)
        {
            _screen = screen;
        }

        public IScreen GetScreen()
        {
            return _screen;
        }

        public static ScreenManager Instance(ContentManager content)
        {
            return _screenInstance ?? (_screenInstance = new ScreenManager(content));
        }
    }
}
