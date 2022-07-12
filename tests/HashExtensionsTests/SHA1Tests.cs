using System;

namespace PowerUtils.Security.Tests.HashExtensionsTests;

public class SHA1Tests
{
    [Fact]
    public void Null_ToSHA1_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.ToSHA1());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Theory]
    [InlineData("", "da39a3ee5e6b4b0d3255bfef95601890afd80709")]
    [InlineData("HelloWorld", "db8ac1c259eb89d4a131b253bacfca5f319d54f2")]
    [InlineData(".net", "bd5802379396fa85be00404cff552e59b824820d")]
    [InlineData("a123456", "895b317c76b8e504c2fb32dbb4420178f60ce321")]
    public void SomeText_ToSHA1_Hash(string text, string sha1)
    {
        // Arrange & Act
        var act = text.ToSHA1();


        // Assert
        act.Should()
            .Be(sha1);
    }
}
