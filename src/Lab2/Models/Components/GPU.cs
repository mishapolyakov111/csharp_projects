using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GPU : IBuilderDirector<IGPUBuilder>
{
    public GPU(
        string? name,
        int width,
        int frequency,
        int wattage,
        string? versionPci,
        int legth)
    {
        ArgumentNullException.ThrowIfNull(versionPci);
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        Width = width;
        Frequency = frequency;
        Wattage = wattage;
        VersionPCI = versionPci;
        Legth = legth;
    }

    public string Name { get; }
    public int Legth { get; }
    public int Width { get; }
    public int Frequency { get; }
    public int Wattage { get; }
    public string VersionPCI { get; }

    public IGPUBuilder Direct(IGPUBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithLegth(Legth)
            .WithWidth(Width)
            .WithFrequency(Frequency)
            .WithWattage(Wattage)
            .WithVersionPCI(VersionPCI);

        return builder;
    }
}