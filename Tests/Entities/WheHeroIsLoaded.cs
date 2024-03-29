﻿using Game.World.Entities;
using Machine.Specifications;
using Microsoft.Xna.Framework;

namespace Tests.Entities
{
    public class WheHeroIsLoaded
    {
        private static  Blob _hero;
        private static  Vector2 _startLocation;

        #region xml
        private static string _xml = @"<?xml version='1.0' encoding='utf-8'?>
<Identity xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <Name>foo</Name>
  <FaceTexture>face</FaceTexture>
  <Texture>player</Texture>
  <HeroType>tracker</HeroType>
  <Info>foobarbaz.</Info>
  <Stats>
    <Health>5</Health>
    <MagicDamage>5</MagicDamage>
    <PhysicalDamage>5</PhysicalDamage>
    <Defense>5</Defense>
  </Stats>
  <ActiveAbilitites>
    <AbilityId>6</AbilityId>
    <AbilityId>7</AbilityId>
    <AbilityId>1</AbilityId>
  </ActiveAbilitites>
  <PassiveAbilitites>
    <AbilityId>6</AbilityId>
    <AbilityId>7</AbilityId>
    <AbilityId>1</AbilityId>
  </PassiveAbilitites>
</Identity>";
        #endregion

        private Establish _context = () =>
        {
            _startLocation = Vector2.One;
        };

        private Because _of = () => _hero = new Blob(_startLocation, _xml);

        private It _shouldHaveNameFoo = () => _hero.Name.ShouldEqual("foo");

        private It _shouldHaveInfoLopsium = () =>_hero.Identity.Info.ShouldEqual("foobarbaz.");

    }
}
