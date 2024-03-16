namespace Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

public sealed record Success(int RemainingDamage = 0) : CollisionResult(RemainingDamage);