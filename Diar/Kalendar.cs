using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

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
                    Console.WriteLine("Loaded from a savefile");
                } 
                catch (Newtonsoft.Json.JsonSerializationException e) 
                {
                    Console.WriteLine("Could not load - Savefile is corrupted");    
                    #if DEBUG
                        Console.WriteLine(e);
                        Console.WriteLine(Environment.CurrentDirectory + "\\" + filename);
                    #endif
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.ToString());
                    Environment.Exit(0);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Could not load - Savefile does not exist");
            }
            Console.WriteLine($"Today is {DateTime.Now.ToString("d.M.yyyy")}");
        }

        internal string save()
        {
            string jsonString = JsonConvert.SerializeObject(udalosti);
            File.WriteAllText(this.filename, jsonString);
            return jsonString;
        }

        internal void addEvent(DateTime date, string name)
        {
            if (!udalosti.Contains(new Udalost(date, name)))
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
            if (udalosti.Contains(new Udalost(date, name)))
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

        internal Udalost[] getEventsByName(string name)
        {
            List<Udalost> result = new List<Udalost>();
            result = udalosti.Where(item => item.name == name).ToList();
            Udalost[] output = result.ToArray();

            return output;
        }

        internal Udalost[] getEventsOn(DateTime date)
        {
            List<Udalost> result = new List<Udalost>();
            result = udalosti.Where(item => item.date.Date == date.Date).ToList();
            Udalost[] output = result.ToArray();

            return output;
        }

        internal Udalost[] getEventsBefore(DateTime date)
        {
            List<Udalost> result = new List<Udalost>();
            result = udalosti.Where(item => item.date.Date <= date.Date).ToList();
            Udalost[] output = result.ToArray();

            return output;
        }

        internal Udalost[] getEventsAfter(DateTime date)
        {
            List<Udalost> result = new List<Udalost>();
            result = udalosti.Where(item => item.date.Date >= date.Date).ToList();
            Udalost[] output = result.ToArray();

            return output;
        }

        internal Udalost[] getEventsBetween(DateTime date1, DateTime date2)
        {
            List<Udalost> result = new List<Udalost>();
            result = udalosti.Where(item => item.date.Date >= date1.Date && item.date.Date <= date2.Date).ToList();
            Udalost[] output = result.ToArray();

            return output;
        }

        internal void outputEvents(Udalost[] events)
        {
            if (events.Length == 0) 
            {
                Console.WriteLine("No events found");
            }
            else 
            {
                foreach (Udalost item in events)
                {
                    Console.WriteLine(item.getEventName());
                }
            }
        }
    }
}
