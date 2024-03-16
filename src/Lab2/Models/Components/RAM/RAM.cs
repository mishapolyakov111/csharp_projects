using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RAM : IBuilderDirector<IRAMBuilder>
{
    public RAM(
        int memorySize,
        IReadOnlyCollection<JEDEC> supportedJedec,
        IReadOnlyCollection<XMP?> supportedXmp,
        string? versionDdr,
        int wattage,
        string? name)
    {
        ArgumentNullException.ThrowIfNull(versionDdr);
        ArgumentNullException.ThrowIfNull(name);

        MemorySize = memorySize;
        SupportedJEDEC = supportedJedec;
        SupportedXMP = supportedXmp;
        VersionDDR = versionDdr;
        Wattage = wattage;
        Name = name;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public IReadOnlyCollection<JEDEC> SupportedJEDEC { get; }
    public IReadOnlyCollection<XMP?> SupportedXMP { get; }
    public string VersionDDR { get; }
    public int Wattage { get; }

    public IRAMBuilder Direct(IRAMBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithName(Name)
            .WithMemorySize(MemorySize)
            .WithWattage(Wattage)
            .WithVersionDDR(VersionDDR);

        foreach (XMP? xmp in SupportedXMP)
        {
            builder.AddSupportedXMP(xmp);
        }

        foreach (JEDEC jedec in SupportedJEDEC)
        {
            builder.AddSupportedJEDEC(jedec);
        }

        return builder;
    }
}