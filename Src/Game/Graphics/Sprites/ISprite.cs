using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Graphics.Sprites
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location,Rectangle part, float size);
    }
}
