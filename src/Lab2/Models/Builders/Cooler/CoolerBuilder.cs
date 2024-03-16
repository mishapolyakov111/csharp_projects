using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CoolerBuilder : ICoolerBuilder
{
    private string? _name;
    private int _size;
    private List<string> _supportedSockets = new List<string>();
    private int _maxTDP;

    public Cooler Build()
    {
        return new Cooler(
            _size,
            _supportedSockets,
            _maxTDP,
            _name);
    }

    public ICoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICoolerBuilder WithSize(int size)
    {
        _size = size;
        return this;
    }

    public ICoolerBuilder AddSupportedSockets(string socket)
    {
        _supportedSockets.Add(socket);
        return this;
    }

    public ICoolerBuilder WithMaxTDP(int tdp)
    {
        _maxTDP = tdp;
        return this;
    }
}