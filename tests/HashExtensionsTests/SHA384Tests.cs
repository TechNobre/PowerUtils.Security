using System;

namespace PowerUtils.Security.Tests.HashExtensionsTests;

public class SHA384Tests
{
    [Fact]
    public void Null_ToSHA384_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.ToSHA384());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Theory]
    [InlineData("", "38b060a751ac96384cd9327eb1b1e36a21fdb71114be07434c0cc7bf63f6e1da274edebfe76f65fbd51ad2f14898b95b")]
    [InlineData("HelloWorld", "293cd96eb25228a6fb09bfa86b9148ab69940e68903cbc0527a4fb150eec1ebe0f1ffce0bc5e3df312377e0a68f1950a")]
    [InlineData(".net", "63445539fe2110568f6b337befd535b60ae55336c3cbcddb4cc83adeae3e70a4f38c5a849f3cf0bedc54bebb77b3384b")]
    [InlineData("a123456", "fec1bb0e04ed484a4e5e37e585c9d15f863db7e7f5585e047a1be80e269d50abb177e61c264f6c0443e4d8e26b235d8e")]
    public void SomeText_ToSHA384_Hash(string text, string sha384)
    {
        // Arrange & Act
        var act = text.ToSHA384();


        // Assert
        act.Should()
            .Be(sha384);
    }
}
