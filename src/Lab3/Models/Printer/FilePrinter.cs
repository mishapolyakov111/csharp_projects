using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class FilePrinter : IPrinter
{
    private string _path;

    public FilePrinter(string path)
    {
        _path = path;
    }

    public void Print(string text)
    {
        File.AppendAllText(_path, text);
    }
}