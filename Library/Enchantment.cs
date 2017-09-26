using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Enchantment
    {
        /*
         * for layout of StatModifiers refer to the Equipment Class
        */
        List<string> StatModifiers = new List<string>();

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
    }
}
