namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineC : IImpulseEngine
{
    private const int FuelConsumption = 10;
    private const int Velocity = 1;

    public int StartFuel { get; } = 50;

    public double? CalculateFuel(int pathLength)
    {
        return (FuelConsumption * pathLength) + StartFuel;
    }

    public double? CalculateTime(int pathLength)
    {
        return pathLength / Velocity;
    }
}