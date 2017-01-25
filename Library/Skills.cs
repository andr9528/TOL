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
        public string Type { get; internal set; }
        public int Level { get; internal set; }
        public int XpMultiplier { get; set; }
        public int XpCurrent { get; set; }
        public int XpRequired { get; internal set; }
        public double XpScale { get; set; }

        public Skill()
        {

        }
        public Skill(int _id, string _type, double _xpScale = 1.25)
        {

            if (Storage.SkillString.Contains(_type))
            {
                Type = _type;
            }
            else
            {
                throw new Exception("Unknown Skill");
            }
            ID = _id;

            Level = 0;
            XpMultiplier = 100;
            XpScale = _xpScale;
            LevelUp();
        }
        public void LevelUp()
        {
            Level++;
            XpCurrent = 0;
            XpRequired = (int)Math.Floor(32 * Level * XpScale);
        }
    }
}
