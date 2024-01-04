using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diar
{
    internal class Kalendar
    {
        internal List<Udalost> udalosti = new List<Udalost>();

        internal void save(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        internal void addEvent(DateTime date, string name)
        {
            udalosti.Add(new Udalost(date, name));
        }
    }
}
