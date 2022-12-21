using FluentAssertions;
using Microsoft.Extensions.Configuration;

using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajestyTests;

[TestFixture]
public class ContenderListGeneratorTests
{
    private IContenderListGenerator _generator;
    
    [SetUp]
    public void SetUp()
    {
        _generator = new ContenderListGenerator();
    }
    
    [Test]
    public void GenerateContenderList_ReturnsListOf100UniqueContenders()
    {
        AppSettings.LoadConfigurationSettings(
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build());
        
        var generatedList = _generator.GenerateContenderList();
        generatedList.Count.Should().Be(100);
        generatedList.Should().OnlyHaveUniqueItems();
    }
}