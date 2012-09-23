using Game.Graphics.Sprites;
using Machine.Specifications;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.Graphics.Sprites
{
    public class WhenAnimatedSpriteFrameIncreasesBeyoundMaximum
    {
        private static AnimatedSprite _entity;
        private const int StartFrame = 2;

        private Establish _context = () =>
        {
            _entity = new AnimatedSprite(null, StartFrame, 2);
        };

        private Because _of = () => _entity.IncrementFrame();

        private It _shouldHaveChangedFrame = () => _entity.Frame.ShouldEqual(StartFrame);
    }
}
