using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalysisException: Exception
    {
        public ExceptionTypes exceptionTypes;

        public enum ExceptionTypes
        {
            NULL_MOOD,
            EMPTY_MOOD
        }
        public MoodAnalysisException(string message, ExceptionTypes exception) : base(message)
        {
            this.exceptionTypes = exception;
        }
    }
}
