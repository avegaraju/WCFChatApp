using EA.Common.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Test.Common
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test]
        public void InputWithNoArguments()
        {
            string[] args = new string[0];
            bool isValid = Validator.IsValid(args);

            Assert.AreEqual(false, isValid);

        }
        [Test]
        public void InputWithTextPortNumber()
        {
            string[] args = new string[1];
            args[0] = "test";
            bool isValid = Validator.IsValid(args);

            Assert.AreEqual(false, isValid);
        }
        [Test]
        public void InputWithMoreParametersThanRequired()
        {
            string[] args = new string[2];
            args[0] = "test";
            args[1] = "1212";
            bool isValid = Validator.IsValid(args);
        }
    }
}
