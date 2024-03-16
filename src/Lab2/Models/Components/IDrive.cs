namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IDrive
{
    int MemorySize { get; }
    string Connector { get; }
    int Wattage { get; }
}