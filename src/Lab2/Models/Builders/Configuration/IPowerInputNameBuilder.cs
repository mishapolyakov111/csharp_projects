namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public interface IPowerInputNameBuilder
{
    IComputerCaseNameBuilder WithPowerInput(string powerInputName);
}