using System;
using System.Text;

namespace PowerUtils.Security.Tests;

public class UtilsAuthTests
{
    [Fact]
    public void NullUsername_ToBasicAuth_ArgumentNullException()
    {
        // Arrange
        string username = null;
        var password = "";


        // Act
        var act = Record.Exception(() => UtilsAuth.ToBasicAuth(username, password));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(username)}')");
    }

    [Fact]
    public void NullPassword_ToBasicAuth_ArgumentNullException()
    {
        // Arrange
        var username = "";
        string password = null;


        // Act
        var act = Record.Exception(() => UtilsAuth.ToBasicAuth(username, password));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(password)}')");
    }

    [Fact]
    public void NullAuth_FromBasicAuth_ArgumentNullException()
    {
        // Arrange
        string auth = null;


        // Act
        var act = Record.Exception(() => auth.FromBasicAuth());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();

        act.Message.Should()
            .Be($"Value cannot be null. (Parameter '{nameof(auth)}')");
    }

    [Fact]
    public void InvalidBase64_FromBasicAuth_ArgumentException()
    {
        // Arrange
        var auth = "sds";


        // Act
        var act = Record.Exception(() => auth.FromBasicAuth());


        // Assert
        act.Should()
            .BeOfType<ArgumentException>();

        act.Message.Should()
            .Be($"Invalid authentication. (Parameter '{nameof(auth)}')");
    }

    [Fact]
    public void InvalidAuth_FromBasicAuth_ArgumentException()
    {
        // Arrange
        var auth = "username:password:extra";
        var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));


        // Act
        var act = Record.Exception(() => base64.FromBasicAuth());


        // Assert
        act.Should()
            .BeOfType<ArgumentException>();

        act.Message.Should()
            .Be($"Invalid authentication. (Parameter '{nameof(auth)}')");
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("jon", "a123456")]
    [InlineData("username", "password")]
    [InlineData("kelly", "11234")]
    public void Flow_EncodeAndDecode_ReturnToOriginalText(string username, string password)
    {
        // Arrange & Act
        var auth = UtilsAuth.ToBasicAuth(username, password);
        var (actUsername, actPassword) = auth.FromBasicAuth();


        // Assert
        actUsername.Should()
            .Be(username);
        actPassword.Should()
            .Be(password);
    }
}
