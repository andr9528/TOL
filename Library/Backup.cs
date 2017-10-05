using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library
{
    public static class Backup
    {
        /* 
        Save Format:
        General ->      Line 1 -> #,#,#,#
                            Value 1 is the Name of the Character
                            Value 2 is the int of Gender
                            Value 3 is the int of Desired Mythology
                            Value 4 is the ID of the God Parent
        Skills ->       Line 2 -> #,#¤...
                            Value 1 is the Level
                            Value 2 is the XpCurrent
                             ... Next skill in the list (split on ¤ within it)
        Equipment ->    Line 3 -> #,#,#,#,#(#,#)~...,#(#,#,#(#,#)~...)£)¤...
                            Value 1 is the Name of the item
                            Value 2 is the int of Rarity
                            Value 3 is the int of Equipment Slot
                            Value 4 is the int of Skill Name
                            Value 5 is the list of Stats on the Equipment (split on ~ within it)
                                Value 1 is the int of the Short
                                Value 2 is the stat modifier
                            Value 6 is the list of Enchantments (split on £ within it)
                                Value 1 is the Name of the enchantment
                                Value 2 is the Mana Regeneration Cost of the enchantment
                                Value 3 is the list of Stats on the Enchantment (split on ~ within it)
                                    Value 1 is the int of the Short
                                    Value 2 is the stat modifier
                            ... Next Equipment in the list (split on ¤ within it)
        Spells ->       Line 4 ->    #,#,#,#,#,#,#,#,#(#,#)~...¤...
                            Value 1 is Name of the spell
                            Value 2 is the int of Rarity
                            Value 3 is the int of Target
                            Value 4 is the int of Skill Name
                            Value 5 is the int of Type
                            Value 6 is the Mana Cost
                            Value 7 is the Duration
                            Value 8 is the Effect
                            Value 9 is the list of Stats on the Enchantment (split on ~ within it) -> if it is empty put in a -1 
                                    Value 1 is the int of the Short
                                    Value 2 is the stat modifier
                            ... Next Spell in the list (split on ¤ within it)
                                
             

        */
        public static void Save()
        {
            foreach (Player player in Repo.GetCharacters())
            {
                string line1 = "";
                string line2 = "";
                string line3 = "";
                string line4 = "";



                foreach (Skill skill in player.GetSkills())
                {
                    line2 += skill.ToStringBackup();
                    line2 += "¤";
                }
                line2 = line2.Substring(0, line2.Length - 1);
                line2 += "\n";








            }
        }
        public static void Load()
        {

        }
    }
}
