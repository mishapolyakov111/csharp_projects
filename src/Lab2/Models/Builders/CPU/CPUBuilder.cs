using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CPUBuilder : ICPUBuilder
{
    private string? _name;
    private string? _socket;
    private int _coresNumber;
    private int _coreFrequency;
    private string? _graphicsCore;
    private List<int> _supportedRamFrequencies = new List<int>();
    private int _tdp;
    private int _wattage;

    public ICPUBuilder WithCPUName(string name)
    {
        _name = name;
        return this;
    }

    public ICPUBuilder WithSocket(string socketName)
    {
        _socket = socketName;
        return this;
    }

    public ICPUBuilder WithCoresNumber(int number)
    {
        _coresNumber = number;
        return this;
    }

    public ICPUBuilder WithCoreFrequency(int frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public ICPUBuilder WithGraphicsCore(string graphicCoreName)
    {
        _graphicsCore = graphicCoreName;
        return this;
    }

    public ICPUBuilder AddSupportedRamFrequency(int frequency)
    {
        _supportedRamFrequencies.Add(frequency);
        return this;
    }

    public ICPUBuilder WithTDP(int tpd)
    {
        _tdp = tpd;
        return this;
    }

    public ICPUBuilder WithWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }

    public CPU Build()
    {
        return new CPU(
            _wattage,
            _tdp,
            _graphicsCore,
            _coreFrequency,
            _coresNumber,
            _socket,
            _name,
            _supportedRamFrequencies);
    }
}