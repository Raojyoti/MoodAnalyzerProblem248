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
        public MoodAnalyser() { }
        public MoodAnalyser(string message) 
        {
            this.message = message;
        }
       // UC2-Given NULL mood Should Return HAPPY
        public string AnalyserMood()
        {
            try
            {
                if (message.ToLower().Contains("sad"))
                {
                    Console.WriteLine("Given message \"{0}\" then\n return \"SAD\"", message);
                    return "SAD";
                }
                else if (message.Equals(string.Empty))
                {
                    Console.WriteLine("Given message \"Empty\" then\n return MoodAnalysisException");
                    throw new MoodAnalysisException("Message is having empty", MoodAnalysisException.ExceptionTypes.EMPTY_MOOD);
                }
                else
                {
                    Console.WriteLine("Given message \"{0}\" then\n return \"HAPPY\"", message);
                    return "HAPPY";
                }
            } 
            catch(NullReferenceException)
            {
                //Console.WriteLine("Given message \"{0}\" then\n return HAPPY", ex.Message);//uc2.1
                //return "HAPPY";//uc2.1
                Console.WriteLine("Given message \"null\" then\n return MoodAnalysisException");
                throw new MoodAnalysisException("Message is having null", MoodAnalysisException.ExceptionTypes.NULL_MOOD);
            }
        }
    }
}
