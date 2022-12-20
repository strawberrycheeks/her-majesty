using FluentAssertions;

using HerMajesty.Model;

namespace HerMajestyTests;

[TestFixture]
public class ContenderListGeneratorTests
{
    private const string Filepath = "../../../../HerMajesty/res/100-unique-names.txt";
    private IContenderListGenerator _generator;
    
    [SetUp]
    public void SetUp()
    {
        _generator = new ContenderListGenerator();
    }
    
    [Test]
    public void GenerateContenderList_ReturnsListOf100UniqueContenders()
    {
        var generatedList = _generator.GenerateContenderList(Filepath);
        generatedList.Count.Should().Be(100);
        generatedList.Should().OnlyHaveUniqueItems();
    }
}