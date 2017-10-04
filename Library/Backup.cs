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
        General ->      Line 1 -> 
        Skills ->       Line 2 -> #,#¤...
                             Value 1 is the Level
                             Value 2 is the XpCurrent
                             ... Next skill in the list
        Equipment ->    Line 3 -> #,#,#,#,#(~(#,#),#()¤...
                            Value 1 is the Name
                            Value 2 is the int of Rarity
                            Value 3 is the int of Equipment Slot
                            Value 4 is the int of Skill Name
                            Value 5 is the list of Stats on the Equipment
                                Value 1 is the int of the Short
                                Value 2 is the stat modifier
                            Value 6 is the list of Enchantments
                                Value 1 is the list of Stats on the Enchantment
                               
        Spells ->       Line 4 ->    
             

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
