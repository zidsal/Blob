using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.World.Entities
{
    interface IEntity
    {
        void Initialize(ContentManager content);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void OnClick();
    }
}
