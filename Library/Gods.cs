using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Gods
    {
        List<int> xpModifier = new List<int>();
        List<int> favoring = new List<int>();
        private string name;
        private int godID;
        private string gender;

        public List<int> Favoring { get { return favoring; } internal set { favoring = value; } }
        public string Name { get { return name; } internal set { name = value; } }
        public int GodID { get { return godID; } internal set { godID = value; } }
        public List<int> XpModifier { get { return xpModifier; } }
        public string Gender { get { return gender; } internal set { gender = value; } }

        public Gods(List<int> _favoring, string _divine, int _godID, string _gender)
        {
            Favoring = _favoring;
            Name = _divine;
            GodID = _godID;
            Gender = _gender;

            foreach (int favor in favoring)
            {
                if (favor >= 5)
                {
                    xpModifier.Add((favor - 5) * 5);
                }
                else
                {
                    xpModifier.Add(0);
                }
            }
        }
    }
}
