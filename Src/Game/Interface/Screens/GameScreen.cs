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
        private SpriteFont _uiFont;

        public GameScreen(Game game, ScreenManager screen)
        {
            _game = game;
            _screen = screen;
            Initialize(_game.Content);
        }

        public void Initialize(ContentManager content)
        {
            _uiFont = content.Load<SpriteFont>("CourierNew");
            _world.Initialize(content);
        }

        public void Update(GameTime gameTime)
        {
            _input.Update(Keyboard.GetState());
            _world.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _world.Draw(spriteBatch);
            spriteBatch.Begin();
                spriteBatch.DrawString(_uiFont,"Fps: ",new Vector2(GameData.ScreenSize.X - 50,5),Color.Black);
            spriteBatch.End();
        }

        private void Quit()
        {
            _screen.SwapScreen(new MainMenu(_game, _screen));
        }

        private void DrawUi()
        {
            
        }
    }
}
