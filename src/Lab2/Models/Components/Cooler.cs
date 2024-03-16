using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cooler : IBuilderDirector<ICoolerBuilder>
{
    public Cooler(
        int size,
        IReadOnlyCollection<string> supportedSockets,
        int maxTdp,
        string? name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Size = size;
        SupportedSockets = supportedSockets;
        MaxTDP = maxTdp;
        Name = name;
    }

    public string Name { get; }
    public int Size { get; }
    public IReadOnlyCollection<string> SupportedSockets { get; }
    public int MaxTDP { get; }

    public ICoolerBuilder Direct(ICoolerBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithName(Name).WithSize(Size).WithMaxTDP(MaxTDP);
        foreach (string socket in SupportedSockets)
        {
            builder.AddSupportedSockets(socket);
        }

        return builder;
    }
}