using System;

namespace PowerUtils.Security.Tests.HashExtensionsTests;

[Trait("Category", "Hash")]
[Trait("Extension", "HashExtensions")]
[Trait("Hash", "SHA512")]
public class SHA512Tests
{
    [Fact(DisplayName = "Try hashing a null text to SHA512 - Should return an 'ArgumentNullException'")]
    public void ToSHA512_Null_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.ToSHA512());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Theory(DisplayName = "Hashing valid texts - Should return a SHA512")]
    [InlineData("", "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e")]
    [InlineData("HelloWorld", "8ae6ae71a75d3fb2e0225deeb004faf95d816a0a58093eb4cb5a3aa0f197050d7a4dc0a2d5c6fbae5fb5b0d536a0a9e6b686369fa57a027687c3630321547596")]
    [InlineData(".net", "2327072c613f9173e321946d4dc2fc2c7fe01bdecd246060bdc4c0a6728620567945546c67f1843975e4036e3f5a012ef773e436fb7faf5a19933ac02258fb05")]
    [InlineData("a123456", "410752b9f6fef035ccb2b469bcc473d7d43e93a108332bc1eb3208412d599bb4478eea687c69f962d7670410b06deaeac77578452f7c2454f3100d017a802b7e")]
    public void ToSHA512_Hashing_ArgumentNullException(string text, string sha512)
    {
        // Arrange & Act
        var act = text.ToSHA512();


        // Assert
        act.Should()
            .Be(sha512);
    }
}
