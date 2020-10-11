using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmotionAnalyser;

namespace MoodAnalyserUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSadMoodShouldReturnSad()
        {
            //arrange
            string expected = "SAD";
            string message = "I am in a sad Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string mood = moodAnalyser.AnalyseMood();
            //assert
            Assert.AreEqual(expected, mood);

        }
    }
}
