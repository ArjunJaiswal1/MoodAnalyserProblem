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
        //Method to test so moodanalyser class return moodanalyser objects(UC4-TC4.1)
        [TestCategory("Reflection")]
        
        [DataRow("MoodAnalyserProblems.Customer", "Customer")]
        [DataRow("MoodAnalyserProblems.MoodAnalyser", "MoodAnalyser")]
        public void ReturnDefaultConstructor(string className, string constructor)
        {
            MoodAnalyse expected = new MoodAnalyse();
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject(className, constructor);

            }
            catch (MoodAnalysisException ex)
            {
                throw new Exception(ex.Message);
            }
            expected.Equals(obj);
        }
        //Method to test so mood analyser with diff class to return no class found(UC4-TC4.2)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyserProblems.Linklist", "Linklist", "The Given Class IS Not Found")]
        [DataRow("MoodAnalyserProblems.Stack", "Stack", "The Given Class IS Not Found")]
        public void ReturnDefaultConstructorNoClassFound(string className, string constructor, string expected)
        {
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject(className, constructor);

            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        //Method to test so mood analyser class return  contructor not found(UC4-TC4.3)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyserProblems.MoodAnalyser", "Linklist", "The Given Constructor Is Not Found")]
        [DataRow("MoodAnalyserProblems.MoodAnalyser", "Customer", "The Given Constructor Is Not Found")]
        public void ReturnDefaultConstructorNoConstructorFound(string className, string constructor, string expected)
        {
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject(className, constructor);

            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        //Method to test moodanalyser class with parameter constructor to check if two objects are equal(UC5-TC5.1)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow("I am in Sad mood")]
        [DataRow("I am in any mood")]
        public void GivenMessageReturnParameterizedConstructor(string message)
        {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyse", "MoodAnalyse", message);

            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
            obj.Equals(expected);
        }

        //Method to test moodanalyser with diff class with parameter constructor to throw error(UC5-TC5.2)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyse.Queues", "I am in Happy mood", "No Such Class")]
        [DataRow("MoodAnalyse.Linkedlist", "I am in Sad mood", "No Such Class")]
        [DataRow("MoodAnalyse.Stack", "I am in any mood", "No Such Class")]
        public void GivenMessageReturnParameterizedClassNotFound(string className, string message, string expextedError)
        {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserParameterizedObject(className, "MoodAnalyse", message);

            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }

        //Method to test moodanalyser with diff constructor with parameter constructor to throw error(UC5-TC5.3)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Customer", "I am in Happy mood", "No Such Constructor")]
        [DataRow("Linkedlist", "I am in Sad mood", "No Such Constructor")]
        [DataRow("Stack", "I am in any mood", "No Such Constructor")]
        public void GivenMessageReturnParameterizedConstructorNotFound(string constructor, string message, string expextedError)
        {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyse", constructor, message);

            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }
    }
}
    

    

