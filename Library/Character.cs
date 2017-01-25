using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Character
    {
        public Storage store = new Storage();
        List<int> closenessHits = new List<int>();
        List<int> exactHits = new List<int>();
        List<int> weighting = new List<int>();

        Skill archery = new Skill(0, "Archery");
        Skill oneHanded = new Skill(1, "OneHanded");
        Skill twoHanded = new Skill(2, "TwoHanded");
        Skill lightArmor = new Skill(3, "LightArmor");
        Skill heavyArmor = new Skill(4, "HeavyArmor");
        Skill stealth = new Skill(5, "Stealth");
        Skill agility = new Skill(6, "Agility");
        Skill smighting = new Skill(7, "Smighting");
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
        public Skill Smighting { get { return smighting; } set { smighting = value; } }
        public Skill Enchanting { get { return enchanting; } set { enchanting = value; } }
        public Skill Alchemy { get { return alchemy; } set { alchemy = value; } }
        public Skill Blocking { get { return blocking; } set { blocking = value; } }
        public Skill WildMagic { get { return wildMagic; } set { wildMagic = value; } }
        public Skill InfernoMagic { get { return infernoMagic; } set { infernoMagic = value; } }
        public Skill BlizzMagic { get { return blizzMagic; } set { blizzMagic = value; } }
        public Skill Skymagic { get { return skymagic; } set { skymagic = value; } }
        public Skill PureMagic { get { return pureMagic; } set { pureMagic = value; } }

        public string Name { get; internal set; }
        public string Gender { get; internal set; }
        public string DivineParent { get; internal set; }
        public int DesiredMythology { get; internal set; }
        public int Level { get; internal set; }
        public List<int> Weighting { get { return weighting; } internal set { weighting = value; } }

        public Character()
        {

        }
        public Character(string name, string gender, int desiredMythology, List<int> _weighting)
        {
            Name = name;
            Weighting = _weighting;
            DesiredMythology = desiredMythology;
            Gender = gender;
            updateLevel();
        }
        public void updateLevel()
        {
            Level = (Archery.Level + OneHanded.Level + TwoHanded.Level + LightArmor.Level
                + HeavyArmor.Level + Stealth.Level + Agility.Level + Smighting.Level
                + Enchanting.Level + Alchemy.Level + Blocking.Level + WildMagic.Level
                + InfernoMagic.Level + BlizzMagic.Level + Skymagic.Level + PureMagic.Level) / 16;
        }
        public void parentDeterminator()
        {
            int highestCount = 0;

            countClosenessHits();
            List<Gods> possibleParents = findHighestHits();

            if (possibleParents.Count() > 1)
            {
                countExactHits(possibleParents);

                for (int i = 0; i < possibleParents.Count; i++)
                {
                    if (exactHits[i] == highestCount)
                    {
                        throw new Exception("Multiple divine parents"); // needs a better solution
                    }
                    else if (exactHits[i] > highestCount)
                    {
                        highestCount = exactHits[i];
                        DivineParent = possibleParents[i].Divine;
                    }
                }
            }
            else
            {
                DivineParent = possibleParents[0].Divine;
            }
        }
        public bool checkIfClose(int index, Gods divine, int weight)
        {
            if (weight >= int.Parse(divine.Favoring.Split(',')[index])-1 
                && weight <= int.Parse(divine.Favoring.Split(',')[index]) + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkIfExact(int index, Gods divine, int weight)
        {
            if (weight == int.Parse(divine.Favoring.Split(',')[index]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void countClosenessHits()
        {
                closenessHits.Clear();
                int count;
                int index;

                if (DesiredMythology == 1)
                {
                    foreach (Gods divine in Storage.GreekGods)
                    {
                        index = 0;
                        count = 0;
                        foreach (int weight in weighting)
                            {
                                if (checkIfClose(index, divine, weight) == true)
                                {
                                    count++;
                                }
                                index++;
                            }
                            closenessHits.Add(count);
                }
                    
                }
                else if (DesiredMythology == 2)
                {
                    foreach (Gods divine in Storage.EgyptianGods)
                    {
                        index = 0;
                        count = 0;
                            foreach (int weight in weighting)
                            {
                                if (checkIfClose(index, divine, weight) == true)
                                {
                                    count++;
                                }
                                index++;
                            }
                            closenessHits.Add(count);
                    }
                    
                }
                else if (DesiredMythology == 3)
                {
                    foreach (Gods divine in Storage.NordicGods)
                    {
                        index = 0;
                        count = 0;
                        foreach (int weight in weighting)
                            {
                                if (checkIfClose(index, divine, weight) == true)
                                {
                                    count++;
                                }
                                index++;
                            }
                            closenessHits.Add(count);
                    }
                    
                }
                else if (DesiredMythology == 4)
                {
                    foreach (Gods divine in Storage.AtlanticTitans)
                    {
                        index = 0;
                        count = 0;
                        foreach (int weight in weighting)
                            {
                                if (checkIfClose(index, divine, weight) == true)
                                {
                                    count++;
                                }
                                index++;
                            }
                        closenessHits.Add(count);
                    }
                    
                }
                else
                {
                    throw new Exception("How did you get to this point?");
                }
        }
        public void countExactHits(List<Gods> gods)
        {
            exactHits.Clear();
            int count;
            int index;

            foreach (Gods divine in gods)
            {
                index = 0;
                count = 0;

                foreach (int weight in weighting)
                {
                    if (checkIfExact(index, divine, weight) == true)
                    {
                        count++;
                    }
                    index++;
                }
                exactHits.Add(count);
            }
        }
        public List<Gods> findHighestHits()
        {
            List<Gods> output = new List<Gods>();
            int index = 0;
            int highestCount = 0;

            if (DesiredMythology == 1)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Storage.GreekGods[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Storage.GreekGods[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            else if (DesiredMythology == 2)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Storage.EgyptianGods[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Storage.EgyptianGods[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            else if (DesiredMythology == 3)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Storage.NordicGods[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Storage.NordicGods[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            else if (DesiredMythology == 4)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Storage.AtlanticTitans[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Storage.AtlanticTitans[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            return output;
        }
        public string ToStringParent()
        {
            return "Your parent is" + DivineParent ;
        }

    }
}
