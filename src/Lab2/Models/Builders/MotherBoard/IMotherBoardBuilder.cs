using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IMotherBoardBuilder : IBuilder<MotherBoard>
{
    IMotherBoardBuilder WithName(string name);
    IMotherBoardBuilder WithSocket(string socket);
    IMotherBoardBuilder WithDDRVersion(string ddrVersion);
    IMotherBoardBuilder WithFormFactor(string formFactor);
    IMotherBoardBuilder WithPCILineNumber(int pciNumber);
    IMotherBoardBuilder WithSATAPortsNumber(int sataNumber);
    IMotherBoardBuilder WithRAMNumber(int ramNumber);
    IMotherBoardBuilder AddSupportedRAMFraquencies(int frequency);
    IMotherBoardBuilder WithSupportedXmp(XMP? xmpProfile);
    IMotherBoardBuilder WithBios(BIOS bios);
}