// See https://aka.ms/new-console-template for more information
using Diar;
using System;
using System.ComponentModel.Design;
using System.Text.Json;

Kalendar kalendar = new Kalendar();

bool run = true;
string error_msg = "This command is not valid. Type 'help' for list of commands.";
string separator = "************************************************************";

Console.WriteLine(separator);

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
exit   - Quit application

Variables:
text - a string of text. Words must NOT be seperated by space
date - a date in format d/m/y
*    - an aterisk symbol (represents [ALL])");
            }
            else
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
<date>       - date of the event [date d/m/y]
<event name> - name of the event [text]");
                        break;
                    case "list":
                        Console.WriteLine(@"[list <primary date> (<secondary date>)]
<primary date>   - primary date for selection [date/*]
<secondary date> - secondary date for selection (optional) [date/*]");
                        break;
                    case "exit":
                        Console.WriteLine(@"[exit]
command has no parameters");
                        break;
                    default:
                        Console.WriteLine(error_msg + "\nArgument 1 in not an existing command");
                        break;
                }
            }
            break;
        case "add":
            try
            {
                if (command.Length > 3)
                {
                    Console.WriteLine(error_msg + "\nToo many argument(s)");
                }
                else if (command.Length < 3)
                {
                    Console.WriteLine(error_msg + "\nMissing argument(s)");
                }
                else
                {
                    kalendar.addEvent(DateTime.Parse(command[1]), command[2]);
                }
            }
            catch
            {
                Console.WriteLine(error_msg + "\nInvalid argument(s)");
            }
            break;
        case "remove":
            try
            {
                if (command.Length > 3)
                {
                    Console.WriteLine(error_msg + "\nToo many argument(s)");
                }
                else if (command.Length < 3)
                {
                    Console.WriteLine(error_msg + "\nMissing argument(s)");
                }
                else
                {
                    kalendar.removeEvent(DateTime.Parse(command[1]), command[2]);
                }
            }
            catch
            {
                Console.WriteLine(error_msg + "\nInvalid argument(s)");
            }
            break;
        case "list":
            if (command.Length > 3)
            {
                Console.WriteLine(error_msg + "\nToo many argument(s)");
            }
            else if (command.Length < 2)
            {
                Console.WriteLine(error_msg + "\nMissing argument(s)");
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
                    Console.WriteLine(error_msg + "\nInvalid argument(s)");
                }
            }
            break;
        case "exit":
            if (command.Length > 1)
            {
                Console.WriteLine(error_msg + "\nToo many argument(s)");
            }
            else
            {
                run = false;
            }
            break;
        default:
            Console.WriteLine(error_msg + "\nTrying to call a non-existing command");
            break;
    }
    Console.WriteLine(separator);
}

kalendar.save();