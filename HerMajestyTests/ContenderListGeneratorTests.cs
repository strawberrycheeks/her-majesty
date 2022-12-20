using FluentAssertions;

using HerMajesty.Model;

namespace HerMajestyTests;

[TestFixture]
public class ContenderListGeneratorTests
{
    private readonly string _filepath = "../../../../HerMajesty/res/100-unique-names.txt";
    private IContenderListGenerator _generator;
    
    [SetUp]
    public void SetUp()
    {
        _generator = new ContenderListGenerator();
    }
    
    [Test]
    public void GenerateContenderList_ReturnsListOf100UniqueContenders()
    {
        var generatedList = _generator.GenerateContenderList(_filepath);
        generatedList.Count.Should().Be(100);
        generatedList.Should().OnlyHaveUniqueItems();
    }
}