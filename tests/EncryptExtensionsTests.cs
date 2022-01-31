using System;

namespace PowerUtils.Security.Tests;

[Trait("Category", "Encrypt")]
[Trait("Extension", "EncryptExtensions")]
public class EncryptExtensionsTests
{
    private readonly string _passPhrase;

    public EncryptExtensionsTests() =>
        _passPhrase = "dsafdsfsdf40954387";

    [Fact(DisplayName = "Try to encrypt a null text - Should return an 'ArgumentNullException'")]
    public void Encrypt_NullText_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.Encrypt(_passPhrase));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Fact(DisplayName = "Try to decrypt a null cipher text - Should return an 'ArgumentNullException'")]
    public void Decrypt_NullText_ArgumentNullException()
    {
        // Arrange
        string cipherText = null;


        // Act
        var act = Record.Exception(() => cipherText.Decrypt(_passPhrase));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(cipherText)}')");
    }

    [Fact(DisplayName = "Try to encrypt a text with null passPhrase - Should return an 'ArgumentNullException'")]
    public void Encrypt_NullPassPhrase_ArgumentNullException()
    {
        // Arrange
        var text = "fake";
        string passPhrase = null;


        // Act
        var act = Record.Exception(() => text.Encrypt(passPhrase));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(passPhrase)}')");
    }

    [Fact(DisplayName = "Try to decrypt a cipher text with null passPhrase - Should return an 'ArgumentNullException'")]
    public void Decrypt_NullPassPhrase_ArgumentNullException()
    {
        // Arrange
        var cipherText = "fake";
        string passPhrase = null;


        // Act
        var act = Record.Exception(() => cipherText.Decrypt(passPhrase));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(passPhrase)}')");
    }

    [Theory(DisplayName = "Encrypt and decrypt text - Should return to original text")]
    [InlineData("", "fsdfd")]
    [InlineData("HelloWorld", "fssdf4523543dfd")]
    [InlineData(".net", "")]
    [InlineData("a123456", "gdfgdfg")]
    public void EncryptDecrypt_Flow_ReturnToOriginalText(string text, string passPhrase)
    {
        // Arrange & Act
        var cipherText = text.Encrypt(passPhrase);
        var act = cipherText.Decrypt(passPhrase);


        // Assert
        act.Should()
            .Be(text);
    }
}
