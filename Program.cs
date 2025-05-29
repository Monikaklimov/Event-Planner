using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Seznam všech událostí
        List<Event> events = new List<Event>();
        // Slovník pro počítání událostí podle data
        Dictionary<DateTime, int> eventStats = new Dictionary<DateTime, int>();
        string command = "";

        // Cyklus se opakuje, dokud nezadáš END
        while (command != "END")
        {
            Console.WriteLine("Enter a command (EVENT;[name];[date], LIST, STATS, END):");
            command = Console.ReadLine();

            // Přidání události přes EVENT;název;datum
            if (command.StartsWith("EVENT;", StringComparison.OrdinalIgnoreCase))
            {
                var parts = command.Split(';');
                if (parts.Length == 3 && DateTime.TryParse(parts[2], out DateTime date))
                {
                    string name = parts[1];
                    Console.WriteLine("Enter event description:");
                    string description = Console.ReadLine();

                    Event newEvent = new Event(name, date, description);
                    events.Add(newEvent);

                    // Zapisujeme do slovníku – pokud už tam ten den je, přičteme, jinak vložíme 1
                    if (eventStats.ContainsKey(date))
                        eventStats[date]++;
                    else
                        eventStats[date] = 1;

                    Console.WriteLine("Event added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid format or date. Use: EVENT;name;yyyy-mm-dd");
                }
            }
            // Výpis všech událostí
            else if (command.Equals("LIST", StringComparison.OrdinalIgnoreCase))
            {
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
            }
            // Statistika událostí – využíváme slovník!
            else if (command.Equals("STATS", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Total number of events: " + events.Count);
                Console.WriteLine("Upcoming events: " + events.FindAll(e => e.Date >= DateTime.Now).Count);
                Console.WriteLine("--- Events per date ---");
                foreach (var entry in eventStats)
                {
                    Console.WriteLine($"{entry.Key.ToShortDateString()}: {entry.Value} event(s)");
                }
            }
            // Ukončení programu
            else if (command.Equals("END", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting program...");
            }
            // Neznámý přík
