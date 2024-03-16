namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : IBasicSpaceObstacle
{
    private const int AsteroidDamage = 7;
    public int TotalDamage { get; } = AsteroidDamage;
}