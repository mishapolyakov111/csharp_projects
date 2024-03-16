using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Validator
{
    private const string InvalidBios = "Motherboard BIOS does not support this processor.\n";
    private const string InvalidCPUSocket = "Motherboard and CPU have different sockets.\n";
    private const string InvalidCoolerSocket = "Cooler and CPU have different sockets.\n";
    private const string InvalidCooler = "CPU emits more heat than the cooler is able to dissipate.\n";
    private const string Disclaimer = "Disclaimer of warranty obligations.\n";
    private const string InvalidRAM = "Invalid RAM:\n";
    private const string InvalidComputerCase = "Computer case doesn't suppord Motherboard.\n";
    private const string InvalidPowerUnit = "Low PowerUnit wattage\n";

    private List<string> _comments = new List<string>();

    public ConfigurationResult GetConfigurationResult(Computer computer)
    {
        return new ConfigurationResult(CheckValidation(computer), _comments);
    }

    private bool CheckValidation(Computer computer)
    {
        bool valid = CheckBIOS(computer) && CheckCPU(computer)
                    && CheckCooler(computer) && CheckRAM(computer)
                    && CheckGPU(computer) && CheckDrive(computer)
                    && CheckComputerCase(computer) && CheckPowerUnit(computer);
        return valid;
    }

    private bool CheckBIOS(Computer computer)
    {
        bool result = computer.MotherBoard.Bios.SupportedProcessors.Any(x => x == computer.CPU.Name);
        if (!result) _comments.Add(InvalidBios);
        return result;
    }

    private bool CheckCPU(Computer computer)
    {
        bool result = computer.MotherBoard.Socket == computer.CPU.Socket;
        if (!result)
        {
            _comments.Add(InvalidCPUSocket
                          + "Motherboard: "
                          + computer.MotherBoard.Socket
                          + "CPU: "
                          + computer.CPU.Socket);
        }

        return result;
    }

    private bool CheckCooler(Computer computer)
    {
        bool socketValid = computer.Cooler.SupportedSockets.Any(x => x == computer.CPU.Socket);
        if (!socketValid)
        {
            _comments.Add(InvalidCoolerSocket + "CPU: " + computer.CPU.Socket);
        }

        if (computer.CPU.TDP >= computer.Cooler.MaxTDP)
        {
            _comments.Add(Disclaimer);
            _comments.Add(InvalidCooler);
        }

        return socketValid;
    }

    private bool CheckRAM(Computer computer)
    {
        var comment = new StringBuilder(InvalidRAM);

        bool result1 = computer.RAMs.Count <= computer.MotherBoard.RAMNumber;
        bool result2 = computer.RAMs.All(x => x.VersionDDR == computer.MotherBoard.DDRVersion);

        if (!result1) comment.Append("Not enough RAM slots\n");
        if (!result2) comment.Append("Unsupported DDR version\n");

        if (!(result1 && result2)) _comments.Add(comment.ToString());
        return result1 && result2;
    }

    private bool CheckGPU(Computer computer)
    {
        bool result1 = computer.MotherBoard.PCILineNumber >= computer.GPUs.Count;
        if (!result1) _comments.Add("Too many GPU\n");

        bool result2 = computer.GPUs.Count != 0 || computer.CPU.GraphicsCore != null;
        if (!result2) _comments.Add("There is not a single video card\n");

        return result1 && result2;
    }

    private bool CheckDrive(Computer computer)
    {
        bool result1 = computer.SSDs.Count + computer.HDDs.Count != 0;
        if (!result1) _comments.Add("There is not a single drive\n");

        bool result2 = computer.SSDs.Count(x => x.Connector == "SATA") + computer.HDDs.Count(x => x.Connector == "SATA") <= computer.MotherBoard.SATAPortsNumber;
        if (!result2) _comments.Add("There are not enough slots for drives\n");

        return result1 && result2;
    }

    private bool CheckComputerCase(Computer computer)
    {
        bool result1 = computer.ComputerCase.MotherBoardFormFactor == computer.MotherBoard.FormFactor;
        if (!result1) _comments.Add(InvalidComputerCase);

        return result1;
    }

    private bool CheckPowerUnit(Computer computer)
    {
        int wattage = computer.CPU.Wattage;
        wattage += computer.RAMs.Sum(ram => ram.Wattage);
        wattage += computer.GPUs.Sum(gpu => gpu.Wattage);
        wattage += computer.SSDs.Sum(ssd => ssd.Wattage);
        wattage += computer.HDDs.Sum(hdd => hdd.Wattage);

        if (wattage >= computer.PowerUnit.Wattage)
        {
            _comments.Add(Disclaimer);
            _comments.Add(InvalidPowerUnit);
        }

        return true;
    }
}