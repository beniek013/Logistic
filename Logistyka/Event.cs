using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistyka
{
    public class Event
    {
        private int Id;
        public int? t0j;
        public int? t1j;
        public int? Lj;

        public Event(int id, int? t0j, int? t1j, int? lj)
        {
            Id = id;
            this.t0j = t0j;
            this.t1j = t1j;
            Lj = lj;
        }
    }
}
