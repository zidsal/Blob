using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Game.World.Entities
{
    public class Blob : Skeleton
    {
        public Blob(Vector2 location, string template) : base(string.Empty, location)
        {
            Identity = CreateIdentity(template);
            Name = Identity.Name;
            Img = Identity.Texture;
            Color = new Color(Identity.Rgb.Red, Identity.Rgb.Green, Identity.Rgb.Blue);
        }

        private static Identity CreateIdentity(string template)
        {

            var serializer = new XmlSerializer(typeof(Identity));

            var reader = new StringReader(template);
            var identity = (Identity) serializer.Deserialize(reader);
            reader.Close();


            return identity;
        }

        public Identity Identity { get; private set; }
    }
}