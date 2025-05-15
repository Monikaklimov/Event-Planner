using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();
        string command = "";

        while (command != "exit")
        {
            Console.WriteLine("Enter a command (add, list, analyze, exit):");
            command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    Console.WriteLine("Enter event name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter event date (yyyy-mm-dd):");
                    DateTime date;
                    while (!DateTime.TryParse(Console.ReadLine(), out date))
                    {
                        Console.WriteLine("Invalid date. Please enter again (yyyy-mm-dd):");
                    }

                    Console.WriteLine("Enter event description:");
                    string description = Console.ReadLine();

                    events.Add(new Event(name, date, description));
                    Console.WriteLine("Event added successfully!");
                    break;

                case "list":
                    if (events.Count == 0)
                    {
                        Console.WriteLine("No events to display.");
                    }
                    else
                    {
                        foreach (var evt in events)
                        {
                            Console.WriteLine(evt);
                        }
                    }
                    break;

                case "analyze":
                    Console.WriteLine("Total number of events: " + events.Count);
                    DateTime now = DateTime.Now;
                    int upcomingCount = events.FindAll(e => e.Date >= now).Count;
                    Console.WriteLine("Upcoming events: " + upcomingCount);
                    break;

                case "exit":
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Unknown command. Please try again.");
                    break;
            }
        }
    }
}

class Event
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Event(string name, DateTime date, string description)
    {
        Name = name;
        Date = date;
        Description = description;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Date: {Date.ToShortDateString()}, Description: {Description}";
    }
}
