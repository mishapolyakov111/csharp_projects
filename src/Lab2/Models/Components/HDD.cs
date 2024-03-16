using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class HDD : IDrive, IBuilderDirector<IHDDBuilder>
{
    public HDD(
        string? name,
        int memorySize,
        string? connector,
        int wattage,
        int rotationSpeed)
    {
        ArgumentNullException.ThrowIfNull(connector);
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        MemorySize = memorySize;
        Connector = connector;
        Wattage = wattage;
        RotationSpeed = rotationSpeed;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public string Connector { get; }
    public int Wattage { get; }
    public int RotationSpeed { get; }

    public IHDDBuilder Direct(IHDDBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithConnector(Connector)
            .WithWattage(Wattage)
            .WithMemorySize(MemorySize)
            .WithRotationSpeed(RotationSpeed);

        return builder;
    }
}