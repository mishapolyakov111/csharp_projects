namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GPUBuilder : IGPUBuilder
{
    private string? _name;
    private int _legth;
    private int _width;
    private int _frequency;
    private int _wattage;
    private string? _versionPCI;

    public GPU Build()
    {
        return new GPU(
            _name,
            _width,
            _frequency,
            _wattage,
            _versionPCI,
            _legth);
    }

    public IGPUBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IGPUBuilder WithLegth(int length)
    {
        _legth = length;
        return this;
    }

    public IGPUBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public IGPUBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IGPUBuilder WithWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public IGPUBuilder WithVersionPCI(string versionPCI)
    {
        _versionPCI = versionPCI;
        return this;
    }
}