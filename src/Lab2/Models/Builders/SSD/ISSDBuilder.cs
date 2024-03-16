using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ISSDBuilder : IBuilder<SSD>
{
    ISSDBuilder WithName(string name);
    ISSDBuilder WithMemorySize(int memorySize);
    ISSDBuilder WithConnector(string connector);
    ISSDBuilder WithWattage(int wattage);
    ISSDBuilder WithWorkingSpeed(int workingSpeed);
}