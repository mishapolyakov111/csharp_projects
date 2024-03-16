using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerBuilder : IComputerBuilder
{
    private MotherBoard? _motherBoard;
    private CPU? _cpu;
    private Cooler? _cooler;
    private List<RAM> _rams = new List<RAM>();
    private ComputerСase? _computerСase;
    private PowerUnit? _powerUnit;

    private List<GPU> _gpus = new List<GPU>();
    private List<SSD> _ssds = new List<SSD>();
    private List<HDD> _hdds = new List<HDD>();
    private WiFiAdapter? _wiFiAdapter;

    public Computer Build()
    {
        return new Computer(
            _motherBoard,
            _cpu,
            _cooler,
            _computerСase,
            _powerUnit,
            _wiFiAdapter,
            _rams,
            _gpus,
            _ssds,
            _hdds);
    }

    public IComputerBuilder WithMotherBoard(MotherBoard? motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder WithCPU(CPU? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder WithCooler(Cooler? cooler)
    {
        _cooler = cooler;
        return this;
    }

    public IComputerBuilder AddRAM(RAM? ram)
    {
        if (ram != null) _rams.Add(ram);
        return this;
    }

    public IComputerBuilder WithComputerСase(ComputerСase? computerСase)
    {
        _computerСase = computerСase;
        return this;
    }

    public IComputerBuilder WithPowerUnit(PowerUnit? powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IComputerBuilder AddGPU(GPU? gpu)
    {
        if (gpu != null) _gpus.Add(gpu);
        return this;
    }

    public IComputerBuilder AddSSD(SSD? ssd)
    {
        if (ssd != null) _ssds.Add(ssd);
        return this;
    }

    public IComputerBuilder AddHDD(HDD? hdd)
    {
        if (hdd != null) _hdds.Add(hdd);
        return this;
    }

    public IComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }
}