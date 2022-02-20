using System;
using System.ComponentModel.DataAnnotations;
namespace MoodAnalyserProblem
{
    /// <summary>
    /// Class to check a message, ability to analyse and respond happy or sad Mood
    /// </summary>
    public class MoodAnalyse
    {
        //Declaring varibale(Refactor)
        public string message;

        //Default constructor(UC4)
        public MoodAnalyse()
        {
            Console.WriteLine("Default constructor");
        }

        //Constructor to initialize message(Refactor) 
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        //Method to analyse the mood from  the given message(UC1)
        public string AnalyzeMood()
        {
            //Handling exception if user provide null or empty value(UC2&UC3)
            try
            {
                //In case of null or empty mood throw custom exception MoodAnalysisException(UC3)
                if (this.message.Equals(null))
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.NULL_MOOD_EXCEPTION, "Message should not be null");
                else if (this.message.Equals(string.Empty))
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.EMPTY_MOOD_EXCEPTION, "Message should not be empty");
                else if (message.ToLower().Contains("sad"))
                    return "sad";
                else
                    return "happy";
            }
            catch (NullReferenceException)
            {
                return "happy";
            }
        }
    }
}