namespace PowerUtils.Security.Tests;

public class AnonymizationExtensionsTests
{
    [Theory]
    [InlineData(null, "t****N")]
    [InlineData("", "t****N")]
    [InlineData("tN", "f****g")]
    [InlineData("t****N", "f****g")]
    [InlineData("t****g", "f****g")]
    [InlineData("tsdfsdfsdfsdfsdfsdN", "t****N")]
    [InlineData("242342342344sdfsd", "2****d")]
    [InlineData("Nelson Nobre", "N****e")]
    public void SomeText_Anonymize_TextFormatted(string text, string expected)
    {
        // Arrange & Act
        var act = text.Anonymize();


        // Assert
        act.Should()
            .Be(expected);
    }
}
