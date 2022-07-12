using System;

namespace PowerUtils.Security.Tests;

public class EncodeExtensionsTests
{
    [Fact]
    public void Null_ToBase64_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.ToBase64());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Fact]
    public void Null_FromBase64_ArgumentNullException()
    {
        // Arrange
        string base64 = null;


        // Act
        var act = Record.Exception(() => base64.FromBase64());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(base64)}')");
    }

    [Theory]
    [InlineData("")]
    [InlineData("HelloWorld")]
    [InlineData(".net")]
    [InlineData("a123456")]
    public void Flow_ToBase64AndFromBase64_ReturnToOriginalText(string text)
    {
        // Arrange & Act
        var cipherText = text.ToBase64();
        var act = cipherText.FromBase64();


        // Assert
        act.Should()
            .Be(text);
    }
}
