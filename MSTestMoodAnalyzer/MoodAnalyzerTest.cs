using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;
using System.ComponentModel;

namespace MSTestMoodAnalyzer
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        /// <summary>
        ///  /*TC1.1 Given “I am in Sad Mood” message Should Return SAD*/
        ///  /*TC1.2 Given “I am in Any Mood” message Should Return HAPPY*/
        ///  TC2.1-Given NULL mood Should Return HAPPY
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow("I am in Sad Mood", "SAD")]
        [DataRow("I am in Any Mood", "HAPPY")]
        //[DataRow(null, "HAPPY")]
        public void GivenMessageWhenAnalyzerShouldReturnMood(string message, string excepted)
        {
            //AAA Methodology
            //Arrange
            MoodAnalyser mood=new MoodAnalyser(message);

            //Act
            string actual=mood.AnalyserMood();

            //Assert
            Assert.AreEqual(excepted, actual);
        }
        /// <summary>
        /// TC3.1-Given NULL mood Should Throw MoodAnalysisException
        /// TC3.2-Given EMPTY mood Should Throw MoodAnalysisException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow(null, "Message is having null")]
        [DataRow("", "Message is having empty")]
        public void GivenNULLOrEMPTYMoodWhenAnalyzerShouldThrowMoodAnalysisException(string message, string excepted)
        {
            try
            {
                //AAA Methodology
                //Arrange
                MoodAnalyser mood = new MoodAnalyser(message);

                //Act
                string actual = mood.AnalyserMood();

                //Assert
                Assert.AreEqual(excepted, actual);
            }
            catch(MoodAnalysisException ex)
            {
                Assert.AreEqual(excepted, ex.Message);
            }
        }
        
        /// <summary>
        /// TC4.1- Given MoodAnalyser ClassName Should Return MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturnMoodAnalyserObject()
        {
            object actual = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            actual.Equals(obj);
        }
        /// <summary>
        /// /*TC4.2 Given Class Name When Improper_ShouldThrowMoodAnalyserExpection*/
        /// </summary>
        [TestMethod]
        public void GivenClassNameWhenImproperShouldThrowMoodAnalyserExpection()
        {
            string exceptedMsg = "Class Not Found";
            try
            {
                // MoodAnalyser actual = (MoodAnalyser)MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");//proper className and prober constructorname
                MoodAnalyser excepted = new MoodAnalyser();
                MoodAnalyser actual = (MoodAnalyser)MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.Customer", "Customer");
                actual.Equals(excepted);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }
        /// <summary>
        /// /*TC4.3- GivenClassWhenConstructorNotProper_ShouldThrowMoodAnalyserExpection*/
        /// </summary>
        [TestMethod]
        public void GivenClassWhenConstructorNotProperShouldThrowMoodAnalyserExpection()
        {
            string exceptedMsg = "Constructor is not found";
            try
            {
                MoodAnalyser excepted = new MoodAnalyser();
                MoodAnalyser actual = (MoodAnalyser)MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "Customer");
                actual.Equals(excepted);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }
    }
}
