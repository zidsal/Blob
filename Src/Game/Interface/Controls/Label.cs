using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Controls
{
    class Label : IControl
    {
        private readonly string _text;
        private readonly Vector2 _position;
        private readonly SpriteFont _font;
        private readonly Color _color;

        public Label(string text, Vector2 position, SpriteFont font, Color color, bool wordWrap = true)
        {
            _text = text;
            _position = position;
            _font = font;
            _color = color;

            if (wordWrap && font.MeasureString(_text).X > GameData.ScreenSize.X - 250)
            {
                _text = WordWarp(_text, _font);
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

        private static string WordWarp(string text, SpriteFont font)
        {
            var currentLine = "";
            var textWithSpacing = "";

            foreach (var c in text)
            {
                currentLine += c;
                float currentLineSize = font.MeasureString(currentLine).X;

                if (currentLineSize >= GameData.ScreenSize.X - 250)
                {
                    textWithSpacing += "\n";
                    currentLine = string.Empty;
                }
                else
                {
                    textWithSpacing += c;
                }
            }

            return textWithSpacing;
        }
    }
}
