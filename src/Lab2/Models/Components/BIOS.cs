using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BIOS : IBuilderDirector<IBIOSBuilder>
{
    public BIOS(string? name, string? version, string? type, IReadOnlyCollection<string> supportedProcessors)
    {
        ArgumentNullException.ThrowIfNull(version);
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        Version = version;
        Type = type;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get;  }
    public string Name { get;  }
    public string Version { get;  }
    public IReadOnlyCollection<string> SupportedProcessors { get; }

    public IBIOSBuilder Direct(IBIOSBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WithType(Type);
        builder.WithVersion(Version);
        foreach (string processor in SupportedProcessors)
        {
            builder.AddSupportedProcessor(processor);
        }

        return builder;
    }
}