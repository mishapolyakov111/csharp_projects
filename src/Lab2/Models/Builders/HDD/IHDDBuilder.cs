using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IHDDBuilder : IBuilder<HDD>
{
    IHDDBuilder WithName(string name);
    IHDDBuilder WithMemorySize(int memorySize);
    IHDDBuilder WithConnector(string connector);
    IHDDBuilder WithWattage(int wattage);
    IHDDBuilder WithRotationSpeed(int rotationSpeed);
}