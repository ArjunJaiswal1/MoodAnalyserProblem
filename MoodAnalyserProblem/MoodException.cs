using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MoodAnalyserProblem
{    /// <summary>
     /// In case of NULL or Empty Mood throwing Custom Exception MoodAnalysisException(UC3)
     /// </summary>
    public class MoodAnalysisException : Exception
    {
        //Declaring exception type 
        public ExceptionTypes type;
        //Using enum to differentiate the mood analysis errors(UC3)
        public enum ExceptionTypes
        {
            NULL_MOOD_EXCEPTION,
            
            EMPTY_MOOD_EXCEPTION,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND
        }

        //Constructor to initialize the enum exception types(UC3)
        public MoodAnalysisException(ExceptionTypes type, string message) : base(message)
        {
            this.type = type;
        }
    }
}