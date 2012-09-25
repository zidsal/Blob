using System;
using System.Collections.Generic;
using System.Linq;
using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Interface.Screens.GameGui
{
    class InteractionMenu : IControl
    {
        private readonly SpriteFont _font;
        private readonly string[] _options;
        private readonly Texture2D _texture;
        private readonly int _menuLength = 48;
        private Rectangle _collision;

        #region onclick
     public delegate void Click(InteractionMenuEventArgs e);
     public event Click OnClickEvent;
     private MouseState _currentMouseState;
     private MouseState _prevMouseState;
#endregion

        public InteractionMenu(String[] options, ContentManager content)
        {
            _font = content.Load<SpriteFont>("InteractionMenu");
            _options = options;
            _texture = content.Load<Texture2D>("Button");
            Visible = false;
            Location = new Vector2(100,100);
            _menuLength = (int)_font.MeasureString(FindLongestWord(_options)).X + 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible == false)
            {
                return;
            }

            //draw the background
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
                spriteBatch.Draw(_texture, new Rectangle((int)Location.X, (int)Location.Y, _menuLength, 14), new Color(0, 0, 0, 120)); //top part
                spriteBatch.Draw(_texture, new Rectangle((int)Location.X, (int)Location.Y + 14, _menuLength, (_options.Length * 15)), new Color(128, 128, 128, 150)); //bottem part
            spriteBatch.End();

            //draw the text
            spriteBatch.Begin();
                for (var i = 0; i < _options.Length; i++)
                {
                    var location = new Vector2((int)Location.X, (int)Location.Y + (i * 15) + 14);
                    spriteBatch.DrawString(_font, "Options", new Vector2((int)Location.X, (int)Location.Y), Color.White); //top part
                    spriteBatch.DrawString(_font, _options[i], location, Color.Black); //bottem part
                }
            spriteBatch.End();
        }

        public void Update(GameTime time)
        {
            if (Visible == false)
            {
                return;
            }
            _currentMouseState = Mouse.GetState();

            //check to see if hero has been clicked
            if (_currentMouseState.LeftButton == ButtonState.Released && _prevMouseState.LeftButton == ButtonState.Pressed)
            {
                if (_collision.Contains(_currentMouseState.X, _currentMouseState.Y))
                {
                    OnClick();
                }
            }
            _prevMouseState = _currentMouseState;

        }

        public void OnClick()
        {
            if (Visible == false)
            {
                return;
            }

            if (OnClickEvent != null)
            {
                OnClickEvent(new InteractionMenuEventArgs(FindOptionClickedOn(_currentMouseState.X, _currentMouseState.Y)));
            }
        }

        public Vector2 Location { get; private set; }
        public bool Visible { get; private set; }

        public void ShowMenu(float x, float y)
        {
            Location = new Vector2(x,y);
            Visible = true;
            _collision = new Rectangle((int)x, (int)y, _menuLength, _options.Length * 15 + 14);
        }

        public void HideMenu()
        {
            Visible = false;
        }

        private string FindOptionClickedOn(float x, float y)
        {

            y = y - 14;
            var option = ((int) y/15) - 2;

            return option < 0 ? string.Empty : _options[option];
        }

        private static string FindLongestWord (IEnumerable<string> words)
        {
            var longest = "";

            foreach (var word in words.Where(word => word.Length > longest.Length))
            {
                longest = word;
            }

            return longest;
        }
    }

    public class InteractionMenuEventArgs : EventArgs
    {
        public string Option { get; private set; }

        public InteractionMenuEventArgs(string option)
        {
            Option = option;
        }
    }
}
