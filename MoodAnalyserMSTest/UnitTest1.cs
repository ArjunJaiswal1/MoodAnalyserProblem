using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
using System;
namespace MoodAnalyserProblem
{
    /// <summary>
    /// Different Test Cases For Analysing Mood
    /// </summary>
    [TestClass]
    public class TestingMood
    {
        //Method to test sad message(UC1-TC1.1)
        [TestCategory("Sad Message")]
        [TestMethod]
        public void TestSadMoodMessage()
        {
            ///AAA
            ///Arange
            string msg = "I am in Sad Mood";
            string expected = "sad";
            MoodAnalyse mood = new MoodAnalyse(msg);
            ///Act
            string actual = mood.AnalyzeMood();

            ///Asert
            Assert.AreEqual(expected, actual);
        }
        //Method to test happy message(UC1-TC1.2)
        [TestCategory("Happy Message")]
        [TestMethod]
        public void TestHappyMoodMessage()
        {
            ///AAA
            ///Arange
            string msg = "I am in Any Mood";
            string expected = "happy";
            MoodAnalyse mood = new MoodAnalyse(msg);
            ///Act
            string actual = mood.AnalyzeMood();
            ///Asert
            Assert.AreEqual(expected, actual);
        }
        //Method to test happy message(UC2-TC2.1)
        [TestCategory("Null Exception")]
        [TestMethod]
        public void TestNullMessageException()
        {
            ///AAA
            ///Arange
            string msg = null;
            string expected = "happy";
            string actual = null;
            MoodAnalyse mood = new MoodAnalyse(msg);

            

            ///Act
            actual = mood.AnalyzeMood();

            ///Asert
            Assert.AreEqual(expected, actual);

        }

        //Method to test custom exception message(UC3-TC3.1)
        [TestCategory("Custom Exception")]
        [TestMethod]
        public void TestCustomNullException()
        {
            ///AAA
            ///Arange
            string msg = null;
            string expected = "Message should not be null";
            MoodAnalyse mood = new MoodAnalyse(msg);

            try
            {
                ///Act
                string actual = mood.AnalyzeMood();
            }
            catch (MoodAnalysisException e)
            {
                ///Asert
                Assert.AreEqual(expected, e.Message);
            }
        }

        //Method to test custom exception message(UC3-TC3.2)
        [TestCategory("Custom Exception")]
        [TestMethod]
        public void TestCustomEmptyException()
        {
            ///AAA
            ///Arange
            string msg = "";
            string expected = "Message should not be empty";
            MoodAnalyse mood = new MoodAnalyse(msg);
            try
            {
                ///Act
                string actual = mood.AnalyzeMood();
            }
            catch (MoodAnalysisException e)
            {
                ///Asert
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}
