// See https://aka.ms/new-console-template for more information
using Diar;
using System.Text.Json;

string filename = "kalendar.json";
Kalendar kalendar;

try
{
    string jsonString = File.ReadAllText(filename);
    kalendar = JsonSerializer.Deserialize<Kalendar>(jsonString);
}
catch (System.IO.FileNotFoundException e)
{
    kalendar = new Kalendar();
}

bool run = true;

while (run)
{
    kalendar.addEvent(new DateTime(2024, 1, 4), "bruh");
    if (kalendar.udalosti.Count >= 9)
    {
        run = false;
    }
}

kalendar.save(filename);