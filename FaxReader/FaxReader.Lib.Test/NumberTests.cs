using NUnit.Framework;

namespace FaxReader.Lib.Test
{
    class NumberTests
    {
        [Test]
        public void Parse_NumberZero_GiveZero()
        {
            var number = new Number()
            {
                Lines = Definitions.Zero
            };

            number.Parse();

            Assert.AreEqual(0, number.Value);
        }

        [Test]
        public void Parse_NumberOne_GivenOne()
        {
            var number = new Number()
            {
                Lines = Definitions.One
            };

            number.Parse();

            Assert.AreEqual(1, number.Value);
        }

        [Test]
        public void Parse_NumberTwo_GivenTwo()
        {
            var number = new Number()
            {
                Lines = Definitions.Two
            };

            number.Parse();

            Assert.AreEqual(2, number.Value);
        }

        [Test]
        public void Parse_NumberThree_GivenThree()
        {
            var number = new Number()
            {
                Lines = Definitions.Three
            };

            number.Parse();

            Assert.AreEqual(3, number.Value);
        }

        [Test]
        public void Parse_NumberFour_GivenFour()
        {
            var number = new Number()
            {
                Lines = Definitions.Four
            };

            number.Parse();

            Assert.AreEqual(4, number.Value);
        }

        [Test]
        public void Parse_NumberFive_GivenFive()
        {
            var number = new Number()
            {
                Lines = Definitions.Five
            };

            number.Parse();

            Assert.AreEqual(5, number.Value);
        }

        [Test]
        public void Parse_NumberSix_GivenSix()
        {
            var number = new Number()
            {
                Lines = Definitions.Six
            };

            number.Parse();

            Assert.AreEqual(6, number.Value);
        }

        [Test]
        public void Parse_NumberSeven_GivenSeven()
        {
            var number = new Number()
            {
                Lines = Definitions.Seven
            };

            number.Parse();

            Assert.AreEqual(7, number.Value);
        }

        [Test]
        public void Parse_NumberEight_GivenEight()
        {
            var number = new Number()
            {
                Lines = Definitions.Eight
            };

            number.Parse();

            Assert.AreEqual(8, number.Value);
        }

        [Test]
        public void Parse_NumberNine_GivenNine()
        {
            var number = new Number()
            {
                Lines = Definitions.Nine
            };

            number.Parse();

            Assert.AreEqual(9, number.Value);
        }
    }
}