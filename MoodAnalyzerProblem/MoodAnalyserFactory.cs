﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
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
    }
}

