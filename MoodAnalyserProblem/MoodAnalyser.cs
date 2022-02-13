using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodStatus
    {
        private string message;

        public MoodStatus(string message)
        {
            this.message = message;
        }

        //<summary>
        // Parameterized Constructor
        // </summary>
        // <returns></returns>
        public string AnalyseMood()
        {
            if (this.message.Contains("Sad"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
    }
}
