using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Game.World.Entities
{
    public class Hero : Character
    {
        private readonly Identity _identity;

        public Hero(Vector2 location, string template) : base(string.Empty, location)
        {
            _identity = CreateIdentity(template);
            Name = _identity.Name;
            Img = _identity.Texture;
        }

        private static Identity CreateIdentity(string template)
        {

            var serializer = new XmlSerializer(typeof(Identity));

            var reader = new StringReader(template);
            var identity = (Identity) serializer.Deserialize(reader);
            reader.Close();


            return identity;
        }
    }
}