using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens
{
    public class LoginScreen : IScreen
    {
        private readonly Game _game;
        private readonly ScreenManager _screen;
        private TextBox[] _textBox = new TextBox[2];
        private Button[] _buttons;
        private static readonly string[] BtnName = { "Back", "Login"};

        public LoginScreen(Game game, ScreenManager screen)
        {
            _game = game;
            _screen = screen;

            Initialize(game.Content);
        }

        public void Initialize(ContentManager content)
        {
            var font = content.Load<SpriteFont>("CourierNew");
            var textBoxImg = content.Load<Texture2D>("Button");

            for (var i = 0; i < _textBox.Length; i++)
            {
                _textBox[i] = new TextBox(textBoxImg, new Rectangle(10, i * 30 + 10, 250, 20), font,Color.Black);
            }

            _buttons = new Button[BtnName.Length];

            for (var i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = new Button(new Rectangle(100 * i + 10, _textBox.Length * 30 + 10, 80, 20), textBoxImg, font, BtnName[i]);
            }

            _buttons[0].OnClickEvent += MainMenu;
            _buttons[1].OnClickEvent += Play;

            foreach(var t in _textBox)
            {
                t.OnClickEvent += Focus;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var txtBox in _textBox)
            {
                txtBox.Update(gameTime);
            }

            foreach (var btn in _buttons)
            {
                btn.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var txtBox in _textBox)
            {
                txtBox.Draw(spriteBatch);
            }

            foreach (var btn in _buttons)
            {
                btn.Draw(spriteBatch);
            }
        }

        private void MainMenu()
        {
            _screen.SwapScreen(new MainMenu(_game, _screen));
        }

        private void Play()
        {
            _screen.SwapScreen(new GameScreen(_game, _screen));
        }

        private void Focus()
        {
            foreach (var txtBox in _textBox)
            {
                txtBox.HasFocus = false;
            }
        }
    }
}
