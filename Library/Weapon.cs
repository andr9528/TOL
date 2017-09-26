using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Weapon : Equipment
    {
        public int BlockChance { get; internal set; }
        public int MinimumDamage { get; internal set; }
        public int MaximumDamage { get; internal set; }

    }
}
