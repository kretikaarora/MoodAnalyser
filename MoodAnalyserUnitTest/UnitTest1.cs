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
        [TestMethod]
        [DataRow("I am in any mood")]        
        public void GivenAnyMoodShouldReturnHappy(string message)
        {
            //arrange
            string expected = "HAPPY";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string mood = moodAnalyser.AnalyseMood();
            //assert
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]        
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingEmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                
            }
            catch(MoodAnalyserCustomException e)
            {
                Assert.AreEqual("mood should not be empty", e.Message);
            }

        }
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingNullMood()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.AnalyseMood();
            }
            catch(MoodAnalyserCustomException e)
            {
                Assert.AreEqual("mood should not be null", e.Message);
            }

        }
        [TestMethod]
        public void GivenMoodAnalyserClassName_ShouldReturn_MoodAnalyserInstance()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("EmotionAnalyser.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyserInstance_UsingParametrisedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject("EmotionAnalyser.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenFactory_ShouldInvokeAnalyserMoodMethod_ReturnHappyMessge()
        {
            string expected = "Happy";
            string actual = MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "AnalyseMood");
            expected.Equals(actual);
        }
        [TestMethod]
        public  void GivenHappyMessage_viaReflector_ShoulGiveHappyMessage()
        {
            string expected = "Happy";
            string actual = MoodAnalyserFactory.SetField("Happy", "message");
            expected.Equals(actual);

        }


    }

}
