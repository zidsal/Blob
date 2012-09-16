using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Controls
{
    class Label : IControl
    {
        private readonly string _text;
        private readonly Vector2 _position;
        private readonly SpriteFont _font;
        private readonly Color _color;
        private readonly float _width;

        public Label(string text, Vector2 position, ContentManager content, Color color, float width)
        {
            _text = text;
            _position = position;
            _font = content.Load<SpriteFont>("ControlFont");
            _color = color;
            _width = width;

            if (_font.MeasureString(_text).X > _width)
            {
                _text = WordWarp(_text);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
                spriteBatch.DrawString(_font, _text, _position, _color);
            spriteBatch.End();
        }

        public void Update(GameTime time)
        {
        }

        public void OnClick()
        {
            throw new System.NotImplementedException();
        }

        private string WordWarp(string text)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (_font.MeasureString(line + word).Length() > _width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
        }

    }
}
