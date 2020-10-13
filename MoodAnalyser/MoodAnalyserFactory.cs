using EmotionAnalyser;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace EmotionAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Creating an object for mood analyser class using non parameterised constructor
        /// </summary>

        public static object CreateMoodAnalyse(string ClassName, String ConstructorName)
        {
            string pattern = @"." + ConstructorName + "$";
            var result = Regex.Match(ClassName, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(ClassName);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "no such class is found");
                }


            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "no such constructor found");
        }
      
    }
}
