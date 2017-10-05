using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Player : Entity
    {
        List<int> closenessHits = new List<int>();
        List<int> weighting = new List<int>();
        
        public enum ValidMythologies { Greek, Eqyptian, Norse, Atlantic}
        
        public Repo.ValidGenders Gender { get; internal set; }
        public Gods DivineParent { get; internal set; }
        public ValidMythologies DesiredMythology { get; internal set; }
        public List<int> Weighting { get { return weighting; } internal set { weighting = value; } }

        public Player(string name, int gender, int desiredMythology, List<int> _weighting, Gods parent = null)
        {
            Name = name;
            Weighting = _weighting;
            DesiredMythology = (ValidMythologies)desiredMythology;
            Gender = (Repo.ValidGenders)gender;
            DivineParent = parent;

            CollectEquipment();
            CollectSkills();

            UpdateLevel();
        }
        #region Parent Determinator
        public void ParentDeterminator()
        {
            List<int> highestCount = new List<int>() { 0 };

            CountClosenessHits();
            List<Gods> possibleParents = FindHighestHits();

            if (possibleParents.Count() > 1)
            {
                possibleParents = FindExcactHits(possibleParents);

                if (possibleParents.Count() > 1)
                {
                    List<Gods> workableList = possibleParents;

                    foreach (Gods divine in possibleParents)
                    {
                        if (divine.Gender != Gender)
                        {
                            workableList.Remove(divine);
                        }
                    }

                    possibleParents = workableList;

                    if (possibleParents.Count() > 1)
                    {
                        throw new Exception("Can't find your 1 Divine parent, you match too many");
                    }
                    else
                    {
                        DivineParent = possibleParents[0];
                    }
                }
                else
                {
                    DivineParent = possibleParents[0];
                }
            }
            else
            {
                DivineParent = possibleParents[0];
            }
        }
        public bool checkIfClose(int index, Gods divine, int weight)
        {
            if (weight >= divine.Favoring[index]-1 
                && weight <= divine.Favoring[index] + 1)
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
            if (weight == divine.Favoring[index])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CountClosenessHits()
        {
                closenessHits.Clear();
                int count;
                int index;

                if (DesiredMythology == ValidMythologies.Greek)
                {
                    foreach (Gods divine in Repo.GreekGods)
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
                else if (DesiredMythology == ValidMythologies.Eqyptian)
                {
                    foreach (Gods divine in Repo.EgyptianGods)
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
                else if (DesiredMythology == ValidMythologies.Norse)
                {
                    foreach (Gods divine in Repo.NordicGods)
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
                else if (DesiredMythology == ValidMythologies.Atlantic)
                {
                    foreach (Gods divine in Repo.AtlanticTitans)
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
        public List<Gods> FindExcactHits(List<Gods> gods)
        {
            List<Gods> output = new List<Gods>();
            List<int> exactHits = new List<int>();
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

            output.Clear();
            int highestKnown = 0;

            for (int i = 0; i < exactHits.Count; i++)
            {
                if (exactHits[i] > highestKnown)
                {
                    output.Clear();
                    output.Add(gods[i]);
                    highestKnown = exactHits[i];
                }
                else if (exactHits[i] == highestKnown)
                {
                    output.Add(gods[i]);
                }
            }
            return output;
        }
        public List<Gods> FindHighestHits()
        {
            List<Gods> output = new List<Gods>();
            int index = 0;
            int highestCount = 0;

            if (DesiredMythology == ValidMythologies.Greek)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Repo.GreekGods[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Repo.GreekGods[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            else if (DesiredMythology == ValidMythologies.Eqyptian)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Repo.EgyptianGods[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Repo.EgyptianGods[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            else if (DesiredMythology == ValidMythologies.Norse)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Repo.NordicGods[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Repo.NordicGods[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            else if (DesiredMythology == ValidMythologies.Atlantic)
            {
                foreach (int hit in closenessHits)
                {
                    if (hit == highestCount)
                    {
                        output.Add(Repo.AtlanticTitans[index]);
                    }
                    else if (hit > highestCount)
                    {
                        output.Clear();
                        output.Add(Repo.AtlanticTitans[index]);
                        highestCount = hit;
                    }
                    index++;
                }
            }
            return output;
        }
        #endregion
        public string ToStringParent()
        {
            return "Your parent is " + DivineParent.Name ;
        }
        public string ToStringPlayer()
        {
            return Name + ", Level " + Level;
        }

    }
}
