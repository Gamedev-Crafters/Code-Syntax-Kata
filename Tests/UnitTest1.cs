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
        if (!AreSymbolsPaired(input)) 
            return false;

        if (IsEndingWithLessThan(input))
            return false;
        
        if (IsStartingWithGreaterThan(input))
            return false;

        return RecursiveCheck(input);
    }

    static bool RecursiveCheck(string input)
    {
        if(!input.Contains("<>"))
            return false;
        
        input = input.Replace("<>", string.Empty);
        
        if (input.Length == 0)
            return true;
        
        return RecursiveCheck(input);
    }

    static bool IsStartingWithGreaterThan(string input)
    {
        return input[0] == '>';
    }

    static bool IsEndingWithLessThan(string input)
    {
        return input[^1] == '<';
    }

    static bool AreSymbolsPaired(string input)
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
        
        return lessThanCount == greaterThanCount;
    }
}