using Game.World.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.World
{
   public class GameWorld
    {
       #region xml
       private static string _xml = @"<?xml version='1.0' encoding='utf-8'?>
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
        private readonly Hero _player = new Hero(new Vector2(32,32), _xml);

        public void Initialize(ContentManager content)
        {
            _player.Initialize(content);
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
        }

       public Hero GetPlayer()
       {
           return _player;
       }
    }
}
