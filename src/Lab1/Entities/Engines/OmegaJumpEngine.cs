using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class OmegaJumpEngine : IJumpEngine
{
    private const int MaxOmegaJumpRange = 10000;
    private const double OmegaLinearCoefficient = 1.45;
    private const int ActivationTime = 5;
    public int MaxJumpRange { get; } = MaxOmegaJumpRange;

    public double? CalculateFuel(int pathLength)
    {
        return pathLength > MaxJumpRange ? double.MaxValue : OmegaLinearCoefficient * pathLength * Math.Log(pathLength);
    }

    public double? CalculateTime(int pathLength)
    {
        return pathLength > MaxJumpRange ? double.MaxValue : ActivationTime;
    }
}