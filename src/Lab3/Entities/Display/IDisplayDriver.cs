namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayDriver;

public interface IDisplayDriver
{
    void ClearOutput();
    string GetColoredText();
    void ReadText(string text);
}