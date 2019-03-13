using Moq;
using NUnit.Framework;
using Soundex_CSharp_NUnit;

namespace SoundexTests
{
    public class SoundexAlgorithmTests
    {
        private IAlgorithmData soundexData;
        private IAlgorithm soundex;

        [SetUp]
        public void Init()
        {
            soundexData = new SoundexData();
            soundex = new SoundexAlgorithm(soundexData);
        }

        [Test]
        public void WhenTheWordIsEmptyThenReturn0000()
        {
            string expectedValue = soundex.Encode("");

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhentTheWordIsNullThenReturn0000()
        {
            string expectedValue = soundex.Encode(null);

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhenTheWordHaveOneCharThenFillTheWordBy0()
        {
            string expectedValue = soundex.Encode("w");

            Assert.AreEqual(expectedValue, "w000");
        }

        [Test]
        public void WhenTheWordHaveUpperCaseThenChancgeToLowerCase()
        {
            string expectedValue = soundex.Encode("ABCD");

            Assert.AreEqual(expectedValue, "a123");
        }

        [Test]
        public void WhenTheWordHaveFourCharsWithDifferentNumbersThenReturnEncodedWord()
        {
            string expectedValue = soundex.Encode("bcdm");

            Assert.AreEqual(expectedValue, "b235");
        }

        [Test]
        public void WhenTheWordHaveMoreThanOneCharAndLessThanFourCharsThenAdd0()
        {
            string expectedValue = soundex.Encode("an");

            Assert.AreEqual(expectedValue, "a500");
        }

        [Test]
        public void WhenTheWordHaveMoreThanFourCharsThenRemoveRedundantChars()
        {
            string expectedValue = soundex.Encode("anrtzv");

            Assert.AreEqual(expectedValue, "a563");
        }

        [Test]
        public void WhenTheWordHaveNeighboringCharsWithTheSameNumberThenRemoveAllThisCharsWitchoutFirst()
        {
            string expectedValue = soundex.Encode("accb");

            Assert.AreEqual(expectedValue, "a210");
        }

        [Test]
        public void WhenTheWordHaveCharsWhichDoNotExistInDictionaryThenRemoveThisChars()
        {
            string expectedValue = soundex.Encode("acob");

            Assert.AreEqual(expectedValue, "a210");
        }

        [Test]
        public void WhenTheWordHaveSpecialCharsThenReplaceThisCharsTo0()
        {
            string expectedValue = soundex.Encode("!%#&");

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByWThenEncodeLikeOneNumber()
        {            
            string expectedValue = soundex.Encode("bgwjlm");

            Assert.AreEqual(expectedValue, "b245");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByHThenEncodeLikeOneNumber()
        {
            string expectedValue = soundex.Encode("bghjlm");

            Assert.AreEqual(expectedValue, "b245");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByVowelThenEncodeTwice()
        {
            string expectedValue = soundex.Encode("bditv");

            Assert.AreEqual(expectedValue, "b331");
        }

        [TestCase("Robert")]
        [TestCase("Rupert")]
        public void WhentTheWordIsRobertOrRupertThenReturnR163(string word)
        {
            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "r163");
        }

        [TestCase("Rubin")]
        public void WhentTheWordIsRubinThenReturnR150(string word)
        {
            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "r150");
        }

        [TestCase("Ashcraft")]
        [TestCase("Ashcroft")]
        public void WhentTheWordIsAshcraftOrAshcroftThenReturnA261(string word)
        {
            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "a261");
        }

        [TestCase("Tymczak")]
        public void WhentTheWordIsTymczakThenReturnT522(string word)
        {
            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "t522");
        }

        [TestCase("Pfister")]
        public void WhentTheWordIsPfisterThenReturnP123(string word)
        {
            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "p123");
        }

        [TestCase("Honeyman")]
        public void WhentTheWordIsHoneymanThenReturnH555(string word)
        {
            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "h555");
        }

        [Test]
        public void WhenCallToSaveMethodThenTheNumberOfCalledToSaveWordMethodIsOne()
        {
            var soundexMock = new Mock<ISaveData>();
            var dataContainer = new DataContaioner(soundexMock.Object);
            dataContainer.Save("abcd");

            soundexMock.Verify(m => m.SaveWord(It.IsAny<string>()), Times.Once);
        }
    }
}
