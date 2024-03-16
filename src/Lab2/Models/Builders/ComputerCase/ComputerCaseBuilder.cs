namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private string? _name;
    private int _width;
    private int _height;
    private int _length;
    private int _maxGPULength;
    private int _maxGPUWidth;
    private string? _motherBoardFormFactor;

    public ComputerСase Build()
    {
        return new ComputerСase(
            _name,
            _width,
            _height,
            _length,
            _maxGPULength,
            _maxGPUWidth,
            _motherBoardFormFactor);
    }

    public IComputerCaseBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public IComputerCaseBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public IComputerCaseBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public IComputerCaseBuilder WithMaxGPULength(int gpuLength)
    {
        _maxGPULength = gpuLength;
        return this;
    }

    public IComputerCaseBuilder WithMaxGPUWidth(int gpuWidth)
    {
        _maxGPUWidth = gpuWidth;
        return this;
    }

    public IComputerCaseBuilder WithMotherBoardFormFactor(string formFactor)
    {
        _motherBoardFormFactor = formFactor;
        return this;
    }

    public IComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
}