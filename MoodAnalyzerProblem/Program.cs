using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to the Mood Analyzer Problems\n--------------------------------------");
                Console.WriteLine("Please choose any options");
                Console.WriteLine("1.Given “I am in Sad Mood” message Should Return SAD\n" +
                    "2.Given “I am in Any Mood” message Should Return HAPPY\n" +
                    "30.Exit\n");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        string message = "I am in Sad Mood";
                        MoodAnalyser mood = new MoodAnalyser();
                        mood.AnalyserMood(message);
                        Console.Write("\nPress any key to continue...... ");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        string message1 = "I am in Any Mood";
                        MoodAnalyser mood1 = new MoodAnalyser();
                        mood1.AnalyserMood(message1);
                        Console.Write("\nPress any key to continue...... ");
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.Clear();
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Select only valid options");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
