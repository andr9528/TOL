using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Enchantment : StatModifier
    {
        /// <summary>
        /// Is true while the enchantment is currently active
        /// Is false while the enchantment is inactive, udo to too low of a mana regeneration
        /// </summary>
        public bool State { get; internal set; }
        /// <summary>
        /// Amount of mana regeneration needed to sustain the enchantment
        /// </summary>
        public double ManaRegenCost { get; internal set; }
        public string Name { get; internal set; }

        public Enchantment(string name, double manaRegenCost, 
            List<Tuple<ValidShorts, double>> modifiers, Rarities rarity = Rarities.Empty)
        {
            if (rarity != Rarities.Empty)
            {
                Rarity = rarity;
            }
            else
            {
                SetRarity();
            }
            

            Name = name;
            ManaRegenCost = manaRegenCost;

            foreach (Tuple<ValidShorts, double> mod in modifiers)
            {
                double temp = mod.Item2 * RarityModifiers[(int)Rarity];
                AddStatModifier(Tuple.Create(mod.Item1, temp));
            }

            
        }
    }
}
