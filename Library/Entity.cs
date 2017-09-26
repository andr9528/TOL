using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Entity
    {
        #region Skills
        Skill archery = new Skill(0, "Archery");
        Skill oneHanded = new Skill(1, "OneHanded");
        Skill twoHanded = new Skill(2, "TwoHanded");
        Skill lightArmor = new Skill(3, "LightArmor");
        Skill heavyArmor = new Skill(4, "HeavyArmor");
        Skill stealth = new Skill(5, "Stealth");
        Skill agility = new Skill(6, "Agility");
        Skill smithing = new Skill(7, "Smithing");
        Skill enchanting = new Skill(8, "Enchanting");
        Skill alchemy = new Skill(9, "Alchemy");
        Skill blocking = new Skill(10, "Blocking");
        Skill wildMagic = new Skill(11, "WildMagic");
        Skill infernoMagic = new Skill(12, "InfernoMagic");
        Skill blizzMagic = new Skill(13, "BlizzMagic");
        Skill skymagic = new Skill(14, "Skymagic");
        Skill pureMagic = new Skill(15, "PureMagic");

        public Skill Archery { get { return archery; } set { archery = value; } }
        public Skill OneHanded { get { return oneHanded; } set { oneHanded = value; } }
        public Skill TwoHanded { get { return twoHanded; } set { twoHanded = value; } }
        public Skill LightArmor { get { return lightArmor; } set { lightArmor = value; } }
        public Skill HeavyArmor { get { return heavyArmor; } set { heavyArmor = value; } }
        public Skill Stealth { get { return stealth; } set { stealth = value; } }
        public Skill Agility { get { return agility; } set { agility = value; } }
        public Skill Smithing { get { return smithing; } set { smithing = value; } }
        public Skill Enchanting { get { return enchanting; } set { enchanting = value; } }
        public Skill Alchemy { get { return alchemy; } set { alchemy = value; } }
        public Skill Blocking { get { return blocking; } set { blocking = value; } }
        public Skill WildMagic { get { return wildMagic; } set { wildMagic = value; } }
        public Skill InfernoMagic { get { return infernoMagic; } set { infernoMagic = value; } }
        public Skill BlizzMagic { get { return blizzMagic; } set { blizzMagic = value; } }
        public Skill Skymagic { get { return skymagic; } set { skymagic = value; } }
        public Skill PureMagic { get { return pureMagic; } set { pureMagic = value; } }
        #endregion

        List<Weapon> Weapons = new List<Weapon>() { };
        List<Armor> Armors = new List<Armor>() { };
        int level;
        public string Name { get; internal set; }
        public int Level
        {
            get
            {
                return level;
            }
            internal set
            {
                level = value;
                UpdateStats();
            }
        }
        public int CurrentHealth { get; internal set; }
        public int MaxHealth { get; internal set; }
        public double HealthRegeneration { get; internal set; } 
        public int CurrentMana { get; internal set; }
        public int MaxMana { get; internal set; }
        public double ManaRegeneration { get; internal set; }

        public void UpdateLevel()
        {
            Level = (Archery.Level + OneHanded.Level + TwoHanded.Level + LightArmor.Level
                + HeavyArmor.Level + Stealth.Level + Agility.Level + Smithing.Level
                + Enchanting.Level + Alchemy.Level + Blocking.Level + WildMagic.Level
                + InfernoMagic.Level + BlizzMagic.Level + Skymagic.Level + PureMagic.Level) / 16;
        }
        public void UpdateStats()
        {
            MaxHealth = 90 + (10 * Level) * (LightArmor.Level / 100 * 2) * (HeavyArmor.Level / 100 * 2) * (Agility.Level / 100 * 2) * (Agility.Level / 100 * 2);
            MaxMana = 90 + (10 * Level) + (WildMagic.Level * 5) + (InfernoMagic.Level * 5) + (BlizzMagic.Level * 5) + (Skymagic.Level * 5) + (PureMagic.Level * 20);
            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;

            AddStatsFromArmors();
            AddStatsFromWeapons();

            HealthRegeneration = 5 + ((MaxHealth - CurrentHealth) / 100);
            ManaRegeneration = 5 + (MaxMana / 100) * (PureMagic.Level * 5);

            
        }
        internal void AddStatsFromArmors()
        {
            foreach (Armor armor in Armors)
            {
                if (armor != null)
                {
                    foreach (string modifier in armor.GetStatModifiers())
                    {
                        string[] splittet = modifier.Split('¤');
                        int parseInt = 0;
                        double parseDouble = 0.00;
                        bool parseResult = false;

                        switch (splittet[0])
                        {
                            case "Hp":
                                parseResult = int.TryParse(splittet[1], out parseInt);
                                MaxHealth += parseInt;
                                break;
                            case "Mp":
                                parseResult = int.TryParse(splittet[1], out parseInt);
                                MaxMana += parseInt;
                                break;
                            case "Hps":
                                parseResult = double.TryParse(splittet[1], out parseDouble);
                                HealthRegeneration += parseDouble;
                                break;
                            case "Mps":
                                parseResult = double.TryParse(splittet[1], out parseDouble);
                                ManaRegeneration += parseDouble;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        internal void AddStatsFromWeapons()
        {
            foreach (Weapon weapon in Weapons)
            {
                if (weapon != null)
                {
                    foreach (string modifier in weapon.GetStatModifiers())
                    {
                        string[] splittet = modifier.Split('¤');
                        int parseInt = 0;
                        double parseDouble = 0.00;
                        bool parseResult = false;

                        switch (splittet[0])
                        {
                            case "Hp":
                                parseResult = int.TryParse(splittet[1], out parseInt);
                                MaxHealth += parseInt;
                                break;
                            case "Mp":
                                parseResult = int.TryParse(splittet[1], out parseInt);
                                MaxMana += parseInt;
                                break;
                            case "Hps":
                                parseResult = double.TryParse(splittet[1], out parseDouble);
                                HealthRegeneration += parseDouble;
                                break;
                            case "Mps":
                                parseResult = double.TryParse(splittet[1], out parseDouble);
                                ManaRegeneration += parseDouble;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        
        public void RegenMana()
        {
            if (CurrentMana < MaxMana)
            {
                if (CurrentMana + ManaRegeneration > MaxMana)
                {
                    CurrentMana = MaxMana;
                }
                else
                {
                    CurrentMana += (int)ManaRegeneration;
                }
            }
        }
        public void RegenHealth()
        {
            if (CurrentHealth < MaxHealth)
            {
                if (CurrentHealth + HealthRegeneration > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
                else
                {
                    CurrentHealth += (int)HealthRegeneration;
                }
            }
        }
    }
}
