using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Equipment
    {
        /*
         * Format:
         * Short for what too add to. - Valid Shorts: Hp -> Health Point, Mp -> Mana Point, Hps -> Health per second, Mps -> Mana per second
         * Then a ¤, whuch will be used to split at.
         * Then a value which will be added to the stat mentioned before. 
         * 
         * Example:
         * HP¤40 -> Will add 40 hp to the wearer
        */
        List<string> StatModifiers = new List<string>();
        List<Enchantment> Enchantments = new List<Enchantment>();
        public string EquipementSlot { get; internal set; }
        public string Name { get; internal set; }
        public string SkillName { get; internal set; }

        public List<string> GetStatModifiers()
        {
            return StatModifiers;
        }
        public void AddStatModifier(string modifier)
        {
            StatModifiers.Add(modifier);
        }
        public void RemoveStatModifier(string modifier)
        {
            StatModifiers.Remove(modifier);
        }
        public List<Enchantment> GetEnchantments()
        {
            return Enchantments;
        }
        public void AddEnchantment(Enchantment enchant)
        {
            Enchantments.Add(enchant);
        }
        public void RemoveEnchantment(Enchantment enchant)
        {
            Enchantments.Remove(enchant);
        }
    }
}
