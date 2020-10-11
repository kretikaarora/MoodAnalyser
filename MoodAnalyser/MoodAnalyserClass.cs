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
                if (this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
                } 
            catch(NullReferenceException exception)
            {
                return "HAPPY";
            }
            
        }
    }
}
