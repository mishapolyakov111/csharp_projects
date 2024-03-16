namespace Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

public sealed record Destruction(int RemainingDamage) : CollisionResult(RemainingDamage);