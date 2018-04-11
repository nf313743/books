namespace Candidate.Tests

open NUnit.Framework

type Candidate(isEligible, passedTest, passedInterview) =
    member this.IsEligible = isEligible
    member this.PassedTest = passedTest
    member this.PassedInterview = passedInterview

[<TestClass>]
type TestClass () =

    [<Test>]
    member this.Candidate_Pass () =
        let c = new Candidate(true, true, true)
        Assert.Pass()

