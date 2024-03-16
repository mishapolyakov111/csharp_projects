using Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IComputerBuilderDirector
{
    Computer Construct(Configuration configuration, IRepository repository);
}