using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Diar
{
    internal class Kalendar
    {
        internal List<Udalost> udalosti = new List<Udalost>();
        string filename = "kalendar.json";

        internal Kalendar() 
        {
            try
            {
                string jsonString = File.ReadAllText(filename);
                try 
                {
                    udalosti = JsonConvert.DeserializeObject<List<Udalost>>(jsonString);
                } 
                catch (Newtonsoft.Json.JsonSerializationException e) 
                {
                    Console.WriteLine("savefile is corrupted");
                    Console.WriteLine(e);
                }
                
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("savefile does not exist");
            }
        }

        internal string save()
        {
            string jsonString = JsonConvert.SerializeObject(udalosti);
            File.WriteAllText(this.filename, jsonString);
            return jsonString;
        }

        internal void addEvent(DateTime date, string name)
        {
            if (!udalosti.Contains(new Udalost(date, name)) 
            {
                udalosti.Add(new Udalost(date, name));
                Console.WriteLine($"Added event: {date.ToString("dd.M.yyyy")} - {name}");
            }
            else
            {
                Console.WriteLine("event already exists");
            }
        }

        internal void removeEvent(DateTime date, string name)
        {
            if (udalosti.Contains(new Udalost(date, name))
            {
                udalosti.Remove(new Udalost(date, name));
                Console.WriteLine($"Removed event: {date.ToString("dd.M.yyyy")} - {name}");
            }
            else
            {
                Console.WriteLine("event doesn't exists");
            }
        }

        internal Udalost[] getAllEvents()
        {
            return udalosti.ToArray();
        }

        internal Udalost[] getEventsOn(DateTime date)
        {
            Udalost[] events = udalosti.ToArray();
            //finnish
        }
    }
}
