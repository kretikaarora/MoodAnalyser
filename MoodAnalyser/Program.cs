// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// 
using System;

namespace EmotionAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //using default constructor 
            //object obj = MoodAnalyserFactory.CreateMoodAnalyse("EmotionAnalyser.MoodAnalyser", "MoodAnalyser");
            //this happy messsage parameter will be passed to message in parameterised constructor
            object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject("EmotionAnalyser.MoodAnalyser", "MoodAnalyser","Happy");
            MoodAnalyser mood = (MoodAnalyser)obj; //Converting object to MoodAnalyser class object so that we can call using it
            Console.WriteLine(mood);

        }
    }
}
