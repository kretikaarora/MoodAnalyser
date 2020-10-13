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
        /// this is a parametarised constructor <see cref="MoodAnalyserClass"/> MoodAnalyserclass.
        /// </summary>     
       public MoodAnalyser(string message)
        {
            this.message = message;
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
