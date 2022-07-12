using System;

namespace PowerUtils.Security.Tests.HashExtensionsTests;

public class MD5Tests
{
    [Fact]
    public void Null_ToMD5_ArgumentNullException()
    {
        // Arrange
        string text = null;


        // Act
        var act = Record.Exception(() => text.ToMD5());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(text)}')");
    }

    [Theory]
    [InlineData("", "d41d8cd98f00b204e9800998ecf8427e")]
    [InlineData("HelloWorld", "68e109f0f40ca72a15e05cc22786f8e6")]
    [InlineData(".net", "2d50972fcecd376129545507f1062089")]
    [InlineData("a123456", "dc483e80a7a0bd9ef71d8cf973673924")]
    public void SomeText_ToMD5_Hash(string text, string MD5)
    {
        // Arrange & Act
        var act = text.ToMD5();


        // Assert
        act.Should()
            .Be(MD5);
    }
}
