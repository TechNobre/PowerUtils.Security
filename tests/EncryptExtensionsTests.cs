using System;

namespace PowerUtils.Security.Tests;

public class EncryptExtensionsTests
{
    private readonly string _passPhrase;

    public EncryptExtensionsTests() =>
        _passPhrase = "dsafdsfsdf40954387";



    [Fact]
    public void Null_Encrypt_ArgumentNullException()
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

    [Fact]
    public void Null_Decrypt_ArgumentNullException()
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

    [Fact]
    public void NullPassPhrase_Encrypt_ArgumentNullException()
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

    [Fact]
    public void NullPassPhrase_Decrypt_ArgumentNullException()
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

    [Theory]
    [InlineData("", "fsdfd")]
    [InlineData("HelloWorld", "fssdf4523543dfd")]
    [InlineData(".net", "")]
    [InlineData("a123456", "gdfgdfg")]
    public void Flow_EncryptAndDecrypt_ReturnToOriginalText(string text, string passPhrase)
    {
        // Arrange & Act
        var cipherText = text.Encrypt(passPhrase);
        var act = cipherText.Decrypt(passPhrase);


        // Assert
        act.Should()
            .Be(text);
    }
}
