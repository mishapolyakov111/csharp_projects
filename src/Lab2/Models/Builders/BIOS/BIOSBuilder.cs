using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BIOSBuilder : IBIOSBuilder
{
    private string? _type;
    private string? _name;
    private string? _version;
    private List<string> _supportedProcessors = new List<string>();

    public IBIOSBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBIOSBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IBIOSBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBIOSBuilder AddSupportedProcessor(string processorName)
    {
        _supportedProcessors.Add(processorName);
        return this;
    }

    public BIOS Build()
    {
        return new BIOS(
            name: _name,
            type: _type,
            version: _version,
            supportedProcessors: _supportedProcessors);
    }
}