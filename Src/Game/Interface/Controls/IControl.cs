using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Interface.Controls
{
    interface IControl
    {
        void Draw(SpriteBatch batch);
        void Update(GameTime time);
    }
}
