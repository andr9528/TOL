using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Equipment : StatModifier
    {
        public enum ValidEquipmentSlot { Head, Shoulder, Gloves, Braces, Chestplate, Leggings, Belt, Boots, MainHand, OffHand, Ranged, Amulet, LeftRing, RightRing, Empty }
        public enum ValidSkillNames { Archery, OneHanded, TwoHanded, LightArmor, HeavyArmor, Blocking, Empty }

        List<string> WeaponSkillNames = new List<string>() { "Archery", "OneHanded", "TwoHanded", "Blocking"};
        List<string> ArmorSkillNames = new List<string>() { "LightArmor", "HeavyArmor" };
        List<string> SlotsForWeapons = new List<string>() { "MainHand", "OffHand", "Ranged" };
        List<string> SlotForArmors = new List<string>() { "Head", "Shoulder", "Gloves", "Braces", "Chestplate", "Leggings", "Belt", "Boots" };

        List<Enchantment> Enchantments = new List<Enchantment>();
        public ValidEquipmentSlot EquipmentSlot { get; internal set; }
        public string Name { get; internal set; }
        public ValidSkillNames SkillName { get; internal set; }
        private string EquipmentTracker { get; set; } // Holds what this is -> if it is a Axe, Sword, Shield, Chestplate, Helmet etc...
        private int MaximumCountOfStats
        {
            get
            {
                return (int)Rarity + 5;
            }
        }
        private int MinimumCountOfStats
        {
            get
            {
                return (int)Rarity + 3;
            }
        }

        public List<Enchantment> GetEnchantments()
        {
            return Enchantments;
        }
        public void Enchant(Enchantment enchant)
        {
            Enchantments.Add(enchant);
        }
        public void Disenchant(Enchantment enchant)
        {
            Enchantments.Remove(enchant);
        }
        public Equipment(Rarities rarity = Rarities.Empty, ValidEquipmentSlot slot = ValidEquipmentSlot.Empty,
            ValidSkillNames skillName = ValidSkillNames.Empty, string name = "", 
            List<Tuple<ValidShorts, double>> modifiers = null)
        {
            if (rarity != Rarities.Empty)
            {
                Rarity = rarity;
            }
            else
            {
                SetRarity();
            }
            if (slot != ValidEquipmentSlot.Empty)
            {
                EquipmentSlot = slot;
            }
            else
            {
                RandomSlot();
            }
            if (skillName != ValidSkillNames.Empty)
            {
                SkillName = skillName;
            }
            else
            {
                if (SlotsForWeapons.Contains(EquipmentSlot.ToString()))
                {
                    DetermineWeaponSkill();
                }
                else if (SlotForArmors.Contains(EquipmentSlot.ToString()))
                {
                    DetermineArmorSkill();
                }
            }
            if (name != "")
            {
                Name = name;
            }
            else
            {
                GenerateName();
            }
            if (modifiers != null)
            {
                AddModifiers(modifiers);
            }
            else
            {
                GenerateModifiers();
            }
        }
        private void AddModifiers(List<Tuple<ValidShorts, double>> modifiers)
        {
            foreach (Tuple<ValidShorts, double> mod in modifiers)
            {
                double temp = mod.Item2 * RarityModifiers[(int)Rarity];
                AddStatModifier(Tuple.Create(mod.Item1, temp));
            }
        }

        private void GenerateModifiers()
        {
            List<Tuple<ValidShorts, double>> modifiers = new List<Tuple<ValidShorts, double>>();
            int modifierCounter = Repo.Random.Next(MinimumCountOfStats, MaximumCountOfStats);
            int aboveOne = 0;
            int belowOne = 0;
            double statRoll = aboveOne + (belowOne / 100);

            switch (EquipmentTracker)
            {
                case "Shortbow":
                    aboveOne = Repo.Random.Next(25, 50);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                    aboveOne = Repo.Random.Next(51, 75);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                    modifiers.Add(Tuple.Create(ValidShorts.As, 0.30));
                    modifierCounter -= 3;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Crossbow":
                    aboveOne = Repo.Random.Next(45, 90);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                    aboveOne = Repo.Random.Next(91, 135);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                    modifierCounter -= 2;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Longbow":
                    aboveOne = Repo.Random.Next(35, 70);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                    aboveOne = Repo.Random.Next(71, 105);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                    modifiers.Add(Tuple.Create(ValidShorts.As, 0.15));
                    modifierCounter -= 3;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Dagger":
                    aboveOne = Repo.Random.Next(15, 30);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                    aboveOne = Repo.Random.Next(31, 45);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                    modifiers.Add(Tuple.Create(ValidShorts.As, 0.30));
                    modifierCounter -= 3;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Sword":

                    switch (SkillName)
                    {
                        case ValidSkillNames.OneHanded:
                            aboveOne = Repo.Random.Next(25, 50);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            aboveOne = Repo.Random.Next(51, 75);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            modifiers.Add(Tuple.Create(ValidShorts.As, 0.30));
                            break;
                        case ValidSkillNames.TwoHanded:
                            aboveOne = Repo.Random.Next(45, 90);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            aboveOne = Repo.Random.Next(91, 135);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            modifiers.Add(Tuple.Create(ValidShorts.As, 0.20));
                            break;
                        default:
                            break;
                    }
                    modifierCounter -= 3;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Axe":

                    switch (SkillName)
                    {
                        case ValidSkillNames.OneHanded:
                            aboveOne = Repo.Random.Next(30, 60);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            aboveOne = Repo.Random.Next(61, 90);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            modifiers.Add(Tuple.Create(ValidShorts.As, 0.20));
                            break;
                        case ValidSkillNames.TwoHanded:
                            aboveOne = Repo.Random.Next(50, 100);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            aboveOne = Repo.Random.Next(101, 150);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            modifiers.Add(Tuple.Create(ValidShorts.As, 0.10));
                            break;
                        default:
                            break;
                    }
                    modifierCounter -= 3;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Mace":
                    switch (SkillName)
                    {
                        case ValidSkillNames.OneHanded:
                            aboveOne = Repo.Random.Next(35, 70);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            aboveOne = Repo.Random.Next(71, 105);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            modifiers.Add(Tuple.Create(ValidShorts.As, 0.10));
                            modifierCounter--;
                            break;
                        case ValidSkillNames.TwoHanded:
                            aboveOne = Repo.Random.Next(55, 110);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            aboveOne = Repo.Random.Next(111, 165);
                            statRoll = aboveOne + (belowOne / 100);
                            modifiers.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            break;
                        default:
                            break;
                    }
                    modifierCounter -= 2;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 9, 10, 11 }));
                    break;
                case "Shield":
                    belowOne = Repo.Random.Next(0, 99);
                    aboveOne = Repo.Random.Next(1, 10);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Bc, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 5 }));
                    break;
                case "Helmet":
                    aboveOne = Repo.Random.Next(1, 25);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Shoulderpads":
                    aboveOne = Repo.Random.Next(1, 15);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Gloves":
                    aboveOne = Repo.Random.Next(1, 10);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Braces":
                    aboveOne = Repo.Random.Next(1, 15);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Chestplate":
                    aboveOne = Repo.Random.Next(1, 60);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Leggings":
                    aboveOne = Repo.Random.Next(1, 50);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Belt":
                    aboveOne = Repo.Random.Next(1, 10);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Boots":
                    aboveOne = Repo.Random.Next(1, 20);
                    statRoll = aboveOne + (belowOne / 100);
                    modifiers.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                    modifierCounter--;
                    modifiers.AddRange(RandomModifiers(modifierCounter, new List<int>() { 6 }));
                    break;
                case "Amulet":
                    modifiers.AddRange(RandomModifiers(modifierCounter));
                    break;
                case "Ring":
                    modifiers.AddRange(RandomModifiers(modifierCounter));
                    break;
                default:
                    break;
            }
            AddModifiers(modifiers);
        }

        private List<Tuple<ValidShorts, double>> RandomModifiers(int modifierCounter, List<int> disregard = null)
        {
            if (disregard == null)
            {
                disregard = new List<int>();
            }
            int statPicker;
            List<Tuple<ValidShorts, double>> output = new List<Tuple<ValidShorts, double>>();
            while (modifierCounter > 0)
            {
                statPicker = Repo.Random.Next(0, Enum.GetNames(typeof(ValidShorts)).Length);
                int aboveOne = 0;
                int belowOne = 0;
                double statRoll = aboveOne + (belowOne / 100);

                if (!disregard.Contains(statPicker))
                {
                    switch ((ValidShorts)statPicker)
                    {
                        case ValidShorts.Hp:
                            aboveOne = Repo.Random.Next(1, 150);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Hp, statRoll));
                            break;
                        case ValidShorts.Mp:
                            aboveOne = Repo.Random.Next(1, 100);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Mp, statRoll));
                            break;
                        case ValidShorts.Hps:
                            belowOne = Repo.Random.Next(0, 99);
                            aboveOne = Repo.Random.Next(1, 15);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Hps, statRoll));
                            break;
                        case ValidShorts.Mps:
                            belowOne = Repo.Random.Next(0, 99);
                            aboveOne = Repo.Random.Next(1, 10);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Mps, statRoll));
                            break;
                        case ValidShorts.Dc:
                            belowOne = Repo.Random.Next(0, 99);
                            aboveOne = Repo.Random.Next(1, 3);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Dc, statRoll));
                            break;
                        case ValidShorts.Bc:
                            belowOne = Repo.Random.Next(0, 99);
                            aboveOne = Repo.Random.Next(1, 3);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Bc, statRoll));
                            break;
                        case ValidShorts.Prot:
                            aboveOne = Repo.Random.Next(1, 25);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Prot, statRoll));
                            break;
                        case ValidShorts.Cc:
                            belowOne = Repo.Random.Next(0, 99);
                            aboveOne = Repo.Random.Next(1, 5);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Cc, statRoll));
                            break;
                        case ValidShorts.Cdm:
                            belowOne = Repo.Random.Next(1, 50);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.Cdm, statRoll));
                            break;
                        case ValidShorts.MinDam:
                            aboveOne = Repo.Random.Next(1, 20);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.MinDam, statRoll));
                            break;
                        case ValidShorts.MaxDam:
                            aboveOne = Repo.Random.Next(1, 30);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.MaxDam, statRoll));
                            break;
                        case ValidShorts.As:
                            belowOne = Repo.Random.Next(1, 10);
                            statRoll = aboveOne + (belowOne / 100);
                            output.Add(Tuple.Create(ValidShorts.As, statRoll));
                            break;
                        default:
                            break;
                    }
                    disregard.Add(statPicker);
                    modifierCounter--;
                }
            }
            return output;
        }

        private void DetermineArmorSkill()
        {
            int randomSkill = Repo.Random.Next(0, 1);

            if (randomSkill == 0)
            {
                SkillName = ValidSkillNames.LightArmor;
            }
            else if (randomSkill == 1)
            {
                SkillName = ValidSkillNames.HeavyArmor;
            }
        }

        private void DetermineWeaponSkill()
        {
            if (EquipmentSlot.ToString() == "Ranged")
            {
                SkillName = ValidSkillNames.Archery;
            }
            else if (EquipmentSlot.ToString() == "MainHand")
            {
                int randomSkill = Repo.Random.Next(0, 1);

                if (randomSkill == 0)
                {
                    SkillName = ValidSkillNames.OneHanded;
                }
                else if (randomSkill == 1)
                {
                    SkillName = ValidSkillNames.TwoHanded;
                }
            }
            else if (EquipmentSlot.ToString() == "OffHand")
            {
                int randomSkill = Repo.Random.Next(0, 1);

                if (randomSkill == 0)
                {
                    SkillName = ValidSkillNames.OneHanded;
                }
                else if (randomSkill == 1)
                {
                    SkillName = ValidSkillNames.Blocking;
                }
            }
        }

        private void GenerateName()
        {
            Name += Rarity.ToString() + " ";

            int randomWeapon;
            List<string> possibleWeapons;

            switch (SkillName)
            {
                case ValidSkillNames.Archery:
                    randomWeapon = Repo.Random.Next(0, 2);
                    possibleWeapons = new List<string>() { "Shortbow", "Crossbow", "Longbow" };
                    EquipmentTracker = possibleWeapons[randomWeapon];
                    Name += EquipmentTracker;
                    break;
                case ValidSkillNames.OneHanded:
                    AddToNameFromSlot();
                    randomWeapon = Repo.Random.Next(0, 3);
                    possibleWeapons = new List<string>() { "Dagger", "Sword", "Axe", "Mace" };
                    EquipmentTracker = possibleWeapons[randomWeapon];
                    Name += EquipmentTracker;
                    break;
                case ValidSkillNames.TwoHanded:
                    AddToNameFromSlot();
                    randomWeapon = Repo.Random.Next(0, 2);
                    possibleWeapons = new List<string>() { "Sword", "Axe", "Mace" };
                    EquipmentTracker = possibleWeapons[randomWeapon];
                    Name += EquipmentTracker;
                    break;
                case ValidSkillNames.LightArmor:
                    Name += "Light ";
                    AddToNameFromSlot();
                    break;
                case ValidSkillNames.HeavyArmor:
                    Name += "Heavy ";
                    AddToNameFromSlot();
                    break;
                case ValidSkillNames.Blocking:
                    EquipmentTracker = "Shield";
                    Name += "Shield";
                    break;
                default:
                    break;
            }
        }
        private void AddToNameFromSlot()
        {
            switch (EquipmentSlot)
            {
                case ValidEquipmentSlot.Head:
                    EquipmentTracker = "Helmet";
                    Name += "Helmet";
                    break;
                case ValidEquipmentSlot.Shoulder:
                    EquipmentTracker = "Shoulderpads";
                    Name += "Shoulderpads";
                    break;
                case ValidEquipmentSlot.Gloves:
                    EquipmentTracker = "Gloves";
                    Name += "Gloves";
                    break;
                case ValidEquipmentSlot.Braces:
                    EquipmentTracker = "Braces";
                    Name += "Braces";
                    break;
                case ValidEquipmentSlot.Chestplate:
                    EquipmentTracker = "Chestplate";
                    Name += "Chestplate";
                    break;
                case ValidEquipmentSlot.Leggings:
                    EquipmentTracker = "Leggings";
                    Name += "Leggings";
                    break;
                case ValidEquipmentSlot.Belt:
                    EquipmentTracker = "Belt";
                    Name += "Belt";
                    break;
                case ValidEquipmentSlot.Boots:
                    EquipmentTracker = "Boots";
                    Name += "Boots";
                    break;
                case ValidEquipmentSlot.MainHand:
                    Name += "Mainhand ";
                    break;
                case ValidEquipmentSlot.OffHand:
                    Name += "Offhand ";
                    break;
                case ValidEquipmentSlot.Amulet:
                    EquipmentTracker = "Amulet";
                    Name += "Amulet";
                    break;
                case ValidEquipmentSlot.LeftRing:
                    EquipmentTracker = "Ring";
                    Name += "Left Ring";
                    break;
                case ValidEquipmentSlot.RightRing:
                    EquipmentTracker = "Ring";
                    Name += "Right Ring";
                    break;
                default:
                    break;
            }
        }

        private void RandomSlot()
        {
            int randomSlot = Repo.Random.Next(0, Enum.GetNames(typeof(ValidEquipmentSlot)).Length-1);

            EquipmentSlot = (ValidEquipmentSlot)randomSlot;
        }
    }
}
