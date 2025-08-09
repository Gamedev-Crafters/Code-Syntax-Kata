using FluentAssertions;
namespace Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        bool result = Check("<");
        
        result.Should().BeFalse();
    }
    
    public bool Check(string input)
    {
        return false;
    }
}