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
        private Texture2D _texture;

        public InteractionMenu(String[] options, ContentManager content)
        {
            _font = content.Load<SpriteFont>("InteractionMenu");
            _options = options;
            _texture = content.Load<Texture2D>("Button");
            Visible = false;
            Location = new Vector2(100,100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible == false)
            {
                return;
            }


            //draw the background
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
            spriteBatch.Draw(_texture, new Rectangle((int)Location.X, (int)Location.Y, 48, 14), new Color(0, 0, 0, 120)); //top part
                spriteBatch.Draw(_texture, new Rectangle((int)Location.X, (int)Location.Y + 14, 48, (_options.Length * 15)), new Color(128, 128, 128, 150)); //bottem part
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
        }

        public void OnClick()
        {
            if (Visible == false)
            {
                return;
            }
        }

        public Vector2 Location { get; private set; }
        public bool Visible { get; private set; }

        public void ShowMenu(float x, float y)
        {
            Location = new Vector2(x,y);
            Visible = true;
        }

        public void HideMenu()
        {
            Visible = false;
        }
    }
}
