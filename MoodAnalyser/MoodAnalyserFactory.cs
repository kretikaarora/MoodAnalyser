﻿using System;
using System.Reflection;
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
      /// <summary>
        /// Creates the object mood analyser class using parameterized constructor.
        /// </summary>

        public static object CreateMoodAnalyserParameterizedObject(string className, string constructorName, string message)
        {
            string pattern = @"." + constructorName + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType, message);
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "no such class is found");
                }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "no such constructor found");
            }
        }


        /// THIS METHOD CAN ALSO BE USED FOR PARAMETRISED CONSTRUCTOR(ALTERNATIVE WAY)

        //public static object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        //{
        //    Type type = typeof(MoodAnalyser);
        //    if (type.Name == className || type.FullName == className)
        //    {
        //        if (type.Name.Equals(constructor))
        //        {
        //            ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
        //            object obj = construct.Invoke(new object[] { message });
        //            return obj;
        //        }


        //        else
        //            throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "no such constructor found");
        //    }
        //    else
        //        throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "no such class is found");

        //}             
        /// <summary>
        /// Invoking Analyser Mood Method
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">no such method is found</exception>
        public static string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("EmotionAnalyser.MoodAnalyser");
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = CreateMoodAnalyserParameterizedObject("EmotionAnalyser.MoodAnalyser", "MoodAnalyser", "Happy");
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "no such method is found");

            }
        }
        /// <summary>
        /// Dynamically setting field variable using Reflection
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// message should be null
        /// or
        /// no field found
        /// </exception>
        public static string SetField(string message , string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "message should be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;

            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "no field found");
            }
            
        }

    }
}
