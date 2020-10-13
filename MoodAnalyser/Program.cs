using System;

namespace EmotionAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //using default constructor 
            //bject obj = MoodAnalyserFactory.CreateMoodAnalyse("EmotionAnalyser.MoodAnalyser", "MoodAnalyser");
            //this happy messsage parameter will be passed to message in parameterised constructor
            object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject("EmotionAnalyser.MoodAnalyser", "MoodAnalyser","Happy");
            MoodAnalyser mood = (MoodAnalyser)obj; //Converting object to MoodAnalyser class object so that we can call using it
            Console.WriteLine(mood);

        }
    }
}
