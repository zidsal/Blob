using System;
using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens
{
    public class MainMenu : IScreen
    {
        private readonly Button[] _buttons = new Button[3];
        private readonly Game _game;

        public MainMenu(Game game)
        {
            _game = game;
            Initialize(_game.Content);
        }

        public void Initialize(ContentManager content)
        {
            var font = content.Load<SpriteFont>("CourierNew");
            var buttonImg = content.Load<Texture2D>("Button");

            _buttons[0] = new Button(new Rectangle(150,150, 80,20), buttonImg, font, "Play");
            _buttons[1] = new Button(new Rectangle(450, 150, 120, 20), buttonImg, font, "Options");
            _buttons[2] = new Button(new Rectangle(10,10,120,120),buttonImg,font,"Quit");

            //add what to do if someone clicks the button
            _buttons[0].OnClickEvent += Play;
            _buttons[2].OnClickEvent += Quit;

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
            Console.WriteLine("test");
        }

        private void Quit()
        {
            _game.Exit();
        }
    }
}
