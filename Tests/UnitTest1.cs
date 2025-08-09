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
    
    public bool Check(string input)
    {
        int lessThanCount = 0;
        int greaterThanCount = 0;

        foreach (char c in input)
        {
            if(c == '<')
            {
                lessThanCount++;
            }
            else if(c == '>')
            {
                greaterThanCount++;
            }
        }
        
        if(lessThanCount != greaterThanCount)
            return false;
        
        if (input[^1] == '<')
            return false;
        
        if (input[0] == '>')
            return false;
        
        if(input.Length % 2 != 0)
            return false;
        
        return input.Contains("<>");
    }
}