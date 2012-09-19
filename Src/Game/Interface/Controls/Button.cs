using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        public delegate void Click();
        public event Click OnClickEvent;
        private MouseState _currentMouseState;
        private MouseState _prevMouseState;
        

        public Button(Rectangle location, ContentManager content, string text = "")
        {
            _location = location;
            _texture = content.Load<Texture2D>("Button");
            _font = content.Load<SpriteFont>("ControlFont");
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

        public void Update(GameTime time)
        {
            _currentMouseState = Mouse.GetState();

            if (_currentMouseState.LeftButton == ButtonState.Released && _prevMouseState.LeftButton == ButtonState.Pressed)
            {
                if (_location.Contains(_currentMouseState.X, _currentMouseState.Y))
                {
                    OnClick();
                }
            }

            _prevMouseState = _currentMouseState;
        }

        public void OnClick()
        {
            if(OnClickEvent != null)
            {
                OnClickEvent();
            }
        }

    }
}
