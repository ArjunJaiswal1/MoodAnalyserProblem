using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Method to test sad message(UC1-TC1.1)
        [TestCategory("SAD Message")]
        public void GivenSadMoodShouldReturnSAD()

        {

            //Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodStatus moodAnalyse = new MoodStatus(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        //Method to test happy message(UC1-TC1.2)
        [TestCategory("HAPPY Message")]
        public void GivenAnyMoodShouldReturnHAPPY()

        {
            //Arrange

            string expected = "HAPPY";
            string message = "I am in Happy Mood";
            MoodStatus moodAnalyse = new MoodStatus(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
    }
}
    

