using FluentAssertions;
using MSCoip.Application.Common.Exceptions;
using NUnit.Framework;

namespace MSCoip.Application.UnitTests.Common.Exceptions;

/// <summary>
/// BadRequestExceptionTests
/// </summary>
public class BadRequestExceptionTests
{
    /// <summary>
    /// DefaultConstructorCreatesAnExceptionWithMessage
    /// </summary>
    /// <param name="message"/>
    [Test]
    [TestCase("Data Not Found")]
    public void DefaultConstructorCreatesAnExceptionWithMessage(string message)
    {
        var actual = new BadRequestException(message);

        actual.Message.Should().BeEquivalentTo(message);
    }
}
