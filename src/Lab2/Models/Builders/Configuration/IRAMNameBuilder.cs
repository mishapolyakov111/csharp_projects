using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public interface IRAMNameBuilder
{
    IPowerInputNameBuilder WithRAMList(IEnumerable<string> rams);
}