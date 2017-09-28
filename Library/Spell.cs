using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Spell : StatModifier
    {
        public string Type { get; internal set; } // Valid Types: Damage, DoT, Buff, Debuff, Heal
        public string Target { get; internal set; } // Valid Targets: Enemy & Self
        /// <summary>
        /// For DoT's this is the damage it will deal per tick of damage.
        /// For Damage this is the Damage it will deal flat out.
        /// For Heal this is the amount of health to return.
        /// </summary>
        public int Effect { get; internal set; }
        public int Duration { get; internal set; } // A Dot/Buff/Debuff needs this value to be more then 1, whereas a Damage/Heal spells needs this to be 0
        public int ManaCost { get; internal set; }
    }
}
