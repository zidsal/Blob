using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game.World.Entities
{
    [XmlRoot("Identity")]
    public class Identity
    {
        public string Name { get; set; }
        public string Texture { get; set; }
        public string HeroType { get; set; }

        public Stats Stats { get; set; }
        public ActiveAbilitites ActiveAbilitites { get; set; }
        public PassiveAbilitites PassiveAbilitites { get; set; }
    }

    public class ActiveAbilitites
    {
        [XmlElement("AbilityId")]
        public List<int> ActiveAbilitiesId { get; set; }
    }

    public class PassiveAbilitites
    {
        [XmlElement("AbilityId")]
        public List<int> PassiveAbilitiesId { get; set; }
    }

    public class Stats
    {
        public int Health { get; set; }
        public int MagicDamage { get; set; }
        public int PhysicalDamage { get; set; }
        public int Defense { get; set; }
    }

}
