using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Security.Tests;

[Trait("Category", "Encrypt")]
[Trait("Extension", "EncryptExtensions")]
public class EncryptExtensionsTests
{
    private readonly string _passPhrase;

    public EncryptExtensionsTests() =>
        _passPhrase = "dsafdsfsdf40954387";

    [Fact(DisplayName = "Try to encrypt a null text - Should return an 'ArgumentNullException'")]
    public void Encrypt_Null_ArgumentNullException()
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
    public void Decrypt_Null_ArgumentNullException()
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

    [Theory(DisplayName = "Encrypt and decrypt text - Should return to original text")]
    [InlineData("", "fsdfd")]
    [InlineData("HelloWorld", "fssdf4523543dfd")]
    [InlineData(".net", "534")]
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
