// See https://aka.ms/new-console-template for more information
using Diar;
using System.ComponentModel.Design;
using System.Text.Json;

Kalendar kalendar = new Kalendar();

bool run = true;
string error_msg = "This command is not valid. Type 'help' for list of commands.";

while (run)
{
	string input = Console.ReadLine();
    string[] command = input.Split(' ');

    switch (command[0])
	{
		case "help":
            if (command.Length == 1)
            {
                Console.WriteLine(@"Type [help <command name>] to see detailed info about a command
help   - Gives help on how to use the app
add    - Add an event
remove - Remove an event
list   - List events
exit   - Quit application");
            }
            else if (command.Length == 2)
            {
                switch (command[1]) 
                {
                    case "help":
                        Console.WriteLine(@"[help (<command name>)]
<command name> - specifies which command to give a description about (optional) [text]");
                        break;
                    case "add":
                        Console.WriteLine(@"[add <date> <event name>]
<date>       - date of the event [date]
<event name> - name of the event [text]");
                        break;
                    case "remove":
                        Console.WriteLine(@"[remove <date> <event name>]
<date>       - date of the event [date]
<event name> - name of the event [text]");
                        break;
                    case "list":
                        Console.WriteLine(@"[list <primary date> (<secondary date>)]
<primary date>   - primary date for selection [date/*]
<secondary date> - secondary date for selection (optional) [date/*]");
                        break;
                    case "exit":
                        Console.WriteLine(@"[exit]");
                        break;
                    default:
                        Console.WriteLine(error_msg);
                        break;
                }
            }


            Console.WriteLine("Type help <command name> to see detailed info about a command");
            break;
        case "add":
            try
            {
                kalendar.addEvent(DateTime.Parse(command[1]), command[2]);
            }
            catch
            {
                Console.WriteLine(error_msg);
            }
            break;
        case "remove":
            try
            {
                kalendar.removeEvent(DateTime.Parse(command[1]), command[2]);
            }
            catch
            {
                Console.WriteLine(error_msg);
            }
            break;
        case "list":
            if (command.Length > 3 || command.Length == 1)
            {
                Console.WriteLine(error_msg);
            }
            else
            {
                try
                {
                    if (command.Length == 3)
                    {
                        if (command[1] == "*")
                        {
                            kalendar.outputEvents(kalendar.getEventsBefore(DateTime.Parse(command[2])));
                        }
                        else if (command[2] == "*")
                        {
                            kalendar.outputEvents(kalendar.getEventsAfter(DateTime.Parse(command[1])));
                        }
                        else
                        {
                            kalendar.outputEvents(kalendar.getEventsBetween(DateTime.Parse(command[1]), DateTime.Parse(command[2])));
                        }

                    }
                    else if (command.Length == 2)
                    {
                        if (command[1] == "*")
                        {
                            kalendar.outputEvents(kalendar.getAllEvents());
                        }
                        else
                        {
                            kalendar.outputEvents(kalendar.getEventsOn(DateTime.Parse(command[1])));
                        }
                    }
                }
                catch
                {
                    Console.WriteLine(error_msg);
                }
            }
            break;
        case "exit":
            run = false;
            break;
        default:
            Console.WriteLine(error_msg);
            break;
    }
}

foreach (Udalost e in kalendar.getAllEvents())
{
    Console.WriteLine(e.getEventName());
}

Console.WriteLine(kalendar.save());