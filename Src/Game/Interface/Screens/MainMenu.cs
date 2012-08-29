using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens
{
    public class MainMenu : IScreen
    {
        private Button[] _buttons = new Button[3];
        public MainMenu(ContentManager content)
        {
            Initialize(content);
        }

        public void Initialize(ContentManager content)
        {
            var font = content.Load<SpriteFont>("CourierNew");
            var buttonImg = content.Load<Texture2D>("Button");

            _buttons[0] = new Button(new Rectangle(150,150, 80,20), buttonImg, font, "Play");
            _buttons[1] = new Button(new Rectangle(450, 150, 120, 20), buttonImg, font, "Options");
            _buttons[2] = new Button(new Rectangle(10,10,120,120),buttonImg,font,"Quit");

        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var btn in _buttons)
            {
                btn.Draw(spriteBatch);
            }
        }
    }
}
