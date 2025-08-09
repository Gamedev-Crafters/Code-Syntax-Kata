using FluentAssertions;
namespace Tests;

public class Tests
{
    [Test]
    public void LessThanIsIncorrect()
    {
        bool result = Check("<");
        
        result.Should().BeFalse();
    }
    
    [Test]
    public void LessThanGreaterThanIsCorrect()
    {
        bool result = Check("<>");
        
        result.Should().BeTrue();
    }
    
    [Test]
    public void OneLessThanGreaterThanNestedIsCorrect()
    {
        bool result = Check("<<>>");
        
        result.Should().BeTrue();
    }
    
    [Test]
    public void TwoLessThanGreaterThanNestedIsCorrect()
    {
        bool result = Check("<<<>>>");
        
        result.Should().BeTrue();
    }
    
    [Test]
    public void ldkfjjlksdjskdjf()
    {
        bool result = Check("<<>><>");
        
        result.Should().BeTrue();
    }

    [Test]
    public void EndWithLessThanIsIncorrect()
    {
        bool result = Check("<><");
        
        result.Should().BeFalse();
    }
    
    [Test]
    public void StartWithGreaterThanIsIncorrect()
    {
        bool result = Check("><>");
        
        result.Should().BeFalse();
    }
    
    [Test]
    public void InputLenghtIsEven()
    {
        bool result = Check("<>>");
        
        result.Should().BeFalse();
    }
    
    [Test]
    public void LessThanAndGreaterThanArePaired()
    {
        bool result = Check("<>>>");
        
        result.Should().BeFalse();
    }
    
    [Test]
    public void sdgsdg()
    {
        bool result = Check("<>><<>");
        
        result.Should().BeFalse();
    }

    [Test]
    public void ContainIncorrectSymbols()
    {
        bool result = Check("P<>P");
        
        result.Should().BeFalse();
    }

    [TestCase("[<>]", true)]
    [TestCase("[<><>[]]", true)]
    [TestCase("<>[]<>[]", true)]
    [TestCase("<[<>]>", true)]
    [TestCase("<[><]>", false)]
    [TestCase("[<][>]", false)]
    public void CheckSquareBrackets(string input, bool expected)
    {
        bool result = Check(input);
        
        result.Should().Be(expected);
    }
    
    public bool Check(string input)
    {
        while (input.Contains("<>") || input.Contains("[]"))
        {
            input = input.Replace("[]", string.Empty);
            input = input.Replace("<>", string.Empty);
        }

        return input.Length == 0;
    }
}