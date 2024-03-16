namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class SSDBuilder : ISSDBuilder
{
    private string? _name;
    private int _memorySize;
    private string? _connector;
    private int _wattage;
    private int _workingSpeed;

    public SSD Build()
    {
        return new SSD(_name, _memorySize, _connector, _wattage, _workingSpeed);
    }

    public ISSDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISSDBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public ISSDBuilder WithConnector(string connector)
    {
        _connector = connector;
        return this;
    }

    public ISSDBuilder WithWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public ISSDBuilder WithWorkingSpeed(int workingSpeed)
    {
        _workingSpeed = workingSpeed;
        return this;
    }
}