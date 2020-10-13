using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace EmotionAnalyser
{
    public class MoodAnalyser
    {
        private string message;
        /// <summary>
        /// this is a parametarised constructor <see cref="MoodAnalyser"/> class.
        /// </summary>     
       public MoodAnalyser(string message)
        {
            this.message = message;
            Console.WriteLine("parameterised constructor");
            Console.WriteLine(message);
        }
        /// <summary>
        /// This is non parametarised constructor of  <see cref="MoodAnalyser"/> class.
        /// </summary>
        public MoodAnalyser()
        {
            Console.WriteLine("default constructor");
        }
        public string AnalyseMood()
        {
            try {
                if (this.message.Equals(string.Empty))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "mood should not be empty");
                if (this.message.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
                } 
            catch(NullReferenceException  )
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "mood should not be null");
            }
            
        }

    }
}
