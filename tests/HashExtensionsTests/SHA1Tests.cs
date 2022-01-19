using System;

namespace PowerUtils.Security.Tests.HashExtensionsTests;

[Trait("Category", "Hash")]
[Trait("Extension", "HashExtensions")]
[Trait("Hash", "SHA1")]
public class SHA1Tests
{
    [Fact(DisplayName = "Try hashing a null text to SHA1 - Should return an 'ArgumentNullException'")]
    public void ToSHA1_Null_ArgumentNullException()
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

    [Theory(DisplayName = "Hashing valid texts - Should return a SHA1")]
    [InlineData("", "da39a3ee5e6b4b0d3255bfef95601890afd80709")]
    [InlineData("HelloWorld", "db8ac1c259eb89d4a131b253bacfca5f319d54f2")]
    [InlineData(".net", "bd5802379396fa85be00404cff552e59b824820d")]
    [InlineData("a123456", "895b317c76b8e504c2fb32dbb4420178f60ce321")]
    public void ToSHA1_Hashing_ArgumentNullException(string text, string sha1)
    {
        // Arrange & Act
        var act = text.ToSHA1();


        // Assert
        act.Should()
            .Be(sha1);
    }
}
