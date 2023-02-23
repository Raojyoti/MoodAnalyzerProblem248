using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// UC4- CreateMoodAnalyse method to create of MoodAnalyser class. 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException"></exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            bool result = Regex.IsMatch(className, pattern);
            if (result)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (Exception )
                {
                    Console.WriteLine("When Class Name ==> \"{0}\" is Improper so here \nthrow MoodAnalyserExpection", className);
                    throw new MoodAnalysisException("Class Not Found",MoodAnalysisException.ExceptionTypes.NO_SUCH_CLASS);
                }
            }
            else
            {
                Console.WriteLine("Here ClassName \"{0}\" is proper but\nConstructorName \"{1}\" is Improper\nSo here throw MoodAnalysisException", className,constructorName);
                throw new MoodAnalysisException("Constructor is not found", MoodAnalysisException.ExceptionTypes.NO_SUCH_CONSTRUCTOR);
            }
        }
        /// <summary>
        /// UC5- CreateMoodAnalyse method to create object of MoodAnalyser class.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException"></exception>
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    Console.WriteLine("Here ClassName \"{0}\" is proper but\nConstructorName \"{1}\" is Improper\nSo here throw MoodAnalysisException", className, constructorName);
                    throw new MoodAnalysisException("Constructor is not found", MoodAnalysisException.ExceptionTypes.NO_SUCH_CONSTRUCTOR);
                }
            }
            else
            {
                Console.WriteLine("Here ClassName \"{0}\" is Improper\nSo here throw MoodAnalysisException ", className);
                throw new MoodAnalysisException("Class Not Found", MoodAnalysisException.ExceptionTypes.NO_SUCH_CLASS);
            }
        }
        /// <summary>
        /// UC6- Use reflection to invoke method.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokedAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "Happy");
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException )
            {
                Console.WriteLine("Given \"{0}\" message when Improper method ==> \"{1}\" should \nreturn MoodAnalysisException ", message,methodName);
                MoodAnalysisException exp = new MoodAnalysisException("No Such Field error",MoodAnalysisException.ExceptionTypes.NO_SUCH_METHOD);
                return exp.Message;
            }
        }
        /// <summary>
        /// UC7- Set the field Dynamically using Reflection.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException"></exception>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    Console.WriteLine("Setting \"Null\" message with Reflector should throw Exception ");
                    throw new MoodAnalysisException("Message should not be null", MoodAnalysisException.ExceptionTypes.NO_SUCH_FIELD);
                }
                field.SetValue(moodAnalyser, message);
                Console.WriteLine("Set \"{0}\" message with Reflector should return \"{1}\" ", message, moodAnalyser.message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Set field when Improper ==> \"{0}\" should \nthrow Exception ", fieldName);
                throw new MoodAnalysisException("Field is Not Found", MoodAnalysisException.ExceptionTypes.NO_SUCH_FIELD);
            }
        }
    }
}

