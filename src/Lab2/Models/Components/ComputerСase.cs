using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerСase : IBuilderDirector<IComputerCaseBuilder>
{
    public ComputerСase(
        string? name,
        int width,
        int height,
        int length,
        int maxGpuLength,
        int maxGpuWidth,
        string? motherBoardFormFactor)
    {
        ArgumentNullException.ThrowIfNull(motherBoardFormFactor);
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        Width = width;
        Height = height;
        Length = length;
        MaxGPULength = maxGpuLength;
        MaxGPUWidth = maxGpuWidth;
        MotherBoardFormFactor = motherBoardFormFactor;
    }

    public string Name { get;  }
    public int Width { get; }
    public int Height { get; }
    public int Length { get; }
    public int MaxGPULength { get; }
    public int MaxGPUWidth { get; }
    public string MotherBoardFormFactor { get; }

    public IComputerCaseBuilder Direct(IComputerCaseBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithWidth(Width);
        builder.WithHeight(Height);
        builder.WithLength(Length);
        builder.WithMaxGPULength(MaxGPULength);
        builder.WithMaxGPUWidth(MaxGPUWidth);
        builder.WithMotherBoardFormFactor(MotherBoardFormFactor);
        return builder;
    }
}