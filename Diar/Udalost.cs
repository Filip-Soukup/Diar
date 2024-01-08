using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diar
{
    internal class Udalost
    {
        public DateTime date;
        public string name;

        public Udalost(DateTime at, string name) 
        {
            this.date = at;
            this.name = name;
        }

        internal string getEventName()
        {
            return $"{this.date.ToString("dd.M.yyyy")} - {this.name}";
        }
    }
}
