namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public interface ICPUNameBuilder
{
    ICoolerNameBuilder WithCPU(string cpuName);
}