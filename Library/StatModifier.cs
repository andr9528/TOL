using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class StatModifier
    {
        public enum ValidShorts { Hp, Mp, Hps, Mps, Dc, Bc, Prot, Cc, Cdm, MinDam, MaxDam, As}
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
