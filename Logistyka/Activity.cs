using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistyka
{
    public class Activity
    {
        public int Id;
        public string Name;
        public string Duration;
        public string PrecessorId;

        public Activity(){}
        public Activity(int id, string name, string duration, string precessorId)
        {
            Id = id;
            Name = name;
            Duration = duration;
            PrecessorId = precessorId;
        }
    }
}
