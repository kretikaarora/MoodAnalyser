using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmotionAnalyser;

namespace MoodAnalyserUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        MoodAnalyser moodAnalyser;
        [TestInitialize]
        public void setup()
        {
            
        }
        [TestMethod]
        public void GivenSadMoodShouldReturnSad()
        {
            //arrange
            string expected = "SAD";
            string message = "I am in a sad mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string mood = moodAnalyser.AnalyseMood();
            //assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
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
