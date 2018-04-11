using NUnit.Framework;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Candidate_Pass()
        {
            var c = new Candidate()
            {
                IsEligible = true,
                PassedTechTest = true,
                PassedInterview = true
            };
            Recruit(c)
                .Match(
                    (x) => Assert.Fail(x.Reason),
                    (y) => Assert.Pass()
                );
        }

        [Test]
        public void Candidate_Fail()
        {
            var c = new Candidate()
            {
                IsEligible = true,
                PassedTechTest = true
            };
            Recruit(c)
                .Match(
                    (x) => Assert.Pass(x.Reason),
                    (y) => Assert.Fail()
                );
        }


        static Either<Rejection, Candidate> Recruit(Candidate c)
            => Right(c)
                .Bind(CheckEligibility)
                .Bind(TechTest)
                .Bind(Interview);

        static Either<Rejection, Candidate> CheckEligibility(Candidate c)
        {
            if (c.IsEligible) return c;
            else return new Rejection("Not Eligible");
        }

        static Either<Rejection, Candidate> TechTest(Candidate c)
        {
            if (c.PassedTechTest) return c;
            else return new Rejection("Failed Test");
        }

        static Either<Rejection, Candidate> Interview(Candidate c)
        {
            if (c.PassedInterview) return c;
            else return new Rejection("Failed Interview");
        }

    }



    class Candidate
    {
        public bool IsEligible { get; set; }
        public bool PassedTechTest { get; set; }
        public bool PassedInterview { get; set; }
    }

    class Rejection
    {
        public Rejection(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; }
    }
}