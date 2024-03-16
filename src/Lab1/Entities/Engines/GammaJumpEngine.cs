namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class GammaJumpEngine : IJumpEngine
{
    private const int MaxGammaJumpRange = 1000000;
    private const double GammaLinearCoefficient = 1.1;
    private const int ActivationTime = 8;

    public int MaxJumpRange { get; } = MaxGammaJumpRange;

    public double? CalculateFuel(int pathLength)
    {
        return pathLength > MaxJumpRange ? null : GammaLinearCoefficient * pathLength * pathLength;
    }

    public double? CalculateTime(int pathLength)
    {
        return pathLength > MaxJumpRange ? null : ActivationTime;
    }
}