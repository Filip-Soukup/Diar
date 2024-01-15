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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Udalost otherEvent = (Udalost)obj;
            return this.date == otherEvent.date && this.name == otherEvent.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(date, name);
        }
    }
}
