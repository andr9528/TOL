using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Equipment : StatModifier
    {
        
        List<Enchantment> Enchantments = new List<Enchantment>();
        public string EquipementSlot { get; internal set; }
        public string Name { get; internal set; }
        public string SkillName { get; internal set; } // Valid values: Archery, OneHanded, TwoHanded, LightArmor, HeavyArmor, None
        public string Rarity { get; internal set; } // 60% Common, 20% Uncommon, 10% Rare, 6% Epic, 3% Legendary, 1% Godlike

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
