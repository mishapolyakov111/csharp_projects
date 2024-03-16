using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public class ConfigurationBuilder : IConfigurationBuilder
{
    private string? _motherBoard;
    private string? _cpu;
    private string? _cooler;
    private string? _powerInput;
    private string? _computerCase;
    private IEnumerable<string> _rams = new List<string>();
    private List<string> _hdds = new List<string>();
    private List<string> _ssds = new List<string>();
    private List<string> _gpus = new List<string>();

    public Configuration Build()
    {
        return new Configuration(
            _motherBoard,
            _cpu,
            _cooler,
            _powerInput,
            _computerCase,
            _rams,
            _hdds,
            _ssds,
            _gpus);
    }

    public ICPUNameBuilder WithMotherBoard(string motherBoardName)
    {
        _motherBoard = motherBoardName;
        return this;
    }

    public ICoolerNameBuilder WithCPU(string cpuName)
    {
        _cpu = cpuName;
        return this;
    }

    public IRAMNameBuilder WithCooler(string coolerName)
    {
        _cooler = coolerName;
        return this;
    }

    public IComputerCaseNameBuilder WithPowerInput(string powerInputName)
    {
        _powerInput = powerInputName;
        return this;
    }

    public IConfigurationBuilder WithComputerCase(string computerCaseName)
    {
        _computerCase = computerCaseName;
        return this;
    }

    public IConfigurationBuilder AddGPU(string gpuName)
    {
        _gpus.Add(gpuName);
        return this;
    }

    public IConfigurationBuilder AddHDD(string hddName)
    {
        _hdds.Add(hddName);
        return this;
    }

    public IConfigurationBuilder AddSSD(string hddName)
    {
        _ssds.Add(hddName);
        return this;
    }

    public IPowerInputNameBuilder WithRAMList(IEnumerable<string> rams)
    {
        _rams = rams;
        return this;
    }
}