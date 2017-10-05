using System;
using System.Collections.Generic;

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
                    SetCurrent();
                }
            }
        }
        #region Spells
        List<Spell> Spells = new List<Spell>();
        List<Spell> Buffs = new List<Spell>();
        List<Spell> Debuffs = new List<Spell>();
        List<Spell> DoTs = new List<Spell>();

        public void LearnSpell(Spell spell)
        {
            Spells.Add(spell);
        }
        public void ForgetSpell(int index)
        {
            Spells.RemoveAt(index);
        }
        private void BuffEntity(Spell buff)
        {
             Buffs.Add(buff);
        }
        private void DebuffEntity(Spell debuff)
        {
             Debuffs.Add(debuff);
        }
        private void ApplyDoT(Spell dot)
        {
             DoTs.Add(dot);
        }

        private void TickDoTs()
        {
            List<Spell> tempDoTs = DoTs;
            foreach (Spell dot in DoTs)
            {
                CurrentHealth -= dot.Effect;
                dot.Duration--;

                if (dot.Duration == 0)
                {
                    tempDoTs.Remove(dot);
                }
            }

            DoTs = tempDoTs;
        }
        public Tuple<Spell, string> SpellCast(int index)
        {
            string output2 = "Succes";
            Spell output1 = null;
            if (CurrentMana > Spells[index].ManaCost)
            {
                CurrentMana -= Spells[index].ManaCost;
                output1 = Spells[index];
                DetermineXp(output1);
            }
            else
            {
                output2 = "Fail";
            }

            RegenHealth();
            RegenMana();

            return Tuple.Create(output1, output2);
        }
        public string SpellHandler(Tuple<Spell, string> spell)
        {
            if (spell.Item1 != null && spell.Item2 == "Succes")
            {
                switch (spell.Item1.Target)
                {
                    case Spell.ValidTargets.Enemy:
                        switch (spell.Item1.Type)
                        {
                            case Spell.ValidTypes.Damage:
                                CurrentHealth -= spell.Item1.Effect;
                                break;
                            case Spell.ValidTypes.DoT:
                                ApplyDoT(spell.Item1);
                                break;
                            case Spell.ValidTypes.Debuff:
                                DebuffEntity(spell.Item1);
                                break;
                            default:
                                break;
                        }
                        break;
                    case Spell.ValidTargets.Self:
                        switch (spell.Item1.Type)
                        {
                            case Spell.ValidTypes.Heal:
                                CurrentHealth += spell.Item1.Effect;
                                break;
                            case Spell.ValidTypes.Buff:
                                BuffEntity(spell.Item1);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            return spell.Item2;
        }
        private void DetermineXp(Spell spell) // For magical battles
        {
            switch (spell.SkillName)
            {
                case Spell.ValidSkillNames.WildMagic:
                    WildMagic.XpCurrent += (int)Math.Floor(spell.XpPerCast * WildMagic.XpMultiplier * 0.9);
                    break;
                case Spell.ValidSkillNames.InfernoMagic:
                    InfernoMagic.XpCurrent += (int)Math.Floor(spell.XpPerCast * InfernoMagic.XpMultiplier * 0.9);
                    break;
                case Spell.ValidSkillNames.BlizzMagic:
                    BlizzMagic.XpCurrent += (int)Math.Floor(spell.XpPerCast * BlizzMagic.XpMultiplier * 0.9);
                    break;
                case Spell.ValidSkillNames.SkyMagic:
                    SkyMagic.XpCurrent += (int)Math.Floor(spell.XpPerCast * SkyMagic.XpMultiplier * 0.9);
                    break;
                default:
                    break;
            }
            PureMagic.XpCurrent += (int)Math.Floor(spell.XpPerCast * PureMagic.XpMultiplier * 0.1);
        }

        #endregion

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

        

        public Equipment Head { get { return head; } set { head = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Shoulder { get { return shoulder; } set { shoulder = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Gloves { get { return gloves; } set { gloves = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Braces { get { return braces; } set { braces = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Chestplate { get { return chestplate; } set { chestplate = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Leggings { get { return leggings; } set { leggings = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Belt { get { return belt; } set { belt = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment Boots { get { return boots; } set { boots = value; } } // Can be LightArmor, HeavyArmor or None
        public Equipment MainHand { get { return mainHand; } set { mainHand = value; } } // Can be OneHanded, Twohanded or None
        public Equipment OffHand { get { return offHand; } set { offHand = value; } } // Can be OneHanded, Twohanded, Blocking or None
        public Equipment Ranged { get { return ranged; } set { ranged = value; } } // Can be Archery or None
        public Equipment Amulet { get { return amulet; } set { amulet = value; } } // Can be None
        public Equipment LeftRing { get { return leftRing; } set { leftRing = value; } } // Can be None
        public Equipment RightRing { get { return rightRing; } set { rightRing = value; } } // Can be None

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
        public Skill SkyMagic { get { return skymagic; } set { skymagic = value; } }
        public Skill PureMagic { get { return pureMagic; } set { pureMagic = value; } }

        List<Skill> Skills;

        internal void CollectSkills()
        {
            Skills = new List<Skill>()
            {
                Archery, OneHanded, TwoHanded, LightArmor,
                HeavyArmor, Stealth, Agility, Smithing,
                Enchanting, Alchemy, Blocking, WildMagic,
                InfernoMagic, BlizzMagic, SkyMagic, PureMagic
            };
        }
        public List<Skill> GetSkills()
        {
            CollectSkills();
            return Skills;
        }
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
            CollectSkills();

            MaxHealth = 90 + (10 * Level);
            MaxMana = 90 + (10 * Level) + (WildMagic.Level * 5) + (InfernoMagic.Level * 5) + (BlizzMagic.Level * 5) + (SkyMagic.Level * 5) + (PureMagic.Level * 20);

            DodgeChance = 5 + (Agility.Level / 5);
            BlockChance = 0 + (Blocking.Level / 5);
            Protection = 0 + (LightArmor.Level / 25) + (HeavyArmor.Level / 15);
            CriticalChance = 5 + (Archery.Level / 10) + (OneHanded.Level / 10) + (TwoHanded.Level / 10);
            CriticalDamageMultiplier = 2;
            MinimumDamage = 1 + (1 * Level);
            MaximumDamage = 3 + (2 * Level);
            AttackSpeed = 1;

            AddStatsFromEquipment();
            AddStatsFromBuffs();
            RemoveStatsFromDebuffs();
            AddStatsFromEnchantments();

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

            TickDoTs();
            EnsureValidStats();
            

        }
        private void EnsureValidStats()
        {
            if (MinimumDamage > MaximumDamage)
            {
                MinimumDamage = MaximumDamage;
            }
            else if (MinimumDamage <= 0)
            {
                MinimumDamage = 1;
            }
            if (MaxHealth < 1)
            {
                MaxHealth = 1;
            }
            if (MaxMana < 0)
            {
                MaxMana = 0;
            }
            if (MaximumDamage <= 1)
            {
                MaximumDamage = 2;
            }
            if (HealthRegeneration < 0)
            {
                HealthRegeneration = 0;
            }
            if (ManaRegeneration < 0)
            {
                ManaRegeneration = 0;
            }
            if (DodgeChance < 0)
            {
                DodgeChance = 0;
            }
            else if (DodgeChance > 45)
            {
                DodgeChance = 45;
            }
            if (BlockChance < 0)
            {
                BlockChance = 0;
            }
            else if (BlockChance > 45)
            {
                BlockChance = 45;
            }
            if (CriticalChance < 0)
            {
                CriticalChance = 0;
            }
            else if (CriticalChance > 100)
            {
                CriticalChance = 100;
            }
            if (CriticalDamageMultiplier < 1)
            {
                CriticalDamageMultiplier = 1;
            }
            if (AttackSpeed < 0.5)
            {
                AttackSpeed = 0.5;
            }
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
        private void RemoveStatsFromDebuffs()
        {
            List<Spell> tempDebuffs = Debuffs;
            foreach (Spell debuff in Debuffs)
            {
                foreach (Tuple<StatModifier.ValidShorts, double> modifier in debuff.GetStatModifiers())
                {
                    SwitchRemove(modifier);
                }
                debuff.Duration--;
                if (debuff.Duration == 0)
                {
                    tempDebuffs.Remove(debuff);
                }
            }
            Debuffs = tempDebuffs;
        }
        private void AddStatsFromBuffs()
        {
            List<Spell> tempBuffs = Buffs;
            foreach (Spell buff in Buffs)
            {
                foreach (Tuple<StatModifier.ValidShorts, double> modifier in buff.GetStatModifiers())
                {
                    SwitchAdd(modifier);
                }
                buff.Duration--;
                if (buff.Duration == 0)
                {
                    tempBuffs.Remove(buff);
                }
            }
            Buffs = tempBuffs;
        }
        private void AddStatsFromEnchantments()
        {
            foreach (Equipment equiped in Equiped)
            {
                if (equiped != null)
                {
                    foreach (Enchantment enchantment in equiped.GetEnchantments())
                    {
                        enchantment.State = false;
                        if (ManaRegeneration - enchantment.ManaRegenCost > 0)
                        {
                            enchantment.State = true;
                            ManaRegeneration -= enchantment.ManaRegenCost;

                            foreach (Tuple < StatModifier.ValidShorts, double> modifier in enchantment.GetStatModifiers())
                            {
                                SwitchAdd(modifier);
                            }
                        }
                    }
                }
            }
        }
        private void AddStatsFromEquipment()
        {
            foreach (Equipment equiped in Equiped)
            {
                if (equiped != null)
                {
                    foreach (Tuple<StatModifier.ValidShorts, double> modifier in equiped.GetStatModifiers())
                    {
                        SwitchAdd(modifier);
                    }
                }
            }
        }

        private void SwitchAdd(Tuple<StatModifier.ValidShorts, double> modifier)
        {
            switch (modifier.Item1.ToString())
            {
                case "Hp":
                    MaxHealth += (int)Math.Floor(modifier.Item2);
                    break;
                case "Mp":
                    MaxMana += (int)Math.Floor(modifier.Item2);
                    break;
                case "Prot":
                    Protection += (int)Math.Floor(modifier.Item2);
                    break;
                case "MinDam":
                    MinimumDamage += (int)Math.Floor(modifier.Item2);
                    break;
                case "MaxDam":
                    MaximumDamage += (int)Math.Floor(modifier.Item2);
                    break;
                case "Hps":
                    HealthRegeneration += modifier.Item2;
                    break;
                case "Mps":
                    ManaRegeneration += modifier.Item2;
                    break;
                case "Dc":
                    DodgeChance += modifier.Item2;
                    break;
                case "Bc":
                    BlockChance += modifier.Item2;
                    break;
                case "Cc":
                    CriticalChance += modifier.Item2;
                    break;
                case "Cdm":
                    CriticalDamageMultiplier += modifier.Item2;
                    break;
                case "As":
                    AttackSpeed += modifier.Item2;
                    break;
                default:
                    break;
            }
        }
        private void SwitchRemove(Tuple<StatModifier.ValidShorts, double> modifier)
        {
            switch (modifier.Item1.ToString())
            {
                case "Hp":
                    MaxHealth -= (int)Math.Floor(modifier.Item2);
                    break;
                case "Mp":
                    MaxMana -= (int)Math.Floor(modifier.Item2);
                    break;
                case "Prot":
                    Protection -= (int)Math.Floor(modifier.Item2);
                    break;
                case "MinDam":
                    MinimumDamage -= (int)Math.Floor(modifier.Item2);
                    break;
                case "MaxDam":
                    MaximumDamage -= (int)Math.Floor(modifier.Item2);
                    break;
                case "Hps":
                    HealthRegeneration -= modifier.Item2;
                    break;
                case "Mps":
                    ManaRegeneration -= modifier.Item2;
                    break;
                case "Dc":
                    DodgeChance -= modifier.Item2;
                    break;
                case "Bc":
                    BlockChance -= modifier.Item2;
                    break;
                case "Cc":
                    CriticalChance -= modifier.Item2;
                    break;
                case "Cdm":
                    CriticalDamageMultiplier -= modifier.Item2;
                    break;
                case "As":
                    AttackSpeed -= modifier.Item2;
                    break;
                default:
                    break;
            }
        }
        public void SetCurrent()
        {
            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;
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

        public int Attack()
        {
            int critCheck = Repo.Random.Next(1, 100);
            int output = 0;

            if (critCheck <= CriticalChance)
            {
                output = (int)Math.Floor(Repo.Random.Next(MinimumDamage, MaximumDamage) * CriticalDamageMultiplier);
                DetermineXp(output, "Attack");
            }
            else
            {
                output = Repo.Random.Next(MinimumDamage, MaximumDamage);
                DetermineXp(output, "Attack");
            }

            RegenHealth();
            RegenMana();

            return output;
        }
        public string Defend(int damage)
        {
            int dodgeCheck = Repo.Random.Next(1, 100);
            int blockCheck = Repo.Random.Next(1, 100);

            if (damage - Protection > 0)
            {
                if (dodgeCheck > DodgeChance)
                {
                    if (blockCheck > BlockChance)
                    {
                        damage -= Protection;
                        CurrentHealth -= damage;
                        if (CurrentHealth < 0)
                        {
                            CurrentHealth = 0;
                            return "Succecfull Hit! " + Name + " is Dead "; 
                        }
                        else
                        {
                            return "Succecfull Hit! " + Name + " Lost " + damage + " Health";
                        }
                    }
                    else
                    {
                        DetermineXp(damage, "Block");
                        return "Blocked";
                    }
                }
                else
                {
                    DetermineXp(damage, "Dodge");
                    return "Dodged";
                }
            }
            else
            {
                DetermineXp(damage, "Protect");
                return "Protected";
            }
        }
        private void DetermineXp(int damage, string check) // For mundane battles
        {
            switch (check)
            {
                case "Protect":
                    int light = CountLightArmorPieces();
                    int heavy = CountHeavyArmorPieces();
                    LightArmor.XpCurrent += (int)Math.Floor(damage / 8 * light * LightArmor.XpMultiplier);
                    HeavyArmor.XpCurrent += (int)Math.Floor(damage / 8 * heavy * HeavyArmor.XpMultiplier);
                    break;
                case "Dodge":
                    Agility.XpCurrent += (int)Math.Floor(damage * Agility.XpMultiplier);
                    break;
                case "Block":
                    Blocking.XpCurrent += (int)Math.Floor(damage * Blocking.XpMultiplier);
                    break;
                case "Attack":
                    double main = 0;
                    double off = 0;
                    double ran = 0;

                    if (MainHand != null && MainHand.SkillName.ToString() == "Onehanded" || MainHand != null && MainHand.SkillName.ToString() == "TwoHanded")
                    {
                        main = DetermineXpDivideForWeapons(MainHand);
                        if (MainHand.SkillName.ToString() == "OneHanded")
                        {
                            OneHanded.XpCurrent += (int)Math.Floor(damage * OneHanded.XpMultiplier * main);
                        }
                        else
                        {
                            TwoHanded.XpCurrent += (int)Math.Floor(damage * TwoHanded.XpMultiplier * main);
                        }

                    }
                    if (OffHand != null && OffHand.SkillName.ToString() == "OneHanded" && MainHand.SkillName.ToString() != "TwoHanded")
                    {
                        off = DetermineXpDivideForWeapons(OffHand);
                        OneHanded.XpCurrent += (int)Math.Floor(damage * OneHanded.XpMultiplier * off);
                    }
                    if (Ranged != null)
                    {
                        ran = DetermineXpDivideForWeapons(Ranged);
                        Archery.XpCurrent += (int)Math.Floor(damage * Archery.XpMultiplier * ran);
                    }
                    break;
                default:
                    break;
            }
        }
        private double DetermineXpDivideForWeapons(Equipment weapon)
        {
            double output = 0;
            double mindam = 0;
            double maxdam = 0;

            foreach (Tuple<StatModifier.ValidShorts, double> modifier in weapon.GetStatModifiers())
            {
                switch (modifier.Item1.ToString())
                {
                    case "MinDam":
                        mindam = Math.Floor(modifier.Item2);
                        break;
                    case "MaxDam":
                        maxdam = Math.Floor(modifier.Item2);
                        break;
                    default:
                        break;
                }
            }

            output = (((mindam + maxdam) / 2) / ((MinimumDamage + MaximumDamage) / 2));

            return output;
        }
        private int CountLightArmorPieces()
        {
            int output = 0;
            CollectEquipment();

            foreach (Equipment equiped in Equiped)
            {
                if (equiped != null)
                {
                    if (equiped.SkillName.ToString() == "LightArmor")
                    {
                        output++;
                    }
                }
            }
            return output;

        }
        private int CountHeavyArmorPieces()
        {
            int output = 0;
            CollectEquipment();

            foreach (Equipment equiped in Equiped)
            {
                if (equiped != null)
                {
                    if (equiped.SkillName.ToString() == "HeavyArmor")
                    {
                        output++;
                    }
                }
            }
            return output;
        }
        public void UpdateLevel()
        {
            Level = (Archery.Level + OneHanded.Level + TwoHanded.Level + LightArmor.Level
                + HeavyArmor.Level + Stealth.Level + Agility.Level + Smithing.Level
                + Enchanting.Level + Alchemy.Level + Blocking.Level + WildMagic.Level
                + InfernoMagic.Level + BlizzMagic.Level + SkyMagic.Level + PureMagic.Level) / 16;
        }
        
    }
}
