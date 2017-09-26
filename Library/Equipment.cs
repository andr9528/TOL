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
         * Short for what too add to.
         * Then a ¤, which will be used to split at.
         * Then a value which will be added to the stat mentioned before. 
         * 
         * Example:
         * HP¤40 -> Will add 40 hp to the wearer
         * 
         * Valid Shorts: 
         *  -> Hp -> Health Point, Does not accept decimal number
         *  -> Mp -> Mana Point, Does not accept decimal number
         *  -> Hps -> Health per second, Does accept decimal number
         *  -> Mps -> Mana per second, Does accept decimal number
         *  -> Dc -> Dodge Chance, Does accept decimal number
         *  -> Bc -> Block Chance, Does accept decimal number
         *  -> Prot -> Protection, Does not accept decimal number
         *  -> Cc -> Critical Chance, Does accept decimal number
         *  -> Cdm -> Critical Damage multiplier, Does accept decimal number
         *  -> MinDam -> Minimum Damage, Does not accept decimal number
         *  -> MaxDam -> Maximum damage, Does not accept decimal number
         *  -> As -> Attack Speed, Does accept decimal number
        */
        List<string> StatModifiers = new List<string>();
        List<Enchantment> Enchantments = new List<Enchantment>();
        public string EquipementSlot { get; internal set; }
        public string Name { get; internal set; }
        public string SkillName { get; internal set; } // Valid values: Archery, OneHanded, TwoHanded, LightArmor, HeavyArmor, None
        public string Quality { get; internal set; }
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
