using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Interface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Screens.GameGui
{
    class InteractionMenu : IControl
    {
        private readonly SpriteFont _font;
        private readonly string[] _options;

        public InteractionMenu(String[] options, ContentManager content)
        {
            _font = content.Load<SpriteFont>("InteractionMenu");
            _options = options;
            Visible = false;
            Location = new Vector2(100,100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible == false)
            {
                return;
            }

            //draw the text
            spriteBatch.Begin();
                for (var i = 0; i < _options.Length; i++)
                {
                    var location = new Vector2(100, 100 + (i * 20));
                    spriteBatch.DrawString(_font, _options[i], location, Color.Black);
                }
            spriteBatch.End();
        }

        public void Update(GameTime time)
        {
            if (Visible == false)
            {
                return;
            }
        }

        public void OnClick()
        {
            if (Visible == false)
            {
                return;
            }
        }

        public Vector2 Location { get; private set; }
        public bool Visible { get;  set; }
    }
}
