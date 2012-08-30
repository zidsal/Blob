using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Interface.Controls
{
    public class TextBox :IControl
    {
        private readonly Texture2D _texture;
        private readonly SpriteFont _font;
        private readonly Color _color;

        private string _text = "";
        private Rectangle _position;
        private KeyboardState _currentKeyBoardState;
        private KeyboardState _prevKeyBoardState;

        //refactor
        public delegate void Click();
        public event Click OnClickEvent;
        private MouseState _currentMouseState;
        private MouseState _prevMouseState;

        public TextBox(Texture2D texture, Rectangle position, SpriteFont font, Color color)
        {
            _texture = texture;
            _position = position;
            _font = font;
            _color = color;
            _position = position;
            HasFocus = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
                spriteBatch.Draw(_texture, _position, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
                spriteBatch.DrawString(_font, _text, new Vector2(_position.X, _position.Y), _color);
            spriteBatch.End();
        }

        public void Update(GameTime time)
        {
            _currentKeyBoardState = Keyboard.GetState();
            _currentMouseState = Mouse.GetState();

            var shift = _currentKeyBoardState.IsKeyDown(Keys.LeftShift) || _currentKeyBoardState.IsKeyDown(Keys.RightShift);

            if (_currentMouseState.LeftButton == ButtonState.Released && _prevMouseState.LeftButton == ButtonState.Pressed)
            {
                if (_position.Contains(_currentMouseState.X, _currentMouseState.Y))
                {
                    OnClick();
                }
            }


            foreach (var key in _currentKeyBoardState.GetPressedKeys().Where(key => _prevKeyBoardState.IsKeyUp(key)).TakeWhile(key => HasFocus))
            {
                if (key == Keys.Space)
                {
                    _text += " ";
                }
                else if (key == Keys.Back && _text.Length >= 1)
                {
                    _text = _text.Remove(_text.Length - 1);
                }
                else //key codes are in ascii so work them out
                {
                    if (shift == false)
                    {
                        if ((int) key >= 65 && (int) key <= 90)
                        {
                            _text += ConvertFromAsciiToChar((int) key + 32); //little ascii trick atm key codes are in upper case add + 32 to get them to lower case
                        }

                        else if ((int) key >= 48 && (int) key <= 75)
                        {
                            _text += ConvertFromAsciiToChar((int) key); //numbers are fine
                        }
                    }
                    else
                    {
                        if ((int)key >= 65 && (int)key <= 90)
                        {
                            _text += ConvertFromAsciiToChar((int)key); //by default the letters are in upper case 
                        }

                        else if ((int)key >= 48 && (int)key <= 75)
                        {
                            _text += ConvertFromAsciiToChar((int)key - 16); //turn numbers into there shift value by - 16
                        }
                    }

                }
            }
            _prevKeyBoardState = _currentKeyBoardState;
            _prevMouseState = _currentMouseState;
        }

        public void OnClick()
        {
            if (OnClickEvent != null)
            {
                OnClickEvent();
            }

            HasFocus = true;
        }

        private static char ConvertFromAsciiToChar(int ascii)
        {
            return Convert.ToChar(ascii);
        }

        public string GetText()
        {
            return _text;
        }

        public void RemoveFocus()
        {
            HasFocus = false;
        }

        public bool HasFocus {get; private set;}
    }
}
