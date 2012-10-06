using System.Xml.Serialization;

namespace Game.World.Entities
{
    [XmlRoot("Identity")]
    public class Identity
    {
        public string Name { get; set; }
        public string Texture { get; set; }
        public string Info { get; set; }
        public Stats Stats { get; set; }
        public Rgb Rgb { get; set; }
    }

    public class Stats
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
    }

    public class Rgb
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }

}
