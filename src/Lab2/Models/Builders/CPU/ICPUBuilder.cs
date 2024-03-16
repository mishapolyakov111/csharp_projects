namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ICPUBuilder
{
    ICPUBuilder WithCPUName(string name);
    ICPUBuilder WithSocket(string socketName);
    ICPUBuilder WithCoresNumber(int number);
    ICPUBuilder WithCoreFrequency(int frequency);
    ICPUBuilder WithGraphicsCore(string graphicCoreName);
    ICPUBuilder AddSupportedRamFrequency(int frequency);
    ICPUBuilder WithTDP(int tpd);
    ICPUBuilder WithWattage(int wattage);
    CPU Build();
}