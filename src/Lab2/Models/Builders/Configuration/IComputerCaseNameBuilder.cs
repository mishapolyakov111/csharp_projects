using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public interface IComputerCaseNameBuilder
{
    IConfigurationBuilder WithComputerCase(string computerCaseName);
}