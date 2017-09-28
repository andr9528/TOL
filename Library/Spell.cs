using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Spell : StatModifier
    {
        /*
         * Future changes:
         * Allow a spell to have multiple types,
         * I.E it deals a chunk of dmaage and applies a DoT
         * Or other combos like that
         */

        public enum ValidTypes { Damage, DoT, Buff, Debuff, Heal}
        public enum ValidTargets { Enemy, Self}
        public enum ValidSkillNames { WildMagic, InfernoMagic, BlizzMagic, SkyMagic}

        public string Type { get; internal set; }
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
        public string SkillName { get; internal set; }
        public string Name { get; internal set; }
        public int XpPerCast { get; internal set; }
        /// <summary>
        /// Call as the last thing in the constructer
        /// </summary>
        private void DetermineXpPerCast()
        {
            switch (Type)
            {
                case "Damage":
                    XpPerCast = Effect;
                    break;
                case "Heal":
                    XpPerCast = Effect;
                    break;
                case "DoT":
                    XpPerCast = Effect * Duration;
                    break;
                case "Debuff":
                    XpPerCast = XpForBuffTypes();
                    break;
                case "Buff":
                    XpPerCast = XpForBuffTypes();
                    break;
                default:
                    break;
            }
        }
        private int XpForBuffTypes()
        {
            int output = 0;
            int counter = 0;
            double combinedStats = 0.00;

            foreach (string modifier in GetStatModifiers())
            {
                string[] split = modifier.Split('¤');

                double.TryParse(split[1], out double temp);

                combinedStats += temp;
                counter++;
            }

            output = (int)Math.Floor(combinedStats / counter);
            return output;
        }

        public Spell(ValidTargets target, ValidTypes type, ValidSkillNames skillName,
            int manacost, string name, int effect = 0, int duration = 0, List<Tuple<ValidShorts, string>> modifiers = null)
        {
            Target = target.ToString();
            Type = type.ToString();
            SkillName = skillName.ToString();
            ManaCost = manacost;
            Name = name;
            Effect = effect;
            Duration = duration;

            if (modifiers != null)
            {
                foreach (Tuple<ValidShorts, string> mod in modifiers)
                {
                    string compound = mod.Item1.ToString() + "¤" + mod.Item2;
                    AddStatModifier(compound);
                }
            }

            DetermineXpPerCast();
        }
    }
}
