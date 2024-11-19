namespace TestSimulator;
using Simulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(7,5,10, 7)]
    [InlineData(20, 1, 10, 10)]
    [InlineData(-5, 3, 10, 3)]
    [InlineData(5, 5, 30, 5)]
    public void Validator_Limiter_ShouldPassCorrectly(int value, int min, int max, int output)
    {
        Assert.Equal(output, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("hello world", 5,15,'#',"Hello world")]
    [InlineData("123", 5, 10, '#', "123##")]
    [InlineData("   abc",5,10,'#',"Abc##")]
    [InlineData("Mikolajuio",5,10,'#',"Mikolajuio")]
    [InlineData("",5,10,'#',"#####")]
    [InlineData("a234567890321312312312312312",1,5,'#',"A2345")]
    public void Validator_Shortener_ShouldPassCorrectly(string value, int min, int max, char placeholder, string output)
    {
        Assert.Equal(output, Validator.Shortener(value, min, max, placeholder));
    }
}