﻿using TxtAI.NET;

namespace LabelsDemo;

public class LabelsDemo 
{
    public static async Task Main(string[] args) 
    {
        try 
        {
            var labels = new Labels("http://localhost:8000");

            var data = new List<string> 
            {
                "Dodgers lose again, give up 3 HRs in a loss to the Giants",
                "Giants 5 Cardinals 4 final in extra innings",
                "Dodgers drop Game 2 against the Giants, 5-4",
                "Flyers 4 Lightning 1 final. 45 saves for the Lightning.",
                "Slashing, penalty, 2 minute power play coming up",
                "What a stick save!",
                "Leads the NFL in sacks with 9.5",
                "UCF 38 Temple 13",
                "With the 30 yard completion, down to the 10 yard line",
                "Drains the 3pt shot!!, 0:15 remaining in the game",
                "Intercepted! Drives down the court and shoots for the win",
                "Massive dunk!!! they are now up by 15 with 2 minutes to go"
            };

            // List of labels
            var tags = new List<string> { "Baseball", "Football", "Hockey", "Basketball" };

            Console.WriteLine($"{"Text",-75} {"Label"}");
            Console.WriteLine(new string('-', 100));

            foreach (var text in data) 
            {
                var label = await labels.LabelAsync(text, tags);
                Console.WriteLine($"{text,-75} {tags[Int32.Parse(label[0].Id)]}");
            }

            Console.WriteLine();
            Console.WriteLine($"{"Text",-75} {"Label"}");
            Console.WriteLine(new string('-', 100));

            tags = new List<string> { "😀", "😡" };

            foreach (var text in data) 
            {
                var label = await labels.LabelAsync(text, tags);
                Console.WriteLine($"{text,-75} {tags[Int32.Parse(label[0].Id)]}");
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex);
        }
    }   
}