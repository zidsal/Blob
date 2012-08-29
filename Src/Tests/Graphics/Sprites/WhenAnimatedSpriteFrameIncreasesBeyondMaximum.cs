using Game.Graphics.Sprites;
using Machine.Specifications;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.Graphics.Sprites
{
    class WhenAnimatedSpriteFrameIncreases
    {
        private static AnimatedSprite _entity;
        private static Texture2D _fakeTexture;
        private const int StartFrame = 0;

        private Establish _context = () =>
        {
            _fakeTexture = new Texture2D(null,0,0);
            _entity = new AnimatedSprite(_fakeTexture, StartFrame, 2);
        };

        private Because _of = () => _entity.IncrementFrame();

        private It _shouldHaveChangedFrame = () => _entity.Frame.ShouldNotEqual(StartFrame);
    }
}
