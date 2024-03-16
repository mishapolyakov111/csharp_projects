namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteor : IBasicSpaceObstacle
{
    private const int MeteorDamage = 20;
    public int TotalDamage { get; } = MeteorDamage;
}