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
        string[] Genders = new string[] { "Male", "Female" };
        List<int> closenessHits = new List<int>();
        List<int> exactHits = new List<int>();
        List<int> weighting = new List<int>();

        
        public string Name { get; internal set; }
        public string Gender { get; internal set; }
        public string GodParent { get; internal set; }
        public int DesiredMythology { get; internal set; }
        public List<int> ClosenessHits { get { return closenessHits; } }
        public List<int> ExactHitsHits { get { return exactHits; } }
        public List<int> Weighting { get { return weighting; } internal set { weighting = value; } }


        public Character()
        {

        }
        public Character(string name, string gender, int desiredMythology, List<int> _weighting)
        {

            Name = name;
            Weighting = _weighting;

            if (Genders.Contains(gender))
            {
                Gender = gender;
            }
            else
            {
                throw new Exception("Invalid Gender");
            }

            if (desiredMythology <= 4 && desiredMythology >= 1)
            {
                DesiredMythology = desiredMythology;
            }
            else
            {
                throw new Exception("Invalid Desired Mythology");
            }
        }
        public string parentDeterminator()
        {
            throw new NotImplementedException();
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

        public void CountClosenessHits()
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

        public void CountExactHits(List<Gods> gods)
        {
            int count;
            int index;

            foreach (Gods divine in gods)
            {
                index = 0;
                count = 0;

                foreach (int weight in weighting)
                {

                }
            }
        }

        public string ToStringParent()
        {
            return "Your parent is" + GodParent ;
        }
        
        

    }
}
