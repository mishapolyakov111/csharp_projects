using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CPU : IBuilderDirector<ICPUBuilder>
{
    public CPU(
        int wattage,
        int tdp,
        string? graphicsCore,
        int coreFrequency,
        int coresNumber,
        string? socket,
        string? name,
        IEnumerable<int> supportedRamFrequencies)
    {
        ArgumentNullException.ThrowIfNull(socket);
        ArgumentNullException.ThrowIfNull(name);
        Wattage = wattage;
        TDP = tdp;
        GraphicsCore = graphicsCore;
        CoreFrequency = coreFrequency;
        CoresNumber = coresNumber;
        Socket = socket;
        Name = name;
        SupportedRamFrequencies = supportedRamFrequencies;
    }

    public string Name { get; }
    public string Socket { get; }
    public int CoresNumber { get; }
    public int CoreFrequency { get; }
    public string? GraphicsCore { get; }
    public IEnumerable<int> SupportedRamFrequencies { get; }
    public int TDP { get; }
    public int Wattage { get; }

    public ICPUBuilder Direct(ICPUBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithCPUName(Name);
        builder.WithSocket(Socket);
        builder.WithCoresNumber(CoresNumber);
        builder.WithCoreFrequency(CoreFrequency);

        if (GraphicsCore is not null)
        {
            builder.WithGraphicsCore(GraphicsCore);
        }

        foreach (int supportedRamFrequency in SupportedRamFrequencies)
        {
            builder.AddSupportedRamFrequency(supportedRamFrequency);
        }

        builder.WithTDP(TDP);
        builder.WithWattage(Wattage);

        return builder;
    }
}