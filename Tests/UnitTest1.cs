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
    
    public bool Check(string input)
    {
        return IterativeCheck(input);
    }

    static bool IterativeCheck(string input)
    {
        while (input.Contains("<>"))
        {
            input = input.Replace("<>", string.Empty);
        }

        return input.Length == 0;
    }
}