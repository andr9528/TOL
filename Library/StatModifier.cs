using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class StatModifier
    {
        
        List<string> StatModifiers = new List<string>();

        public List<string> GetStatModifiers()
        {
            return StatModifiers;
        }
        /// <summary>
        /// String input Format:
        /// First a short for what too add to.
        /// Then a ¤, which will be used to split at.
        /// Then a value which will be added/removed depending on where that modifier is. 
        /// 
        /// Example:
        /// HP¤40 -> Will add/remove 40 hp.
        ///
        /// Valid Shorts: 
        ///  -> Hp -> Health Point, Does not accept decimal number
        ///  -> Mp -> Mana Point, Does not accept decimal number
        ///  -> Hps -> Health per second, Does accept decimal number
        ///  -> Mps -> Mana per second, Does accept decimal number
        ///  -> Dc -> Dodge Chance, Does accept decimal number
        ///  -> Bc -> Block Chance, Does accept decimal number
        ///  -> Prot -> Protection, Does not accept decimal number
        ///  -> Cc -> Critical Chance, Does accept decimal number
        ///  -> Cdm -> Critical Damage multiplier, Does accept decimal number
        ///  -> MinDam -> Minimum Damage, Does not accept decimal number
        ///  -> MaxDam -> Maximum damage, Does not accept decimal number
        ///  -> As -> Attack Speed, Does accept decimal number
        /// </summary>
        public void AddStatModifier(string modifier)
        {
            StatModifiers.Add(modifier);
        }
        /// <summary>
        /// String input Format:
        /// First a short for what too add to.
        /// Then a ¤, which will be used to split at.
        /// Then a value which will be added/removed depending on where that modifier is. 
        /// 
        /// For this method the string needs to already exist in the list of Modifiers
        /// 
        /// Example:
        /// HP¤40 -> Will add/remove 40 hp.
        ///
        /// Valid Shorts: 
        ///  -> Hp -> Health Point, Does not accept decimal number
        ///  -> Mp -> Mana Point, Does not accept decimal number
        ///  -> Hps -> Health per second, Does accept decimal number
        ///  -> Mps -> Mana per second, Does accept decimal number
        ///  -> Dc -> Dodge Chance, Does accept decimal number
        ///  -> Bc -> Block Chance, Does accept decimal number
        ///  -> Prot -> Protection, Does not accept decimal number
        ///  -> Cc -> Critical Chance, Does accept decimal number
        ///  -> Cdm -> Critical Damage multiplier, Does accept decimal number
        ///  -> MinDam -> Minimum Damage, Does not accept decimal number
        ///  -> MaxDam -> Maximum damage, Does not accept decimal number
        ///  -> As -> Attack Speed, Does accept decimal number
        /// </summary>
        public void RemoveStatModifier(string modifier)
        {
            StatModifiers.Remove(modifier);
        }
    }
}
