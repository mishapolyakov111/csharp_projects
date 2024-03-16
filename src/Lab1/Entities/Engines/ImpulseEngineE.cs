using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineE : IImpulseEngine
{
    private const int FuelConsumption = 50;

    public int StartFuel { get; } = 100;

    public double? CalculateFuel(int pathLength)
    {
        return (FuelConsumption * pathLength) + StartFuel;
    }

    public double? CalculateTime(int pathLength)
    {
        return Math.Log(pathLength);
    }
}