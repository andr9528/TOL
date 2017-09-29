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
        List<Tuple<ValidShorts, double>> StatModifiers = new List<Tuple<ValidShorts, double>>();

        public List<Tuple<ValidShorts, double>> GetStatModifiers()
        {
            return StatModifiers;
        }
        public void AddStatModifier(Tuple<ValidShorts, double> modifier)
        {
            StatModifiers.Add(modifier);
        }
        public void RemoveStatModifier(int index)
        {
            StatModifiers.RemoveAt(index);
        }
    }
}
