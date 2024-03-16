namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class AlphaJumpEngine : IJumpEngine
{
    private const int MaxAlphaJumpRange = 1000;
    private const double AlphaLinearCoefficient = 1.75;
    private const int ActivationTime = 1;

    public int MaxJumpRange { get; } = MaxAlphaJumpRange;

    public double? CalculateFuel(int pathLength)
    {
        return pathLength > MaxJumpRange ? null : AlphaLinearCoefficient * pathLength;
    }

    public double? CalculateTime(int pathLength)
    {
        return pathLength > MaxJumpRange ? null : ActivationTime;
    }
}