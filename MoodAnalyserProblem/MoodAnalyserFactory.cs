using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    /// <summary>
    /// Creating MoodAnalyserFactory To Specify Static Method To Create MoodAnalyser Object
    /// </summary>
    public class MoodAnalyzerFactory
    {
        //Method to create mood analyser object
        public object CreateMoodAnalyserObject(string className, string constructor)
        {
            //Matching the pattern for extension of namespance
            string p = @"." + constructor + "$";
            Match result = Regex.Match(className, p);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (Exception)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.CLASS_NOT_FOUND, "The Given Class IS Not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND, "The Given Constructor Is Not Found");
            }
        }
    }
}