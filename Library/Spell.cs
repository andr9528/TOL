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
         * I.E it deals a chunk of damage and then applies a DoT
         * Or other combos like that
         */

        public enum ValidTypes { Damage, DoT, Buff, Debuff, Heal}
        public enum ValidTargets { Enemy, Self}
        public enum ValidSkillNames { WildMagic, InfernoMagic, BlizzMagic, SkyMagic}

        public ValidTypes Type { get; internal set; }
        public ValidTargets Target { get; internal set; }
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
        public ValidSkillNames SkillName { get; internal set; }
        public string Name { get; internal set; }
        public int XpPerCast { get; internal set; }
        /// <summary>
        /// Call as the last thing in the constructer
        /// </summary>
        private void DetermineXpPerCast()
        {
            switch (Type)
            {
                case ValidTypes.Damage:
                    XpPerCast = Effect;
                    break;
                case ValidTypes.Heal:
                    XpPerCast = Effect;
                    break;
                case ValidTypes.DoT:
                    XpPerCast = Effect * Duration;
                    break;
                case ValidTypes.Debuff:
                    XpPerCast = XpForBuffTypes();
                    break;
                case ValidTypes.Buff:
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

            foreach (Tuple<ValidShorts, double> modifier in GetStatModifiers())
            {
                combinedStats += modifier.Item2;
                counter++;
            }

            output = (int)Math.Floor(combinedStats / counter);
            return output;
        }

        public Spell(ValidTargets target, ValidTypes type, ValidSkillNames skillName,
            int manacost, string name, int effect = 0, int duration = 0, 
            List<Tuple<ValidShorts, double>> modifiers = null, Rarities rarity = Rarities.Empty)
        {
            if (rarity != Rarities.Empty)
            {
                Rarity = rarity;
            }
            else
            {
                SetRarity();
            }

            Target = target;
            Type = type;
            SkillName = skillName;
            ManaCost = manacost;
            Name = name;
            Effect = (int)Math.Floor(effect * RarityModifiers[(int)Rarity]);
            Duration = (int)Math.Floor(duration * RarityModifiers[(int)Rarity]);

            if (modifiers != null)
            {
                foreach (Tuple<ValidShorts, double> mod in modifiers)
                {
                    double temp = mod.Item2 * RarityModifiers[(int)Rarity];
                    AddStatModifier(Tuple.Create(mod.Item1, temp));
                }
            }
            

            DetermineXpPerCast();
        }
    }
}
