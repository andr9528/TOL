using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Repo
    {
        /*
            TODO ->
                Make new Favoring numbers for Egyptians, Norse & Atlantic Divines
                Make charackter window, where stats can be seen
                Make Health, Mana, Health & Mana Regeneration & Melee/Ranged Damage on character.
                    -> Health Scales with level of Light Armor, Heavy Armor, Agility & Blocking
                    -> Mana Scales with levels of Wild, Inferno Blizz, Sky & Pure Magic, with Pure being 4 times as effective
                    -> Mana regeneration scales with Pure magic
                    -> Health Regeneration scales with max health (& possibly other things)
                    -> Melee / Rnaged damage depends on the weapon quality and proficiancy with that type of weapon
                Create Monster Class
                    -> Instantiate many different monsters in the Repo to be used later while fighting
                Make Fight window, where battles between the player and random mosnters occure.
                Create Spell Class
                    -> Instantiate many different standard spells
                Create Weapon Class
                    -> Instantiate many different weapons
                Create Armor Class
                    -> Instantiate many different armors
        */
        #region Gods

        // Greek Gods
        static Gods Zeus = new Gods(new List<int>() {1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6},
                             "Zeus", 0, "Male");
        static Gods Hades = new Gods(new List<int>() {8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6},
                              "Hades", 1, "Male");
        static Gods Poseidon = new Gods(new List<int>() {1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7},
                                 "Poseidon", 2, "Male");
        static Gods Aphrodite = new Gods(new List<int>() {8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8},
                                  "Aphrodite", 3, "Female");
        static Gods Hephaestus = new Gods(new List<int>() {2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6},
                                   "Hephaestus", 4, "Male");
        static Gods Hera = new Gods(new List<int>() {4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8},
                             "Hera", 5, "Female");
        static Gods Athena = new Gods(new List<int>() {8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10},
                               "Athena", 6, "Female");
        static Gods Ares = new Gods(new List<int>() {4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4},
                             "Ares", 7, "Male");
        static Gods Hermes = new Gods(new List<int>() {3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6},
                               "Hermes", 8, "Male");
        static Gods Artemis = new Gods(new List<int>() {10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5},
                                "Artemis", 9, "Female");
        static Gods Apollo = new Gods(new List<int>() {10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5},
                               "Apollo", 10, "Male");
        static Gods Dionysus = new Gods(new List<int>() {1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4},
                                 "Dionysus", 11, "Male");
        // Egyptian Gods - Favoring not changed from greek!
        static Gods Ra = new Gods(new List<int>() { 1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6 },
                             "Ra", 0, "Male");
        static Gods Isis = new Gods(new List<int>() { 8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6 },
                              "Isis", 1, "Female");
        static Gods Set = new Gods(new List<int>() { 1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7 },
                                 "Set", 2, "Male");
        static Gods Horus = new Gods(new List<int>() { 8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8 },
                                  "Horus", 3, "Male");
        static Gods Osiris = new Gods(new List<int>() { 2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6 },
                                   "Osiris", 4, "Male");
        static Gods Anubis = new Gods(new List<int>() { 4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8 },
                             "Anubis", 5, "Male");
        static Gods Bast = new Gods(new List<int>() { 8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10 },
                               "Bast", 6, "Female");
        static Gods Ptah = new Gods(new List<int>() { 4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4 },
                             "Ptah", 7, "Male");
        static Gods Hathor = new Gods(new List<int>() { 3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6 },
                               "Hathor", 8, "Female");
        static Gods Thoth = new Gods(new List<int>() { 10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5 },
                                "Thoth", 9, "Male");
        static Gods Sekhmet = new Gods(new List<int>() { 10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5 },
                               "Sekhmet", 10, "Female");
        static Gods Nephthys = new Gods(new List<int>() { 1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4 },
                                 "Nephthys", 11, "Female");
        // Nordic Gods - Favoring not changed from greek!
        static Gods Thor = new Gods(new List<int>() { 1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6 },
                             "Thor", 0, "Male");
        static Gods Odin = new Gods(new List<int>() { 8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6 },
                              "Odin", 1, "Male");
        static Gods Loki = new Gods(new List<int>() { 1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7 },
                                 "Loki", 2, "Male");
        static Gods Forseti = new Gods(new List<int>() { 8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8 },
                                  "Forseti", 3, "Male");
        static Gods Freyja = new Gods(new List<int>() { 2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6 },
                                   "Freyja", 4, "Female");
        static Gods Hel = new Gods(new List<int>() { 4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8 },
                             "Hel", 5, "Female");
        static Gods Baldr = new Gods(new List<int>() { 8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10 },
                               "Baldr", 6, "Male");
        static Gods Tyr = new Gods(new List<int>() { 4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4 },
                             "Tyr", 7, "Male");
        static Gods Heimdall = new Gods(new List<int>() { 3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6 },
                               "Heimdall", 8, "Male");
        static Gods Skadi = new Gods(new List<int>() { 10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5 },
                                "Skadi", 9, "Female");
        static Gods Bragi = new Gods(new List<int>() { 10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5 },
                               "Bragi", 10, "Male");
        static Gods Njord = new Gods(new List<int>() { 1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4 },
                                 "Njord", 11, "Male");
        // Atlantic Titans - Favoring not changed from greek!
        static Gods Kronos = new Gods(new List<int>() { 1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6 },
                             "Kronos", 0, "Male");
        static Gods Oranos = new Gods(new List<int>() { 8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6 },
                              "Oranos", 1, "Male");
        static Gods Gaia = new Gods(new List<int>() { 1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7 },
                                 "Gaia", 2, "Female");
        static Gods Hekate = new Gods(new List<int>() { 8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8 },
                                  "Hekate", 3, "Female");
        static Gods Atlas = new Gods(new List<int>() { 2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6 },
                                   "Atlas", 4, "Male");
        static Gods Helios = new Gods(new List<int>() { 4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8 },
                             "Helios", 5, "Male");
        static Gods Theia = new Gods(new List<int>() { 8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10 },
                               "Theia", 6, "Female");
        static Gods Rheia = new Gods(new List<int>() { 4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4 },
                             "Rheia", 7, "Female");
        static Gods Hyperion = new Gods(new List<int>() { 3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6 },
                               "Hyperion", 8, "Male");
        static Gods Oceanus = new Gods(new List<int>() { 10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5 },
                                "Oceanus", 9, "Male");
        static Gods Prometheus = new Gods(new List<int>() { 10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5 },
                               "Prometheus", 10, "Male");
        static Gods Leto = new Gods(new List<int>() { 1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4 },
                                 "Leto", 11, "Female");
        static List<Gods> greekGods = new List<Gods>()
        {
                Zeus, Hades, Poseidon, Aphrodite,
                Hephaestus, Hera, Athena, Ares,
                Hermes, Artemis, Apollo, Dionysus
        };
        static List<Gods> egyptianGods = new List<Gods>()
        {
                Ra, Isis, Set, Horus,
                Osiris, Anubis, Bast, Ptah,
                Hathor, Thoth, Sekhmet, Nephthys
        };
        static List<Gods> nordicGods = new List<Gods>()
        {
                Thor, Odin, Loki, Forseti,
                Freyja, Hel, Baldr, Tyr,
                Heimdall, Skadi, Bragi, Njord
        };
        static List<Gods> atlanticTitans = new List<Gods>()
        {
                Kronos, Oranos, Gaia, Hekate,
                Atlas, Helios, Theia, Rheia,
                Hyperion, Oceanus, Prometheus, Leto
        };
        static List<Gods> allDivines = new List<Gods>()
        {
                Zeus, Hades, Poseidon, Aphrodite,
                Hephaestus, Hera, Athena, Ares,
                Hermes, Artemis, Apollo, Dionysus,
                Ra, Isis, Set, Horus,
                Osiris, Anubis, Bast, Ptah,
                Hathor, Thoth, Sekhmet, Nephthys,
                Thor, Odin, Loki, Forseti,
                Freyja, Hel, Baldr, Tyr,
                Heimdall, Skadi, Bragi, Njord,
                Kronos, Oranos, Gaia, Hekate,
                Atlas, Helios, Theia, Rheia,
                Hyperion, Oceanus, Prometheus, Leto
        };

        static public List<Gods> GreekGods { get { return greekGods; } }
        static public List<Gods> EgyptianGods { get { return egyptianGods; } }
        static public List<Gods> NordicGods { get { return nordicGods; } }
        static public List<Gods> AtlanticTitans { get { return atlanticTitans; } }
        static public List<Gods> AllDivines { get { return allDivines; } }

        #endregion
        #region Character

        static List<Character> characters = new List<Character>();

        static public void RemoveCharacter(Character entity)
        {
            characters.Remove(entity);
        }
        static public void AddCharacter(Character entity)
        {
            characters.Add(entity);
        }
        static public List<Character> GetCharacters()
        {
            return characters;
        }

        #endregion
    }
}
