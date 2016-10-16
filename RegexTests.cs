using System;
using System.Text.RegularExpressions;
using FlimFlan.ReadableRex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReadableRegexTests
{
    [TestClass]
    public class RegexTests
    {
        [TestMethod]
        public void ValidSocialSecurityNumber_Expect_Match()
        {
            var socialSecurityNumberCheck = new Regex(Pattern.With.AtBeginning
                                                      .Digit.Repeat.Exactly(3)
                                                      .Literal("-").Repeat.Optional
                                                      .Digit.Repeat.Exactly(2)
                                                      .Literal("-").Repeat.Optional
                                                      .Digit.Repeat.Exactly(4)
                                                      .AtEnd);

            var validSSN = "123-55-7788";
            var result = socialSecurityNumberCheck.IsMatch(validSSN);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InValidSocialSecurityNumber_Expect_ZeroMatch()
        {
            var socialSecurityNumberCheck = new Regex(Pattern.With.AtBeginning
                                                      .Digit.Repeat.Exactly(3)
                                                      .Literal("-").Repeat.Optional
                                                      .Digit.Repeat.Exactly(2) // Fails this condition
                                                      .Literal("-").Repeat.Optional
                                                      .Digit.Repeat.Exactly(4)
                                                      .AtEnd);

            var invalidSSN = "123-555-7788";
            var result = socialSecurityNumberCheck.IsMatch(invalidSSN);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidAustralianPhoneFormat_Expect_Match()
        {

            // Australian phone format +61 2 98776655
            var pattern =
                Pattern.With.AtBeginning.Literal("+61").Repeat.Exactly(1)
                .WhiteSpace.Repeat.Exactly(1)
                .Digit.Repeat.Exactly(1)
                .WhiteSpace.Repeat.Exactly(1)
                .Digit.Repeat.Exactly(8);

            Console.WriteLine(pattern);
            var phoneValidator = new Regex(pattern);
            var result = phoneValidator.IsMatch("+61 7 85225588");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InValidPhoneFormat_Expect_ZeroMatch()
        {
            var pattern =
                 Pattern.With.AtBeginning.Literal("+61").Repeat.Exactly(1)
                 .WhiteSpace.Repeat.Exactly(1)
                 .Digit.Repeat.Exactly(1)
                 .WhiteSpace.Repeat.Exactly(1)
                 .Digit.Repeat.Exactly(8);

            Console.WriteLine(pattern);
            var phoneValidator = new Regex(pattern);
            var result = phoneValidator.IsMatch("+61 97 85225588");
            Assert.IsFalse(result);
        }
    }
}
