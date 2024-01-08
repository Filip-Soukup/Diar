// See https://aka.ms/new-console-template for more information
using Diar;
using System.ComponentModel.Design;
using System.Text.Json;

Kalendar kalendar = new Kalendar();

bool run = true;

while (run)
{
	string input = Console.ReadLine();
    string[] command = input.Split(' ');

    switch (command[0])
	{
		case "help":
            Console.WriteLine("");
            break;
        case "add":
            try
            {
                kalendar.addEvent(DateTime.Parse(command[1]), command[2]);
            }
            catch
            {
                Console.WriteLine("This command is not valid. Check for any mistakes.");
            }
            break;
        case "remove":
            try
            {
                kalendar.removeEvent(DateTime.Parse(command[1]), command[2]);
            }
            catch
            {
                Console.WriteLine("This command is not valid. Check for any mistakes.");
            }
            break;
        case "list":
            try
            {
                if (command[1] == "*") 
                { 
                    kalendar.getAllEvents();
                }
            }
            catch
            {
                Console.WriteLine("This command is not valid. Check for any mistakes.");
            }
            break;
    }
}

foreach (Udalost e in kalendar.getAllEvents())
{
    Console.WriteLine(e.getEventName());
}

Console.WriteLine(kalendar.save());