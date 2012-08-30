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
        private static readonly string[] BtnName = {"Login", "Register", "Options", "Exit"};
        private readonly Game _game;
        private readonly ScreenManager _screen;
        private readonly NewsReader _news = new NewsReader();

        private readonly Label[] _label = new Label[2];

        #region buttonStyle
        private const int BtnWidth = 80;
        private const int BtnHeight = 50;
        private const int BtnSpacing = 20;
        private Vector2 _btnCenter = new Vector2(GameData.ScreenSize.X / 2 - ((BtnWidth * BtnName.Length/2) + (BtnSpacing * BtnName.Length/2) + BtnWidth + BtnSpacing), 
                                                    GameData.ScreenSize.Y / 2 - BtnHeight / 2);
        #endregion

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

            _buttons = new Button[BtnName.Length];

            for(var i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = new Button(new Rectangle((int)_btnCenter.X + (i * BtnWidth) + (i * BtnSpacing), (int)_btnCenter.Y, 
                                          BtnWidth, BtnHeight), buttonImg, font, BtnName[i]);
            }

            _label[0] = new Label(_news.ReadTitle(), new Vector2(10, 10), font, Color.Red, GameData.ScreenSize.X - 250);
            _label[1] = new Label(_news.ReadNews(), new Vector2(10, 40), font, Color.Black, GameData.ScreenSize.X - 250);


            //add what to do if someone clicks the button
            _buttons[0].OnClickEvent += Login;
            _buttons[3].OnClickEvent += _game.Exit;

        }

        public void Update(GameTime gameTime)
        {
            foreach (var btn in _buttons)
            {
                btn.Update(gameTime);
            }

            foreach (var lbl in _label)
            {
                lbl.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            foreach(var btn in _buttons)
            {
                btn.Draw(spriteBatch);
            }

            foreach (var lbl in _label)
            {
                lbl.Draw(spriteBatch);
            }
        }

        private void Login()
        {
            _screen.SwapScreen(new LoginScreen(_game,_screen));
        }

    }
}
