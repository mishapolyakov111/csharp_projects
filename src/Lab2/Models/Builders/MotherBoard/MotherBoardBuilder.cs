using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private string? _name;
    private string? _socket;
    private string? _ddrVersion;
    private string? _formFactor;
    private int _pciLineNumber;
    private int _sataPortsNumber;
    private int _ramNumber;
    private List<int> _supportedRAMFraquencies = new List<int>();
    private XMP? _supportedXmp;
    private BIOS? _bios;

    public MotherBoard Build()
    {
        return new MotherBoard(
            _name,
            _socket,
            _ddrVersion,
            _formFactor,
            _pciLineNumber,
            _sataPortsNumber,
            _ramNumber,
            _supportedRAMFraquencies,
            _supportedXmp,
            _bios);
    }

    public IMotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoardBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherBoardBuilder WithDDRVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IMotherBoardBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder WithPCILineNumber(int pciNumber)
    {
        _pciLineNumber = pciNumber;
        return this;
    }

    public IMotherBoardBuilder WithSATAPortsNumber(int sataNumber)
    {
        _sataPortsNumber = sataNumber;
        return this;
    }

    public IMotherBoardBuilder WithRAMNumber(int ramNumber)
    {
        _ramNumber = ramNumber;
        return this;
    }

    public IMotherBoardBuilder AddSupportedRAMFraquencies(int frequency)
    {
        _supportedRAMFraquencies.Add(frequency);
        return this;
    }

    public IMotherBoardBuilder WithSupportedXmp(XMP? xmpProfile)
    {
        _supportedXmp = xmpProfile;
        return this;
    }

    public IMotherBoardBuilder WithBios(BIOS bios)
    {
        _bios = bios;
        return this;
    }
}