using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Graphics.Sprites
{
    public class AnimatedSprite : ISprite
    {
        private readonly Texture2D _spriteTexture;
        private readonly int _maxFrame = 0;
        private readonly int _startFrame = 0;

        public AnimatedSprite(Texture2D texture,int startFrame, int maxFrame)
        {
            _spriteTexture = texture;
            _maxFrame = maxFrame;
            _startFrame = startFrame;
            Frame = _startFrame;

            if(startFrame > maxFrame)
            {
                //TODO ADD LOGGER
                startFrame = maxFrame;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location,Rectangle part, float size)
        {
            spriteBatch.Draw(_spriteTexture, location, part, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
        }

        public void IncrementFrame()
        {
            Frame++;

            if(Frame > _maxFrame)
            {
                Frame = _startFrame;
            }

            if(Frame < _startFrame)
            {
                Frame = _startFrame;
            }
        }

        public int Frame { get; private set; }
    }
}
