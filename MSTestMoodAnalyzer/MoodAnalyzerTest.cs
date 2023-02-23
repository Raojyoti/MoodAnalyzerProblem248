using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;
using System.ComponentModel;
using System.Reflection;

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
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(excepted, ex.Message);
            }
        }
        
        /// <summary>
        /// TC4.1- Given MoodAnalyser ClassName Should Return MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturnMoodAnalyserObject()
        {
            object excepted = new MoodAnalyser();
            object obj = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            excepted.Equals(obj);
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
                Object excepted = new MoodAnalyser();
                object actual = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyzerProblem.Customer", "Customer");
                actual.Equals(excepted);
            }
            catch (MoodAnalysisException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
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
                Object excepted = new MoodAnalyser();
                Object actual = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "Customer");
                actual.Equals(excepted);
            }
            catch (MoodAnalysisException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }
        /// <summary>
        /// TC5.1- Given MoodAnalyser ClassName Should Return MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserShouldReturnMoodAnalyserObject()
        {
            string message = "Happy";
            object excepted = new MoodAnalyser(message);
            object actual = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", message);
            Console.WriteLine("Here Excepted object ==> \"{0}\" and \nActual object  ==> \"{1}\" ", excepted, actual+ "\nBoth are equal");
            excepted.Equals(actual);
        }
        /// <summary>
        /// /*TC5.2 Given Class Name When Improper_ShouldThrowMoodAnalyserExpection*/
        /// </summary>
        [TestMethod]
        public void GivenClassNameWhenImproperShouldThrowMoodAnalyserExpectionUsingParameterizedConstructor()
        {
            string exceptedMsg = "Class Not Found";
            try
            {
                string message = "Happy";
                //MoodAnalyser actual = (MoodAnalyser)MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");//proper className and proper constructorname
                MoodAnalyser excepted = new MoodAnalyser(message);
                MoodAnalyser actual = (MoodAnalyser)MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProblem.Customer", "Customer", message);
                actual.Equals(excepted);
            }
            catch (MoodAnalysisException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }
        /// <summary>
        /// /*TC5.3- GivenClassWhenConstructorNotProper_ShouldThrowMoodAnalyserExpection*/
        /// </summary>
        [TestMethod]
        public void GivenClassWhenConstructorNotProperShouldThrowMoodAnalyserExpectionUsingParameterizedConstructor()
        {
            string exceptedMsg = "Constructor is not found";
            try
            {
                string message = "Happy";
                MoodAnalyser excepted = new MoodAnalyser(message);
                object actual = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyser", "Customer", message);
                actual.Equals(excepted);
            }
            catch (MoodAnalysisException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }
        /// <summary>
        /// TC6.1 Give HAPPY message with Reflector should return HAPPY
        /// </summary>
        [TestMethod]
        public void SetHappyMessagewithReflectorShouldReturnHAPPY()
        {
            string expected = "Happy";
            try
            {
                string mood = MoodAnalyserReflector.InvokedAnalyseMood("Happy", "AnalyserMood");
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC6.2 Given Happy Message When Improper Method Should Throw MoodAnalysisException.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessageWhenImproperMethodShouldThrowMoodAnalysisException()
        {
            string expected = "Happy";
            try
            {
                string mood = MoodAnalyserReflector.InvokedAnalyseMood("Happy", "Customer");
            }
            catch (MoodAnalysisException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}
