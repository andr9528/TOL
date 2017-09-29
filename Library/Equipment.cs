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

            switch (EquipmentTracker)
            {
                case "Shortbow":

                    break;
                case "Crossbow":

                    break;
                case "Longbow":

                    break;
                case "Dagger":

                    break;
                case "Sword":

                    break;
                case "Axe":

                    break;
                case "Mace":

                    break;
                case "Shield":

                    break;
                case "Helmet":

                    break;
                case "Shoulderpads":

                    break;
                case "Gloves":

                    break;
                case "Braces":

                    break;
                case "Chestplate":

                    break;
                case "Leggings":

                    break;
                case "Belt":

                    break;
                case "Boots":

                    break;
                case "Amulet":

                    break;
                case "Ring":

                    break;
                default:
                    break;
            }
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
