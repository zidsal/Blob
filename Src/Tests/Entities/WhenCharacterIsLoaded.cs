using Game;
using Game.Entities;
using Game.World.Entities;
using Machine.Specifications;
using Microsoft.Xna.Framework;

namespace Tests.Entities
{
    class WhenEntityIsLoaded
    {
        private static Character _entity;
        private Establish _context = () =>
        {

        };

        private Because _of = () => _entity = new Character("foo", 0, Vector2.One);

        private It _shouldHaveLocationOfOne = () => _entity.Location.ShouldEqual(Vector2.One);
        private It _shouldHaveNameFoo = () => _entity.Name.ShouldEqual("foo");
        private It _shouldHaveAnIdOfZero = () => _entity.Id.ShouldEqual(0);
        private It _shouldHaveALocation = () => _entity.Direction.ShouldEqual(GameData.DefaultDirection);
    }
}
