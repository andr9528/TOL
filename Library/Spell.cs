using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Spell : StatModifier
    {
        /// <summary>
        /// Valid Types: Damage, DoT, Buff, Debuff, Heal
        /// </summary>
        public string Type { get; internal set; }
        /// <summary>
        /// Valid Targets: Enemy & Self
        /// </summary>
        public string Target { get; internal set; } 
        /// <summary>
        /// For DoT's this is the Damage it will deal per tick of damage.
        /// For Damage this is the Damage it will deal flat out.
        /// For Heal this is the amount of Health to return.
        /// </summary>
        public int Effect { get; internal set; }
        /// <summary>
        /// A Dot/Buff/Debuff needs this value to be more then 1.
        /// Whereas a Damage/Heal spells needs this to be 0
        /// </summary>
        public int Duration { get; internal set; }
        public int ManaCost { get; internal set; }
    }
}
