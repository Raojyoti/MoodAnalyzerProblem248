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
            EMPTY_MOOD,
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
            NO_SUCH_FIELD,
            NO_SUCH_METHOD,
        }
        public MoodAnalysisException(string message, ExceptionTypes exception) : base(message)
        {
            this.exceptionTypes = exception;
        }
    }
}
