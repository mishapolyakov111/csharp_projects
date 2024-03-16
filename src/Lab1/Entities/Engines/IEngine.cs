namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IEngine
{
    public double? CalculateFuel(int pathLength);
    public double? CalculateTime(int pathLength);
}