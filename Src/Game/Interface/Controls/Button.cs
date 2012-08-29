using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Controls
{
    public class Button : IControl
    {
        private readonly Rectangle _location;
        private readonly Texture2D _texture;
        private readonly SpriteFont _font;
        private Vector2 textCenter = Vector2.One;
        private readonly string _text;

        public Button(Rectangle location, Texture2D texture, SpriteFont font, string text = "")
        {
            _location = location;
            _texture = texture;
            _font = font;
            _text = text;

            textCenter = new Vector2(_location.X + (_location.Width / 2), _location.Y + (_location.Height / 2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,_location,Color.White);
            spriteBatch.DrawString(_font, _text, textCenter, Color.White);
        }
    }
}
