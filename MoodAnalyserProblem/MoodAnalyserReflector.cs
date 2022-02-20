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
    
    public class MoodAnalyserReflector
    {
        //Method To Create Mood Analyser Object Using Reflection(UC4)
        public object CreateMoodAnalyserObject(string className, string constructor)
        {
            //Matching The Pattern For Extension Of Namespace
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
        //Method To Use Create MoodAnalyser with Parameter Constructor Using Reflection(UC5)
        public object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        {
            Type type = typeof(MoodAnalyse);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND, "No Such Constructor");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.CLASS_NOT_FOUND, "No Such Class");
            }
        }
        //Method to Use Reflection To Invoke Method i.e analyseMood(UC6)
        public string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyse);
                MethodInfo methodInfo = type.GetMethod(methodName);
                MoodAnalyserReflector reflector = new MoodAnalyserReflector();
                object moodAnalyserObject = reflector.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblems.MoodAnalyser", "MoodAnalyser", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionTypes.METHOD_NOT_FOUND, "No Such Method");
            }
        }
    }
}