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
        public string type { get; internal set; }
        public int startup { get; internal set; }
        public int level { get; internal set; }
        public int xpMultiplier { get; internal set; }

        public Skill()
        {

        }
        public Skill(int _id, int _startup, int _level, int _xpMultiplier , string _type)
        {

            if (_startup <= 10)
            {
                startup = _startup;
            }
            else
            {
                throw new Exception("Too High Favoring");
            }
            if (_level <= 100)
            {
                level = _level;
            }
            else
            {
                throw new Exception("Too High Level");
            }
            if (_xpMultiplier > 50)
            {
                xpMultiplier = _xpMultiplier;
            }
            else
            {
                throw new Exception("Can't go below 50% XP gain on a skill");
            }

            if (Storage.SkillString.Contains(_type))
            {
                type = _type;
            }
            else
            {
                throw new Exception("Unknown Skill");
            }
            ID = _id;
        }
    }
}
