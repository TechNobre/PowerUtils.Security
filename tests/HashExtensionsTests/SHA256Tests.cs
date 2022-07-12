using System;

namespace PowerUtils.Security.Tests.HashExtensionsTests;

public class SHA256Tests
{
    [Fact]
    public void Null_ToSHA256_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.ToSHA256());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Theory]
    [InlineData("", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")]
    [InlineData("HelloWorld", "872e4e50ce9990d8b041330c47c9ddd11bec6b503ae9386a99da8584e9bb12c4")]
    [InlineData(".net", "fb74851c8bc7bdddbae440847e819521ea7b33b775e939692d6b22852530892e")]
    [InlineData("a123456", "20f645c703944a0027acf6fad92ec465247842450605c5406b50676ff0dcd5ea")]
    public void SomeText_ToSHA256_Hash(string text, string sha256)
    {
        // Arrange & Act
        var act = text.ToSHA256();


        // Assert
        act.Should()
            .Be(sha256);
    }
}
