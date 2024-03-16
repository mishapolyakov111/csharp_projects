namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IRepository
{
    T? FindComponent<T>(string name);
    void AddComponent<T>(string name, T component);
}