using Game.World.Entities;
using Machine.Specifications;
using Microsoft.Xna.Framework;

namespace Tests.Entities
{
    public class WheHeroIsLoaded
    {
        private static  Hero _hero;
        private static  Vector2 _startLocation;

        #region xml

        private const string Xml = @"<?xml version='1.0' encoding='utf-8'?>
<Identity xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <Name>foo</Name>
  <Texture>player</Texture>
  <HeroType>tracker</HeroType>
  <Stats>
    <Health>5</Health>
    <MagicDamage>5</MagicDamage>
    <PhysicalDamage>5</PhysicalDamage>
    <Defense>5</Defense>
  </Stats>
  <ActiveAbilitites>
    <AbilityId>1</AbilityId>
    <AbilityId>2</AbilityId>
    <AbilityId>3</AbilityId>
  </ActiveAbilitites>
  <PassiveAbilitites>
    <AbilityId>1</AbilityId>
    <AbilityId>2</AbilityId>
    <AbilityId>3</AbilityId>
  </PassiveAbilitites>
</Identity>";

        #endregion

        private Establish _context = () =>
        {
            _startLocation = Vector2.One;

        };

        private Because _of = () => _hero = new Hero(_startLocation, Xml);

        private It _shouldHaveNameFoo = () => _hero.Name.ShouldEqual("foo");
        private It _shouldHaveSpritePlayer = () => _hero.Img.ShouldEqual("player");

    }
}
