using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Skill
    {
        public int ID { get; internal set; }
        public string Name { get; internal set; }
        public int Level { get; internal set; }
        public int XpMultiplier { get; set; }
        public int XpCurrent { get; set; }
        public int XpRequired { get; internal set; }
        public double XpScale { get; set; }

        public Skill(int _id, string _name, double _xpScale = 1.25)
        {
            Name = _name;

            ID = _id;

            Level = 0; // What Level the entity is at this skill
            XpMultiplier = 100; // How fast the entity levels up this skills, 150 -> 1.5 times as fast as normal
            XpScale = _xpScale; // How much extra Xp per level is needed to get to the next one
            LevelUp();
        }
        public void LevelUp() // Levels up the skill and determines how much is needed for the next level
        {
            Level++;
            XpCurrent = 0;
            XpRequired = (int)Math.Floor(32 * Level * XpScale);
        }
    }
}
