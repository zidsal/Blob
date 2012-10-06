using System.Collections.Generic;
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
  <Info>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</Info>
  <Stats>
    <Health>5</Health>
    <Damage>5</Damage>
    <Defense>5</Defense>
  </Stats>
    <Rgb>
        <Red>0</Red>
        <Green>255</Green>
        <Blue>0</Blue>
    </Rgb>
</Identity>";
       #endregion
       private readonly List<Blob> _blobs = new List<Blob>();

        public void Initialize(ContentManager content)
        {
            _blobs.Add(new Blob(new Vector2(32, 32), _xml));

            foreach (var hero in _blobs)
            {
                hero.Initialize(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var hero in _blobs)
            {
                hero.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var hero in _blobs)
            {
                hero.Draw(spriteBatch);
            }
        }

       public List<Blob> GetBlobs()
       {
           return  _blobs;
       }
    }
}
