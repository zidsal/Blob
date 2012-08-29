using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Controls
{
    public class Button : IControl
    {
        private readonly Rectangle _location;
        private readonly Texture2D _texture;
        private readonly SpriteFont _font;
        private readonly Vector2 _textCenter = Vector2.One;
        private readonly string _text;

        //for onclick stuff
        public delegate void OnClick();
        public event OnClick OnClickEvent;

        public Button(Rectangle location, Texture2D texture, SpriteFont font, string text = "")
        {
            _location = location;
            _texture = texture;
            _font = font;
            _text = text;

            _textCenter = new Vector2(_location.X + _location.Width/2 - _font.MeasureString(_text).X /2,
                                       _location.Y + _location.Height / 2 - _font.MeasureString(_text).Y / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap,DepthStencilState.Default, RasterizerState.CullNone);
                spriteBatch.Draw(_texture,_location,Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
                spriteBatch.DrawString(_font, _text, _textCenter, Color.Black);
            spriteBatch.End();
        }

        public void PressButton()
        {
            if(OnClickEvent != null)
            {
                OnClickEvent();
            }
        }

    }

}
