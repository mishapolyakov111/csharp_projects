namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public interface IMotherBoardNameBuilder
{
    ICPUNameBuilder WithMotherBoard(string motherBoardName);
}