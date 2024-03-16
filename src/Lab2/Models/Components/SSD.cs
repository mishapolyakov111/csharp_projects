using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class SSD : IDrive, IBuilderDirector<ISSDBuilder>
{
    public SSD(string? name, int memorySize, string? connector, int wattage, int workingSpeed)
    {
        ArgumentNullException.ThrowIfNull(connector);
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        MemorySize = memorySize;
        Connector = connector;
        Wattage = wattage;
        WorkingSpeed = workingSpeed;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public string Connector { get; }
    public int Wattage { get; }
    public int WorkingSpeed { get; }

    public ISSDBuilder Direct(ISSDBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithMemorySize(MemorySize)
            .WithConnector(Connector)
            .WithWattage(Wattage)
            .WithWorkingSpeed(WorkingSpeed);

        return builder;
    }
}