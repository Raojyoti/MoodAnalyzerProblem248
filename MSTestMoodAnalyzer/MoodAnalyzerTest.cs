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
        [TestMethod]
        public void GivenSadMessageWhenAnalyzerShouldReturnSadMood()
        {
            //AAA Methodology
            //Arrange
            string message = "I am in Sad Mood";
            string excepted = "SAD";
            MoodAnalyser mood=new MoodAnalyser();

            //Act
            string actual=mood.AnalyserMood(message);

            //Assert
            Assert.AreEqual(excepted, actual);
        }
        /// <summary>
        /// /*TC1.2 Given “I am in Any Mood” message Should Return HAPPY*/
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        public void GivenAnyMessageWhenAnalyzerShouldReturnHAPPYMood()
        {
            //AAA Methodology
            //Arrange
            string message = "I am in Any Mood";
            string excepted = "HAPPY";
            MoodAnalyser mood = new MoodAnalyser();

            //Act
            string actual = mood.AnalyserMood(message);

            //Assert
            Assert.AreEqual(excepted, actual);
        }
    }
}
