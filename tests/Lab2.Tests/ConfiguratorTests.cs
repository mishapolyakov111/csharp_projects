using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ConfiguratorTests
{
    [Theory]
    [ClassData(typeof(FirstTestDataGenerator))]
    public void Build_ShouldBuildWithoutComments(IRepository repository)
    {
        // Arrange
        Configuration config = Configuration.Build
            .WithMotherBoard("GIGABYTE B550 AORUS ELITE V2")
            .WithCPU("AMD RYZEN 5 5600X")
            .WithCooler("DEEPCOOL AK620")
            .WithRAMList(new[] { "Kingston FURY Beast Black", "Kingston FURY Beast Black" })
            .WithPowerInput("GoodPower")
            .WithComputerCase("Case")
            .AddGPU("Nvidia GeForce RTX 3080 ti CORE")
            .AddHDD("HDD")
            .Build();

        // Act
        var computer = Computer.Build(config, repository);
        ConfigurationResult result = computer.GetConfigurationResult();

        // Assert
        Assert.True(result.Success);
        Assert.Empty(result.Comments);
    }

    [Theory]
    [ClassData(typeof(SecondTestDataGenerator))]
    public void Build_ShouldBuildWithCommentAboutLowPower(IRepository repository, string disclaimer, string lowPower)
    {
        // Arrange
        Configuration config = Configuration.Build
            .WithMotherBoard("GIGABYTE B550 AORUS ELITE V2")
            .WithCPU("AMD RYZEN 5 5600X")
            .WithCooler("DEEPCOOL AK620")
            .WithRAMList(new[] { "Kingston FURY Beast Black", "Kingston FURY Beast Black" })
            .WithPowerInput("LowPower")
            .WithComputerCase("Case")
            .AddGPU("Nvidia GeForce RTX 3080 ti CORE")
            .AddGPU("Nvidia GeForce RTX 3080 ti CORE")
            .AddHDD("HDD")
            .Build();

        // Act
        var computer = Computer.Build(config, repository);
        ConfigurationResult result = computer.GetConfigurationResult();

        // Assert
        Assert.True(result.Success);
        Assert.Contains(disclaimer, result.Comments);
        Assert.Contains(lowPower, result.Comments);
    }

    [Theory]
    [ClassData(typeof(ThirdTestDataGenerator))]
    public void Build_ShouldBuildWithCommentAboutBadCooler(IRepository repository, string disclaimer, string badCooler)
    {
        // Arrange
        Configuration config = Configuration.Build
            .WithMotherBoard("GIGABYTE B550 AORUS ELITE V2")
            .WithCPU("AMD RYZEN 5 5600X")
            .WithCooler("BAD COOLER")
            .WithRAMList(new[] { "Kingston FURY Beast Black", "Kingston FURY Beast Black" })
            .WithPowerInput("GoodPower")
            .WithComputerCase("Case")
            .AddGPU("Nvidia GeForce RTX 3080 ti CORE")
            .AddGPU("Nvidia GeForce RTX 3080 ti CORE")
            .AddHDD("HDD")
            .Build();

        // Act
        var computer = Computer.Build(config, repository);
        ConfigurationResult result = computer.GetConfigurationResult();

        // Assert
        Assert.True(result.Success);
        Assert.Contains(disclaimer, result.Comments);
        Assert.Contains(badCooler, result.Comments);
    }

    [Theory]
    [ClassData(typeof(FourthTestDataGenerator))]
    public void Build_InvalidBuildWithCommentAboutGPU(IRepository repository, string noGPU)
    {
        // Arrange
        Configuration config = Configuration.Build
            .WithMotherBoard("GIGABYTE B550 AORUS ELITE V2")
            .WithCPU("AMD RYZEN 5 5600X")
            .WithCooler("DEEPCOOL AK620")
            .WithRAMList(new[] { "Kingston FURY Beast Black", "Kingston FURY Beast Black" })
            .WithPowerInput("GoodPower")
            .WithComputerCase("Case")
            .AddHDD("HDD")
            .Build();

        // Act
        var computer = Computer.Build(config, repository);
        ConfigurationResult result = computer.GetConfigurationResult();

        // Assert
        Assert.False(result.Success);
        Assert.Contains(noGPU, result.Comments);
    }
}
