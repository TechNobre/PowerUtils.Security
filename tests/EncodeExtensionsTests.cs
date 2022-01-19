using System;

namespace PowerUtils.Security.Tests;

[Trait("Category", "Encode")]
[Trait("Extension", "EncodeExtensions")]
public class EncodeExtensionsTests
{
    [Fact(DisplayName = "Try to encode a null text - Should return an 'ArgumentNullException'")]
    public void ToBase64_Null_ArgumentNullException()
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

    [Fact(DisplayName = "Try to decode from a null base64 - Should return an 'ArgumentNullException'")]
    public void FromBase64_Null_ArgumentNullException()
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

    [Theory(DisplayName = "Encode and decode text - Should return to original text")]
    [InlineData("")]
    [InlineData("HelloWorld")]
    [InlineData(".net")]
    [InlineData("a123456")]
    public void EncodeDecode_Flow_ReturnToOriginalText(string text)
    {
        // Arrange & Act
        var cipherText = text.ToBase64();
        var act = cipherText.FromBase64();


        // Assert
        act.Should()
            .Be(text);
    }
}
