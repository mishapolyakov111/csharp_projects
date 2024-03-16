namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class PhotonicFlash : IDenseSpaceObstacle
{
    private const int PhotonicFlashDamage = 0;
    public int TotalDamage { get; } = PhotonicFlashDamage;
}