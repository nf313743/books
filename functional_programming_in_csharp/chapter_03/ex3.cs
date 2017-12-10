// Write a type Email that wraps an underlying string, enforcing that it’s in a valid
// format. Ensure that you include the following:
//   * A smart constructor
//   * Implicit conversion to string, so that it can easily be used with the typical API
// for sending emails

using System.Text.RegularExpressions;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace chapter03
{
    [TestClass]
    public class Ex3_Test
    {
        [TestMethod]
        public void InvalidEmail_None()
        {
            Assert.AreEqual(None, Email.Create("sdfsdghdf"));

        }


        [TestMethod]
        public void ValidEmail_Some()
        {
            var result = Email.Create("hello@gmail.com");
            
            Email email = result.Match
            (
                None: () => throw new ArgumentException(),
                Some: (e) => e
            );

            Assert.AreEqual("hello@gmail.com", email.Value);
        }
    }

    public class Email
    {
        public static Option<Email> Create(string email)
            => regex.IsMatch(email)
                    ? Some(new Email(email))
                    : None;

        public Email(string email) => Value = email;

        static readonly Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public string Value { get; }

        public static implicit operator string(Email x) => x.Value;
    }
}