namespace Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

public sealed record CrewFlashed(int RemainingDamage = 0) : CollisionResult(RemainingDamage);