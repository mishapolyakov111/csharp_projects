using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RAMBuilder : IRAMBuilder
{
    private string? _name;
    private int _memorySize;
    private List<JEDEC> _supportedJEDEC = new List<JEDEC>();
    private List<XMP?> _supportedXMP = new List<XMP?>();
    private string? _versionDDR;
    private int _wattage;

    public RAM Build()
    {
        return new RAM(
            _memorySize,
            _supportedJEDEC,
            _supportedXMP,
            _versionDDR,
            _wattage,
            _name);
    }

    public IRAMBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRAMBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRAMBuilder AddSupportedJEDEC(JEDEC pair)
    {
        _supportedJEDEC.Add(pair);
        return this;
    }

    public IRAMBuilder AddSupportedXMP(XMP? xmpProfile)
    {
        if (xmpProfile is not null) _supportedXMP.Add(xmpProfile);
        return this;
    }

    public IRAMBuilder WithVersionDDR(string versionDDR)
    {
        _versionDDR = versionDDR;
        return this;
    }

    public IRAMBuilder WithWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }
}