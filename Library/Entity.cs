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
                if (value > Level)
                {
                    level = value;
                    UpdateStats();
                }
            }
        }
        #region Equipment

        Equipment head;
        Equipment shoulder;
        Equipment gloves;
        Equipment braces;
        Equipment chestplate;
        Equipment leggings;
        Equipment belt;
        Equipment boots;
        Equipment mainHand;
        Equipment offHand;
        Equipment ranged;
        Equipment amulet;
        Equipment leftRing;
        Equipment rightRing;

        public Equipment Head { get { return head; } set { head = value; } }
        public Equipment Shoulder { get { return shoulder; } set { shoulder = value; } }
        public Equipment Gloves { get { return gloves; } set { gloves = value; } }
        public Equipment Braces { get { return braces; } set { braces = value; } }
        public Equipment Chestplate { get { return chestplate; } set { chestplate = value; } }
        public Equipment Leggings { get { return leggings; } set { leggings = value; } }
        public Equipment Belt { get { return belt; } set { belt = value; } }
        public Equipment Boots { get { return boots; } set { boots = value; } }
        public Equipment MainHand { get { return mainHand; } set { mainHand = value; } }
        public Equipment OffHand { get { return offHand; } set { offHand = value; } }
        public Equipment Ranged { get { return ranged; } set { ranged = value; } }
        public Equipment Amulet { get { return amulet; } set { amulet = value; } }
        public Equipment LeftRing { get { return leftRing; } set { leftRing = value; } }
        public Equipment RightRing { get { return rightRing; } set { rightRing = value; } }

        List<Equipment> Equiped;

        public void CollectEquipment()
        {
            Equiped = new List<Equipment>()
            {
                Head, Shoulder, Gloves, Braces,
                Chestplate, Leggings, Belt, Boots,
                MainHand, OffHand, Ranged, Amulet,
                LeftRing, RightRing
            };
        }
        #endregion

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

        #region Stats
        public double DodgeChance { get; internal set; }
        public double BlockChance { get; internal set; }
        public int Protection { get; internal set; }
        public double CriticalChance { get; internal set; }
        public double CriticalDamageMultiplier { get; internal set; }
        public int MinimumDamage { get; internal set; }
        public int MaximumDamage { get; internal set; }
        public double AttackSpeed { get; internal set; }

        public int CurrentHealth { get; internal set; }
        public int MaxHealth { get; internal set; }
        public double HealthRegeneration { get; internal set; } 
        public int CurrentMana { get; internal set; }
        public int MaxMana { get; internal set; }
        public double ManaRegeneration { get; internal set; }

        public void UpdateStats()
        {
            CollectEquipment();

            MaxHealth = 90 + (10 * Level);
            MaxMana = 90 + (10 * Level) + (WildMagic.Level * 5) + (InfernoMagic.Level * 5) + (BlizzMagic.Level * 5) + (Skymagic.Level * 5) + (PureMagic.Level * 20);
            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;

            DodgeChance = 5 + (Agility.Level / 5);
            BlockChance = 0 + (Blocking.Level / 5);
            Protection = 0 + (LightArmor.Level / 25) + (HeavyArmor.Level / 15);
            CriticalChance = 5 + (Archery.Level / 10) + (OneHanded.Level / 10) + (TwoHanded.Level / 10);
            CriticalDamageMultiplier = 2;
            MinimumDamage = 1 + (1 * Level);
            MaximumDamage = 3 + (2 * Level);
            AttackSpeed = 1;

            AddStatsFromEquipment();
            //AddStatsFromEnchantments();

            MinimumDamage = (int)Math.Floor(MinimumDamage * (1 + (Archery.Level / 40))
                * (1 + (OneHanded.Level / 40)) * (1 + (TwoHanded.Level / 40))
                * (1 + (Agility.Level / 50)) * AttackSpeed);

            MaximumDamage = (int)Math.Floor(MaximumDamage * (1 + (Archery.Level / 30))
                * (1 + (OneHanded.Level / 30)) * (1 + (TwoHanded.Level / 30))
                * (1 + (Stealth.Level / 40)) * AttackSpeed);

            MaxHealth = MaxHealth * (1 + (LightArmor.Level / 50)) * (1 + (HeavyArmor.Level / 50))
                * (1 + (Agility.Level / 50)) * (1 + (Blocking.Level / 50));

            HealthRegeneration = 5 + (MaxHealth / 100);
            ManaRegeneration = 5 + (MaxMana / 100) * (PureMagic.Level * 2.5);

            if (MinimumDamage > MaximumDamage)
            {
                MinimumDamage = MaximumDamage;
            }

        }

        private void AddStatsFromEnchantments()
        {
            throw new NotImplementedException();
        }

        internal void AddStatsFromEquipment()
        {
            foreach (Equipment equiped in Equiped)
            {
                if (equiped != null)
                {
                    foreach (string modifier in equiped.GetStatModifiers())
                    {
                        string[] split = modifier.Split('¤');
                        int parseInt = 0;
                        double parseDouble = 0.00;
                        bool parseResult = false;

                        switch (split[0])
                        {
                            case "Hp":
                                parseResult = int.TryParse(split[1], out parseInt);
                                MaxHealth += parseInt;
                                break;
                            case "Mp":
                                parseResult = int.TryParse(split[1], out parseInt);
                                MaxMana += parseInt;
                                break;
                            case "Prot":
                                parseResult = int.TryParse(split[1], out parseInt);
                                Protection += parseInt;
                                break;
                            case "MinDam":
                                parseResult = int.TryParse(split[1], out parseInt);
                                MinimumDamage += parseInt;
                                break;
                            case "MaxDam":
                                parseResult = int.TryParse(split[1], out parseInt);
                                MaximumDamage += parseInt;
                                break;
                            case "Hps":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                HealthRegeneration += parseDouble;
                                break;
                            case "Mps":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                ManaRegeneration += parseDouble;
                                break;
                            case "Dc":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                DodgeChance += parseDouble;
                                break;
                            case "Bc":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                BlockChance += parseDouble;
                                break;
                            case "Cc":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                CriticalChance += parseDouble;
                                break;
                            case "Cdm":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                CriticalDamageMultiplier += parseDouble;
                                break;
                            case "As":
                                parseResult = double.TryParse(split[1], out parseDouble);
                                AttackSpeed += parseDouble;
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
        #endregion
        public void UpdateLevel()
        {
            Level = (Archery.Level + OneHanded.Level + TwoHanded.Level + LightArmor.Level
                + HeavyArmor.Level + Stealth.Level + Agility.Level + Smithing.Level
                + Enchanting.Level + Alchemy.Level + Blocking.Level + WildMagic.Level
                + InfernoMagic.Level + BlizzMagic.Level + Skymagic.Level + PureMagic.Level) / 16;
        }
        
    }
}
