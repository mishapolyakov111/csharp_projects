namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public interface ICoolerNameBuilder
{
    IRAMNameBuilder WithCooler(string coolerName);
}