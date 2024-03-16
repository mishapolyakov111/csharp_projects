using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public class Repository : IRepository
{
    public Repository()
    {
        var biosBuilder = new BIOSBuilder();
        BIOS bios = biosBuilder.WithName("Director").WithType("Internetovich")
            .WithVersion("123").AddSupportedProcessor("AMD RYZEN 5 5600X").AddSupportedProcessor("Intel Core i5-12400F").Build();

        var motherBoardBuilder = new MotherBoardBuilder();
        MotherBoard motherBoard1 = motherBoardBuilder.WithSocket("AM4").WithPCILineNumber(4)
            .WithSATAPortsNumber(4).WithDDRVersion("DDR4-DIMM")
            .WithRAMNumber(4).WithFormFactor("Standard-ATX").WithBios(bios).WithName("GIGABYTE B550 AORUS ELITE V2").Build();

        AddComponent(motherBoard1.Name, motherBoard1);

        MotherBoard motherBoard2 = motherBoardBuilder.WithSocket("LGA 1700").WithPCILineNumber(4)
            .WithSATAPortsNumber(6).WithDDRVersion("DDR5-DIMM")
            .WithRAMNumber(4).WithFormFactor("Standard-ATX").WithBios(bios).WithName("MSI MAG Z690 TOMAHAWK").Build();

        AddComponent(motherBoard2.Name, motherBoard2);

        var cpuBuilder = new CPUBuilder();
        CPU cpu1 = cpuBuilder.WithCoreFrequency(3700).WithCoresNumber(6).WithSocket("AM4")
            .AddSupportedRamFrequency(3200).WithTDP(65).WithWattage(140).WithCPUName("AMD RYZEN 5 5600X").Build();

        AddComponent(cpu1.Name, cpu1);

        CPU cpu2 = cpuBuilder.WithCoreFrequency(2500).WithCoresNumber(6).WithSocket("LGA 1700")
            .AddSupportedRamFrequency(4800).WithTDP(65).WithWattage(115).WithCPUName("Intel Core i5-12400F").Build();

        AddComponent(cpu2.Name, cpu2);

        RAM ram1 = new RAMBuilder().WithMemorySize(16).AddSupportedJEDEC(new JEDEC(3200, 10))
            .WithVersionDDR("DDR4-DIMM").WithWattage(10).WithName("Kingston FURY Beast Black").Build();

        AddComponent(ram1.Name, ram1);

        RAM ram2 = new RAMBuilder().WithMemorySize(16).AddSupportedJEDEC(new JEDEC(3200, 10))
            .WithVersionDDR("DDR5-DIMM").WithWattage(10).WithName("Patriot Viper Venom").Build();

        AddComponent(ram2.Name, ram2);

        Cooler cooler1 = new CoolerBuilder().WithName("DEEPCOOL AK620").AddSupportedSockets("AM4")
            .AddSupportedSockets("LGA 1700").WithMaxTDP(200).WithSize(10).Build();

        AddComponent(cooler1.Name, cooler1);

        Cooler cooler2 = new CoolerBuilder().WithName("BAD COOLER").AddSupportedSockets("AM4")
            .AddSupportedSockets("LGA 1700").WithMaxTDP(50).WithSize(10).Build();

        AddComponent(cooler2.Name, cooler2);

        GPU gpu1 = new GPUBuilder().WithName("KFA2 GeForce RTX 3060 CORE").WithLegth(245)
            .WithWidth(112).WithWattage(100).WithFrequency(1320).WithVersionPCI("PCI-E 4.0").Build();

        AddComponent(gpu1.Name, gpu1);

        GPU gpu2 = new GPUBuilder().WithName("Nvidia GeForce RTX 3080 ti CORE").WithLegth(300)
            .WithWidth(120).WithWattage(130).WithFrequency(1720).WithVersionPCI("PCI-E 4.0").Build();

        AddComponent(gpu2.Name, gpu2);

        SSD ssd = new SSDBuilder().WithName("SSD").WithMemorySize(1024)
            .WithConnector("SATA").WithWorkingSpeed(10000).WithWattage(15).Build();

        AddComponent(ssd.Name, ssd);

        HDD hdd = new HDDBuilder().WithName("HDD").WithMemorySize(1024)
            .WithConnector("SATA").WithWattage(15).Build();

        AddComponent(hdd.Name, hdd);

        ComputerСase computerCase = new ComputerCaseBuilder().WithName("Case").WithHeight(100)
            .WithLength(100).WithWidth(100).WithMotherBoardFormFactor("Standard-ATX").WithMaxGPULength(250)
            .WithMaxGPUWidth(120).Build();

        AddComponent(computerCase.Name, computerCase);

        var powerUnit1 = new PowerUnit("GoodPower", 600);
        var powerUnit2 = new PowerUnit("LowPower", 300);

        AddComponent(powerUnit1.Name, powerUnit1);
        AddComponent(powerUnit2.Name, powerUnit2);
    }

    public T? FindComponent<T>(string name)
    {
        return ConcreteRepository<T>.TryGetComponent(name);
    }

    public void AddComponent<T>(string name, T component)
    {
        ConcreteRepository<T>.AddComponent(name, component);
    }

    private class ConcreteRepository<T>
    {
        private static readonly Dictionary<string, T> _storage = new();

        public static T? TryGetComponent(string name)
        {
            return _storage.TryGetValue(name, out T? value) ? value : default;
        }

        public static void AddComponent(string name, T component)
        {
            _storage.TryAdd(name, component);
        }
    }
}