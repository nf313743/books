/*
Write a ToOption extension method to convert an Either into an Option ; the
left value is thrown away if present. Then write a ToEither method to convert
an Option into an Either , with a suitable parameter that can be invoked to
obtain the appropriate Left value if the Option is None . (Tip: start by writing
the function signatures in arrow notation.)
 */

using System;
using NUnit.Framework;
using LaYumba.Functional;
using static LaYumba.Functional.F;

internal class Pass {}
internal class Fail {}
public class Ex01
{
    // (Left, Right) -> Option

    [Test]
    public void ToOption_IsNone()
    {
        Either<Fail, Pass> eitherToTest = Left(new Fail());
        var result = eitherToTest.ToOption();
        Assert.AreEqual(None, result);
    }

    [Test]
    public void ToOption_IsSome()
    {
        Either<Fail, Pass> eitherToTest = Right(new Pass());
        var result = eitherToTest.ToOption().Match(
            () => throw new Exception(),
            (y) => y);
        
        Assert.AreEqual(result.GetType(), typeof(Pass) );
    }
}

public static class EitherExt2
{
    public static Option<R> ToOption<L,R>(this Either<L,R> @this)
        => @this.Match(
            _ => None,
            x => Some(x)
        );

    public static Either<L, R> ToEither<L,R>(this Option<R> @this)
        => @this.Match(
            x => Left(default(L)),
            y => Right(y)
        )
}