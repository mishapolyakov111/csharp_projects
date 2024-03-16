namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string? _name;
    private string? _wiFiVersion;
    private string? _bluetoothVersion;
    private string? _pciVersion;
    private int _wattage;

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _name,
            _wiFiVersion,
            _bluetoothVersion,
            _pciVersion,
            _wattage);
    }

    public IWiFiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWiFiAdapterBuilder WithWiFiVersion(string wifiVersion)
    {
        _wiFiVersion = wifiVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithBluetoothVersion(string? bluetoothVersion)
    {
        _bluetoothVersion = bluetoothVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithPCIVersion(string pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithWattage(int wattage)
    {
        _wattage = wattage;
        return this;
    }
}