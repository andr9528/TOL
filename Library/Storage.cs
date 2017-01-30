using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Storage
    {
        // Gods
        // Greek Gods
        Gods Zeus = new Gods("1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6",
                             "Zeus", 0);
        Gods Hades = new Gods("8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6",
                              "Hades", 1);
        Gods Poseidon = new Gods("1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7",
                                 "Poseidon", 2);
        Gods Aphrodite = new Gods("8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8",
                                  "Aphrodite", 3);
        Gods Hephaestus = new Gods("2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6",
                                   "Hephaestus", 4);
        Gods Hera = new Gods("",
                             "Hera", 5);
        Gods Athena = new Gods("",
                               "Athena", 6);
        Gods Ares = new Gods("",
                             "Ares", 7);
        Gods Hermes = new Gods("",
                               "Hermes", 8);
        Gods Artemis = new Gods("",
                                "Artemis", 9);
        Gods Apollo = new Gods("",
                               "Apollo", 10);
        Gods Dionysus = new Gods("",
                                 "Dionysus", 11);
        // Egyptian Gods

        // Nordic Gods

        // Atlantic Titans

        static List<Gods> greekGods = new List<Gods>();
        static List<Gods> egyptianGods = new List<Gods>();
        static List<Gods> nordicGods = new List<Gods>();
        static List<Gods> atlanticTitans = new List<Gods>();

        static List<string> godGreekString = new List<string>() {
            "Zeus", "Hades", "Poseidon", "Aphrodite",
            "Hephaestus", "Hera", "Athena", "Ares",
            "Hermes", "Artemis", "Apollo", "Dionysus"
        };
        static List<string> godEgyptianString = new List<string>()
        {
            "Ra", "Isis", "Set", "Horus",
            "Osiris", "Anubis", "Bast", "Ptah",
            "Hathor", "Thoth", "Sekhmet", "Nephthys"
        };
        static List<string> godNordicString = new List<string>()
        {
            "Thor", "Odin", "Loki", "Forseti",
            "Freyja", "Hel", "Baldr", "Tyr",
            "Heimdall", "Skadi", "Bragi", "Njord"
        };

        static List<string> godAtlanticString = new List<string>()
        {
            "Kronos", "Oranos", "Gaia", "Hekate",
            "Atlas", "Helios", "Theia", "Rheia",
            "Hyperion", "Oceanus", "Prometheus", "Leto"
        };

        static public List<string> GodGreekString { get { return godGreekString; } }
        static public List<string> GodEgyptianString { get { return godEgyptianString; } }
        static public List<string> GodNordicString { get { return godNordicString; } }
        static public List<string> GodAtlanticString { get { return godAtlanticString; } }
        static public List<Gods> GreekGods { get { return greekGods; } }
        static public List<Gods> EgyptianGods { get { return egyptianGods; } }
        static public List<Gods> NordicGods { get { return nordicGods; } }
        static public List<Gods> AtlanticTitans { get { return atlanticTitans; } }


        // Skills
        Skill Archery = new Skill(0, "Archery");
        Skill OneHanded = new Skill(1,  "OneHanded");
        Skill TwoHanded = new Skill(2, "TwoHanded");
        Skill LightArmor = new Skill(3, "LightArmor");
        Skill HeavyArmor = new Skill(4, "HeavyArmor");
        Skill Stealth = new Skill(5, "Stealth");
        Skill Agility = new Skill(6, "Agility");
        Skill Smithing = new Skill(7,  "Smithing");
        Skill Enchanting = new Skill(8, "Enchanting");
        Skill Alchemy = new Skill(9, "Alchemy");
        Skill Blocking = new Skill(10, "Blocking");
        Skill WildMagic = new Skill(11, "WildMagic");
        Skill InfernoMagic = new Skill(12, "InfernoMagic");
        Skill BlizzMagic = new Skill(13, "BlizzMagic");
        Skill Skymagic = new Skill(14, "Skymagic");
        Skill PureMagic = new Skill(15, "PureMagic");

        static List<Skill> skillList = new List<Skill>();
        static List<string> skillString = new List<string>()
        {
            "Archery", "OneHanded", "TwoHanded", "LightArmor",
            "HeavyArmor", "Stealth", "Agility", "Smithing",
            "Enchanting", "Alchemy", "Blocking", "WildMagic",
            "InfernoMagic", "BlizzMagic", "Skymagic", "PureMagic"
        };
        static public List<string> SkillString { get { return skillString; } }
        static public List<Skill> SkillList { get { return skillList; } }

        // Character

        static List<Character> characters = new List<Character>();

        static public List<Character> Characters { get { return characters; } set { characters = value; } }
        
        // Functions
        public Storage()
        {
            List<Skill> skillSkillSetup = new List<Skill>()
           {
                Archery, OneHanded, TwoHanded, LightArmor,
                HeavyArmor, Stealth, Agility, Smithing,
                Enchanting, Alchemy, Blocking, WildMagic,
                InfernoMagic, BlizzMagic, Skymagic, PureMagic
           };

            List<Gods> godsGreekSetup = new List<Gods>()
            {
                Zeus, Hades, Poseidon, Aphrodite,
                Hephaestus, Hera, Athena, Ares,
                Hermes, Artemis, Apollo, Dionysus
            };

            //List<Gods> egyptianGodsSetup = new List<Gods>();
            //{
            //    Ra, Isis, Set, Horus,
            //    Osiris, Anubis, Bast, Ptah,
            //    Hathor, Thoth, Sekhmet, Nephthys
            //};

            // List<Gods> nordicGodsSetup = new List<Gods>();
            //{
            //    Thor, Odin, Loki, Forseti,
            //    Freyja, Hel, Baldr, Tyr,
            //    Heimdall, Skadi, Bragi, Njord
            //};

            //List<Gods> atlanticTitansSetup = new List<Gods>();
            //{
            //    Kronos, Oranos, Gaia, Hekate,
            //    Atlas, Helios, Theia, Rheia,
            //    Hyperion, Oceanus, Prometheus, Leto
            //};

            greekGods = godsGreekSetup;
            //EgyptianGods = egyptianGodsSetup
            //NordicGods = nordicGodsSetup
            //AtlanticTitans = atlanticTitansSetup
            skillList = skillSkillSetup;
        }

        public void removeCharacter(int index)
        {
            Characters.RemoveAt(index);
        }
    }
}
