using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmotionAnalyser;

namespace MoodAnalyserUnitTest
{
    [TestClass]
    public class UnitTest1
    {    
        [TestMethod]
        [DataRow("I am in a sad mood")]
        public void GivenSadMoodShouldReturnSad(string message)
        {
            //arrange
            string expected = "SAD";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string mood = moodAnalyser.AnalyseMood();
            //assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        //[DataRow("I am in sad mood")]
        [DataRow(null)]
        public void GivenNullShouldReturnHappy(string message)
        {
            //arrange
            string expected = "HAPPY";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string mood = moodAnalyser.AnalyseMood();
            //assert
            Assert.AreEqual(expected, mood);
        }
    }
}
