using System;
using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens
{
    public class MainMenu : IScreen
    {
        private Button[] _buttons;
        private static readonly string[] _btnName = {"Login", "Register", "Options", "Exit"};
        private readonly Game _game;
        private readonly ScreenManager _screen;

        private const int BtnWidth = 80;
        private const int BtnHeight = 50;
        private const int BtnSpacing = 20;
        private Vector2 _btnCenter = new Vector2(GameData.ScreenSize.X / 2 - ((BtnWidth * _btnName.Length/2) + (BtnSpacing * _btnName.Length/2) + BtnWidth + BtnSpacing), 
                                                    GameData.ScreenSize.Y / 2 - BtnHeight / 2);

        public MainMenu(Game game, ScreenManager screen)
        {
            _game = game;
            _screen = screen;
            Initialize(_game.Content);
        }

        public void Initialize(ContentManager content)
        {
            var font = content.Load<SpriteFont>("CourierNew");
            var buttonImg = content.Load<Texture2D>("Button");

            _buttons = new Button[_btnName.Length];

            for(int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = new Button(new Rectangle((int)_btnCenter.X + (i * BtnWidth) + (i * BtnSpacing), (int)_btnCenter.Y, 
                                          BtnWidth, BtnHeight), buttonImg, font, _btnName[i]);
            }


            //add what to do if someone clicks the button
            _buttons[0].OnClickEvent += Play;
            _buttons[3].OnClickEvent += Quit;

        }

        public void Update(GameTime gameTime)
        {
            foreach (var btn in _buttons)
            {
                btn.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var btn in _buttons)
            {
                btn.Draw(spriteBatch);
            }
        }

        private void Play()
        {
            _screen.SwapScreen(new GameScreen(_game,_screen));
        }

        private void Quit()
        {
            _game.Exit();
        }
    }
}
