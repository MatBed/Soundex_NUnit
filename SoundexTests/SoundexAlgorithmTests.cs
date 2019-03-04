using Moq;
using NUnit.Framework;
using Soundex_CSharp_NUnit;

namespace SoundexTests
{
    public class SoundexAlgorithmTests
    {
        [Test]
        public void WhenTheWordIsEmptyThenReturn0000()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("");

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhentTheWordIsNullThenReturn0000()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(null);

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhenTheWordHaveOneCharThenFillTheWordBy0()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("w");

            Assert.AreEqual(expectedValue, "w000");
        }

        [Test]
        public void WhenTheWordHaveUpperCaseThenChancgeToLowerCase()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("ABCD");

            Assert.AreEqual(expectedValue, "a123");
        }

        [Test]
        public void WhenTheWordHaveFourCharsWithDifferentNumbersThenReturnEncodedWord()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("bcdm");

            Assert.AreEqual(expectedValue, "b235");
        }

        [Test]
        public void WhenTheWordHaveMoreThanOneCharAndLessThanFourCharsThenAdd0()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("an");

            Assert.AreEqual(expectedValue, "a500");
        }

        [Test]
        public void WhenTheWordHaveMoreThanFourCharsThenRemoveRedundantChars()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("anrtzv");

            Assert.AreEqual(expectedValue, "a563");
        }

        [Test]
        public void WhenTheWordHaveNeighboringCharsWithTheSameNumberThenRemoveAllThisCharsWitchoutFirst()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("accb");

            Assert.AreEqual(expectedValue, "a210");
        }

        [Test]
        public void WhenTheWordHaveCharsWhichDoNotExistInDictionaryThenRemoveThisChars()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("acob");

            Assert.AreEqual(expectedValue, "a210");
        }

        [Test]
        public void WhenTheWordHaveSpecialCharsThenReplaceThisCharsTo0()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("!%#&");

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByWThenEncodeLikeOneNumber()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("bgwjlm");

            Assert.AreEqual(expectedValue, "b245");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByHThenEncodeLikeOneNumber()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("bghjlm");

            Assert.AreEqual(expectedValue, "b245");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByVowelThenEncodeTwice()
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode("bditv");

            Assert.AreEqual(expectedValue, "b331");
        }

        [TestCase("Robert")]
        [TestCase("Rupert")]
        public void WhentTheWordIsRobertOrRupertThenReturnR163(string word)
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "r163");
        }

        [TestCase("Rubin")]
        public void WhentTheWordIsRubinThenReturnR150(string word)
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "r150");
        }

        [TestCase("Ashcraft")]
        [TestCase("Ashcroft")]
        public void WhentTheWordIsAshcraftOrAshcroftThenReturnA261(string word)
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "a261");
        }

        [TestCase("Tymczak")]
        public void WhentTheWordIsTymczakThenReturnT522(string word)
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "t522");
        }

        [TestCase("Pfister")]
        public void WhentTheWordIsPfisterThenReturnP123(string word)
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "p123");
        }

        [TestCase("Honeyman")]
        public void WhentTheWordIsHoneymanThenReturnH555(string word)
        {
            IAlgorithmData soundexData = new SoundexData();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData);

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "h555");
        }

        [Test]
        public void WhenCallToEncodeMethodThenTheNumberOfCalledToEncodeWordMethodIsOne()
        {
            int timesCalled = 0;

            IAlgorithmData soundexData = new SoundexData();
            var soundexMock = new Mock<IAlgorithm>();
            SoundexAlgorithm soundex = new SoundexAlgorithm(soundexData, soundexMock.Object);

            soundexMock
                .Setup(x => x.EncodeWord(It.IsAny<string>()))
                .Callback(() => timesCalled++);

            soundex.Encode("abcd");

            Assert.That(timesCalled, Is.EqualTo(1));
        }
    }
}
