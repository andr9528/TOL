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
        private string favoring;
        private string divine;
        private int godID;

        public string Favoring { get { return favoring; } internal set { favoring = value; } }
        public string Divine { get { return divine; } internal set { divine = value; } }
        public int GodID { get { return godID; } internal set { godID = value; } }
        public List<int> XpModifier { get { return xpModifier; } }

        public Gods()
        {

        }
        public Gods(string _favoring, string _divine, int _godID)
        {
            Favoring = _favoring;
            if (Storage.GodGreekString.Contains(_divine)
                || Storage.GodEgyptianString.Contains(_divine)
                || Storage.GodNordicString.Contains(_divine)
                || Storage.GodAtlanticString.Contains(_divine))
            {
                Divine = _divine;
            }
            GodID = _godID;

            for (int i = 0; i < Favoring.Split(',').Count(); i++)
            {
                int parseValue;
                bool parseCheck = int.TryParse(Favoring.Split(',')[i].TrimStart(' '), out parseValue);

                if (parseValue > 5 && parseCheck == true)
                {
                    xpModifier.Add((parseValue - 5) * 5);
                }
                else if (parseValue <= 5 && parseCheck == true)
                {
                    xpModifier.Add((parseValue - 5) * 5);
                }
                else if (parseCheck == false)
                {
                    throw new Exception("Failed to parse favoring value");
                }
            }
        }
    }
}
