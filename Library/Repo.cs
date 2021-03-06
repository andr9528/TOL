﻿using System;
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
                Create Monster Class
                    -> Instantiate many different monsters in the Repo to be used later while fighting
                Make Fight window, where battles between the player and random mosnters occure.
                Create Spell Class
                    -> Instantiate many different standard spells
                Create Enchantment Class
                    -> Instantiate many different standard enchantments
                Change player constructer to use a enum as gender
        */
        public enum ValidGenders { Male, Female }
        public static Random Random = new Random();

        #region Gods

        // Greek Gods
        static Gods Zeus = new Gods(new List<int>() {1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6},
                             "Zeus", 0, ValidGenders.Male);
        static Gods Hades = new Gods(new List<int>() {8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6},
                              "Hades", 1, ValidGenders.Male);
        static Gods Poseidon = new Gods(new List<int>() {1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7},
                                 "Poseidon", 2, ValidGenders.Male);
        static Gods Aphrodite = new Gods(new List<int>() {8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8},
                                  "Aphrodite", 3, ValidGenders.Female);
        static Gods Hephaestus = new Gods(new List<int>() {2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6},
                                   "Hephaestus", 4, ValidGenders.Male);
        static Gods Hera = new Gods(new List<int>() {4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8},
                             "Hera", 5, ValidGenders.Female);
        static Gods Athena = new Gods(new List<int>() {8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10},
                               "Athena", 6, ValidGenders.Female);
        static Gods Ares = new Gods(new List<int>() {4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4},
                             "Ares", 7, ValidGenders.Male);
        static Gods Hermes = new Gods(new List<int>() {3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6},
                               "Hermes", 8, ValidGenders.Male);
        static Gods Artemis = new Gods(new List<int>() {10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5},
                                "Artemis", 9, ValidGenders.Female);
        static Gods Apollo = new Gods(new List<int>() {10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5},
                               "Apollo", 10, ValidGenders.Male);
        static Gods Dionysus = new Gods(new List<int>() {1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4},
                                 "Dionysus", 11, ValidGenders.Male);
        // Egyptian Gods - Favoring not changed from greek!
        static Gods Ra = new Gods(new List<int>() { 1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6 },
                             "Ra", 12, ValidGenders.Male);
        static Gods Isis = new Gods(new List<int>() { 8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6 },
                              "Isis", 13, ValidGenders.Female);
        static Gods Set = new Gods(new List<int>() { 1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7 },
                                 "Set", 14, ValidGenders.Male);
        static Gods Horus = new Gods(new List<int>() { 8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8 },
                                  "Horus", 15, ValidGenders.Male);
        static Gods Osiris = new Gods(new List<int>() { 2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6 },
                                   "Osiris", 16, ValidGenders.Male);
        static Gods Anubis = new Gods(new List<int>() { 4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8 },
                             "Anubis", 17, ValidGenders.Male);
        static Gods Bast = new Gods(new List<int>() { 8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10 },
                               "Bast", 18, ValidGenders.Female);
        static Gods Ptah = new Gods(new List<int>() { 4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4 },
                             "Ptah", 19, ValidGenders.Male);
        static Gods Hathor = new Gods(new List<int>() { 3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6 },
                               "Hathor", 20, ValidGenders.Female);
        static Gods Thoth = new Gods(new List<int>() { 10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5 },
                                "Thoth", 21, ValidGenders.Male);
        static Gods Sekhmet = new Gods(new List<int>() { 10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5 },
                               "Sekhmet", 22, ValidGenders.Female);
        static Gods Nephthys = new Gods(new List<int>() { 1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4 },
                                 "Nephthys", 23, ValidGenders.Female);
        // Nordic Gods - Favoring not changed from greek!
        static Gods Thor = new Gods(new List<int>() { 1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6 },
                             "Thor", 24, ValidGenders.Male);
        static Gods Odin = new Gods(new List<int>() { 8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6 },
                              "Odin", 25, ValidGenders.Male);
        static Gods Loki = new Gods(new List<int>() { 1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7 },
                                 "Loki", 26, ValidGenders.Male);
        static Gods Forseti = new Gods(new List<int>() { 8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8 },
                                  "Forseti", 27, ValidGenders.Male);
        static Gods Freyja = new Gods(new List<int>() { 2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6 },
                                   "Freyja", 28, ValidGenders.Female);
        static Gods Hel = new Gods(new List<int>() { 4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8 },
                             "Hel", 29, ValidGenders.Female);
        static Gods Baldr = new Gods(new List<int>() { 8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10 },
                               "Baldr", 30, ValidGenders.Male);
        static Gods Tyr = new Gods(new List<int>() { 4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4 },
                             "Tyr", 31, ValidGenders.Male);
        static Gods Heimdall = new Gods(new List<int>() { 3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6 },
                               "Heimdall", 32, ValidGenders.Male);
        static Gods Skadi = new Gods(new List<int>() { 10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5 },
                                "Skadi", 33, ValidGenders.Female);
        static Gods Bragi = new Gods(new List<int>() { 10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5 },
                               "Bragi", 34, ValidGenders.Male);
        static Gods Njord = new Gods(new List<int>() { 1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4 },
                                 "Njord", 35, ValidGenders.Male);
        // Atlantic Titans - Favoring not changed from greek!
        static Gods Kronos = new Gods(new List<int>() { 1, 8, 3, 8, 1, 4, 7, 6, 8, 3, 8, 5, 1, 1, 10, 6 },
                             "Kronos", 36, ValidGenders.Male);
        static Gods Oranos = new Gods(new List<int>() { 8, 4, 3, 2, 8, 10, 4, 5, 5, 7, 2, 4, 10, 1, 1, 6 },
                              "Oranos", 37, ValidGenders.Male);
        static Gods Gaia = new Gods(new List<int>() { 1, 4, 8, 4, 9, 2, 4, 1, 8, 7, 7, 6, 1, 10, 1, 7 },
                                 "Gaia", 38, ValidGenders.Female);
        static Gods Hekate = new Gods(new List<int>() { 8, 4, 2, 8, 2, 5, 7, 2, 6, 3, 2, 8, 1, 6, 8, 8 },
                                  "Hekate", 39, ValidGenders.Female);
        static Gods Atlas = new Gods(new List<int>() { 2, 3, 9, 3, 9, 2, 2, 10, 3, 3, 8, 9, 9, 1, 1, 6 },
                                   "Atlas", 40, ValidGenders.Male);
        static Gods Helios = new Gods(new List<int>() { 4, 9, 2, 10, 2, 5, 7, 1, 8, 5, 2, 8, 1, 1, 7, 8 },
                             "Helios", 41, ValidGenders.Male);
        static Gods Theia = new Gods(new List<int>() { 8, 3, 1, 7, 1, 6, 6, 1, 9, 5, 1, 6, 5, 5, 6, 10 },
                               "Theia", 42, ValidGenders.Female);
        static Gods Rheia = new Gods(new List<int>() { 4, 9, 5, 4, 9, 5, 6, 6, 4, 4, 8, 3, 7, 1, 1, 4 },
                             "Rheia", 43, ValidGenders.Female);
        static Gods Hyperion = new Gods(new List<int>() { 3, 8, 1, 10, 3, 8, 9, 3, 6, 7, 2, 3, 1, 3, 7, 6 },
                               "Hyperion", 44, ValidGenders.Male);
        static Gods Oceanus = new Gods(new List<int>() { 10, 7, 1, 7, 1, 8, 9, 3, 4, 5, 1, 10, 1, 5, 3, 5 },
                                "Oceanus", 45, ValidGenders.Male);
        static Gods Prometheus = new Gods(new List<int>() { 10, 3, 8, 3, 8, 4, 6, 5, 6, 4, 1, 1, 5, 1, 10, 5 },
                               "Prometheus", 46, ValidGenders.Male);
        static Gods Leto = new Gods(new List<int>() { 1, 3, 9, 3, 9, 4, 4, 4, 6, 10, 6, 10, 1, 3, 3, 4 },
                                 "Leto", 47, ValidGenders.Female);
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

        static List<Player> characters = new List<Player>();

        static public void RemoveCharacter(Player entity)
        {
            characters.Remove(entity);
        }
        static public void AddCharacter(Player entity)
        {
            characters.Add(entity);
        }
        static public List<Player> GetCharacters()
        {
            return characters;
        }

        #endregion

        static Equipment item1 = new Equipment();
        static Equipment item2 = new Equipment();
        static Equipment item3 = new Equipment();
        static Equipment item4 = new Equipment();
        static Equipment item5 = new Equipment();
        static Equipment item6 = new Equipment();
        static Equipment item7 = new Equipment();
        static Equipment item8 = new Equipment();
        static Equipment item9 = new Equipment();
        static Equipment item10 = new Equipment();
        static Equipment item11 = new Equipment();
        static Equipment item12 = new Equipment();
        static Equipment item13 = new Equipment();
        static Equipment item14 = new Equipment();
        static Equipment item15 = new Equipment();
        static Equipment item16 = new Equipment();
        static Equipment item17 = new Equipment();
        static Equipment item18 = new Equipment();
        static Equipment item19 = new Equipment();
        static Equipment item20 = new Equipment();
        static Equipment item21 = new Equipment();
        static Equipment item22 = new Equipment();
        static Equipment item23 = new Equipment();
        static Equipment item24 = new Equipment();

        static public List<Equipment> Items = new List<Equipment>()
        {
            item1, item2, item3, item4, item5, item6,
            item7, item8, item9, item10, item11, item12,
            item13, item14, item15, item16, item17, item18,
            item19, item20, item21, item22, item23, item24
        };
    }
}
