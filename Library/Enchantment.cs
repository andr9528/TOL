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

        public Enchantment(string name, double manaRegenCost, List<Tuple<ValidShorts, double>> modifiers)
        {
            Name = name;
            ManaRegenCost = manaRegenCost;

            foreach (Tuple<ValidShorts, double> mod in modifiers)
            {
                AddStatModifier(mod);
            }
        }
    }
}
