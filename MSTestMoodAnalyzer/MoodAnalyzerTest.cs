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
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow("I am in Sad Mood", "SAD")]
        public void GivenSadMessageWhenAnalyzerShouldReturnSadMood(string message, string excepted)
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
        /// /*TC1.2 Given “I am in Any Mood” message Should Return HAPPY*/
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow("I am in Any Mood", "HAPPY")]
        public void GivenAnyMessageWhenAnalyzerShouldReturnHAPPYMood(string message, string excepted)
        {
            //AAA Methodology
            //Arrange
            MoodAnalyser mood = new MoodAnalyser(message);

            //Act
            string actual = mood.AnalyserMood();

            //Assert
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [DataRow(null, "HAPPY")]
        public void GivenNULLMessageWhenAnalyzerShouldReturnHAPPYMood(string message, string excepted)
        {
            //AAA Methodology
            //Arrange
            MoodAnalyser mood = new MoodAnalyser(message);

            //Act
            string actual = mood.AnalyserMood();

            //Assert
            Assert.AreEqual(excepted, actual);
        }
    }
}
