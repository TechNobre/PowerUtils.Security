using System;
using System.Text;

namespace PowerUtils.Security.Tests;

[Trait("Category", "Encode")]
[Trait("Extension", "UtilsAuth")]
public class UtilsAuthTests
{
    [Fact(DisplayName = "Try to encode to basic authentication with null username - Should return an 'ArgumentNullException'")]
    public void ToBasicAuth_NullUsername_ArgumentNullException()
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

    [Fact(DisplayName = "Try to encode to basic authentication with null password - Should return an 'ArgumentNullException'")]
    public void ToBasicAuth_NullPassword_ArgumentNullException()
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

    [Fact(DisplayName = "Try to decode from a null basic authentication - Should return an 'ArgumentNullException'")]
    public void FromBasicAuth_NullAuth_ArgumentNullException()
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

    [Fact(DisplayName = "Try to decode from a invalid base64 - Should return an 'ArgumentNullException'")]
    public void FromBasicAuth_InvalidBase64_ArgumentException()
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

    [Fact(DisplayName = "Try to decode from a invalid basic authentication - Should return an 'ArgumentNullException'")]
    public void FromBasicAuth_InvalidAuth_ArgumentException()
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

    [Theory(DisplayName = "Encode and decode basic authentication - Should return the username and password")]
    [InlineData("", "")]
    [InlineData("jon", "a123456")]
    [InlineData("username", "password")]
    [InlineData("kelly", "11234")]
    public void EncodeDecode_Flow_ReturnToOriginalText(string username, string password)
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
