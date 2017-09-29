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
        

        public List<Enchantment> GetEnchantments()
        {
            return Enchantments;
        }
        public void Enchant(Enchantment enchant)
        {
            Enchantments.Add(enchant);
        }
        public void Disenchant(Enchantment enchant)
        {
            Enchantments.Remove(enchant);
        }
        public Equipment()
        {

        }
    }
}
