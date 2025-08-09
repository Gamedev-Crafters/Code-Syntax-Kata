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
    
    public bool Check(string input)
    {
        return input.Contains("<>");
    }
}