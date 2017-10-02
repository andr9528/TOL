using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Skill
    {
        int xpCurrent = 0;

        private int ID { get; set; }
        public string Name { get; internal set; }
        public int Level { get; internal set; } // What Level the entity is at this skill
        public double XpMultiplier { get; set; } 
        public int XpCurrent
        {
            get
            {
                return xpCurrent;
            }
            set
            {
                xpCurrent = value;
                if (XpCurrent >= XpRequired)
                {
                    LevelUp();
                }
            }
        }
        public int XpRequired { get; internal set; }
        private double XpScale { get; set; } // How much extra Xp per level is needed to get to the next one

        public Skill(int _id, string _name, double _xpScale = 1.25)
        {
            Name = _name;

            ID = _id;

            Level = 0; 
            XpMultiplier = 1; 
            XpScale = _xpScale; 
            LevelUp();
        }
        public void LevelUp() // Levels up the skill and determines how much is needed for the next level
        {
            Level++;
            XpCurrent -= XpRequired;
            XpRequired = (int)Math.Floor(32 * Level * XpScale);
        }
    }
}
