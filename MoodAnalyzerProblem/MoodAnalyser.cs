using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        public string message;
        /// <summary>
        /// RefactorCode- Refactor the code to take the mood message in Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public MoodAnalyser(string message) 
        {
            this.message = message;
        }
        public string AnalyserMood()
        {
            if (message.ToLower().Contains("sad"))
            {
                Console.WriteLine("Given message \"{0}\" then\n return SAD",message);
                return "SAD";
            }
            else
            {
                Console.WriteLine("Given message \"{0}\" then\n return HAPPY", message);
                return "HAPPY";
            }
        }
    }
}
