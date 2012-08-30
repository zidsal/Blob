using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Controls
{
    interface IControl
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime time);
        void OnClick();
    }
}
