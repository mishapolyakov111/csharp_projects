namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class HDDBuilder : IHDDBuilder
{
    private string? _name;
    private int _memorySize;
    private string? _connector;
    private int _wattage;
    private int _rotationSpeed;

    public HDD Build()
    {
        return new HDD(
            _name,
            _memorySize,
            _connector,
            _wattage,
            _rotationSpeed);
    }

    public IHDDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHDDBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IHDDBuilder WithConnector(string connector)
    {
        _connector = connector;
        return this;
    }

    public IHDDBuilder WithWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public IHDDBuilder WithRotationSpeed(int rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
        return this;
    }
}