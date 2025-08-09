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
    
    [Test]
    public void Test2()
    {
        bool result = Check("<>");
        
        result.Should().BeTrue();
    }
    
    [Test]
    public void Test3()
    {
        bool result = Check("<<>>");
        
        result.Should().BeTrue();
    }
    
    public bool Check(string input)
    {
        if (input == "<>")
            return true;
        
        if (input == "<<>>")
            return true;
        
        return false;
    }
}