using NUnit.Framework;
using Soundex_CSharp_NUnit;

namespace SoundexTests
{
    public class SoundexAlgorithmTests
    {
        [Test]
        public void WhenTheWordIsEmptyThenReturn0000()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("");

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhentTheWordIsNullThenReturn0000()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(null);

            Assert.AreEqual(expectedValue, "0000");
        }

        [Test]
        public void WhenTheWordHaveOneCharThenFillTheWordBy0()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("w");

            Assert.AreEqual(expectedValue, "w000");
        }

        [Test]
        public void WhenTheWordHaveUpperCaseThenChancgeToLowerCase()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("ABCD");

            Assert.AreEqual(expectedValue, "a123");
        }
        
        [Test]
        public void WhenTheWordHaveFourCharsWithDifferentNumbersThenReturnEncodedWord()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("bcdm");

            Assert.AreEqual(expectedValue, "b235");
        }

        [Test]
        public void WhenTheWordHaveMoreThanOneCharAndLessThanFourCharsThenAdd0()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("an");

            Assert.AreEqual(expectedValue, "a500");
        }

        [Test]
        public void WhenTheWordHaveMoreThanFourCharsThenRemoveRedundantChars()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("anrtzv");

            Assert.AreEqual(expectedValue, "a563");
        }

        [Test]
        public void WhenTheWordHaveNeighboringCharsWithTheSameNumberThenRemoveAllThisCharsWitchoutFirst()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("accb");

            Assert.AreEqual(expectedValue, "a210");
        }

        [Test]
        public void WhenTheWordHaveCharsWhichDoNotExistInDictionaryThenRemoveThisChars()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("acob");

            Assert.AreEqual(expectedValue, "a210");
        }

        [Test]
        public void WhenTheWordHaveSpecialCharsThenReplaceThisCharsTo0()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("!%#&");

            Assert.AreEqual(expectedValue, "0000");
        }
        
        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByWThenEncodeLikeOneNumber()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("bgwjlm");

            Assert.AreEqual(expectedValue, "b245");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByHThenEncodeLikeOneNumber()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("bghjlm");

            Assert.AreEqual(expectedValue, "b245");
        }

        [Test]
        public void WhenInTheWordTwoLettersWithTheSameNumberAreSeparatedByVowelThenEncodeTwice()
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode("bditv");

            Assert.AreEqual(expectedValue, "b331");
        }

        [TestCase("Robert")]
        [TestCase("Rupert")]
        public void WhentTheWordIsRobertOrRuperThenReturnR163(string word)
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "r163");
        }

        [TestCase("Rubin")]
        public void WhentTheWordIsRubinThenReturnR150(string word)
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "r150");
        }

        [TestCase("Ashcraft")]
        [TestCase("Ashcroft")]
        public void WhentTheWordIsAshcraftOrAshcroftThenReturnA261(string word)
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "a261");
        }

        [TestCase("Tymczak")]
        public void WhentTheWordIsTymczakThenReturnT522(string word)
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "t522");
        }

        [TestCase("Pfister")]
        public void WhentTheWordIsPfisterThenReturnP123(string word)
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "p123");
        }

        [TestCase("Honeyman")]
        public void WhentTheWordIsHoneymanThenReturnH555(string word)
        {
            SoundexAlgorithm soundex = new SoundexAlgorithm();

            string expectedValue = soundex.Encode(word);

            Assert.AreEqual(expectedValue, "h555");
        }
    }
}
