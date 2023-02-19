using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        /// <summary>
        /// UC1-Given a Message, ability to analyse and respond Happy or Sad Mood.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AnalyserMood(string message)
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
