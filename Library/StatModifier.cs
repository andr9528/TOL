using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class StatModifier
    {
        public enum ValidShorts { Hp, Mp, Hps, Mps, Dc, Bc, Prot, Cc, Cdm, MinDam, MaxDam, As}
        public enum Rarities { Common, Uncommon, Rare, Epic, Legendary, Godlike, Empty}
        internal List<double> RarityModifiers = new List<double>() { 1, 1.5, 2.25, 3.25, 4.5, 6 };
        List<Tuple<ValidShorts, double>> StatModifiers = new List<Tuple<ValidShorts, double>>();
        public Rarities Rarity { get; internal set; } // 60% Common, 20% Uncommon, 10% Rare, 6% Epic, 3% Legendary, 1% Godlike

        public List<Tuple<ValidShorts, double>> GetStatModifiers()
        {
            return StatModifiers;
        }
        public void AddStatModifier(Tuple<ValidShorts, double> modifier)
        {
            StatModifiers.Add(modifier);
        }
        public void RemoveStatModifier(int index)
        {
            StatModifiers.RemoveAt(index);
        }
        internal void SetRarity()
        {
            int rarityRole = Repo.Random.Next(1, 100);

            if (rarityRole <= 60)
            {
                Rarity = Rarities.Common;
            }
            else if (rarityRole > 60 && rarityRole <= 80)
            {
                Rarity = Rarities.Uncommon;
            }
            else if (rarityRole > 80 && rarityRole <= 90)
            {
                Rarity = Rarities.Rare;
            }
            else if (rarityRole > 90 && rarityRole <= 96)
            {
                Rarity = Rarities.Epic;
            }
            else if (rarityRole > 96 && rarityRole <= 99)
            {
                Rarity = Rarities.Legendary;
            }
            else if (rarityRole == 100)
            {
                Rarity = Rarities.Godlike;
            }
            else
            {
                throw new Exception("Something went wrong assigning a rarity");
            }
        }
    }
}
