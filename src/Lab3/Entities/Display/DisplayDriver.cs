using System;
using System.Drawing;
using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayDriver;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;
    private string _text;

    public DisplayDriver(Color color)
    {
        _color = color;
        _text = string.Empty;
    }

    public void ClearOutput()
    {
        Console.Clear();
    }

    public string GetColoredText()
    {
        return Output.Rgb(_color.R, _color.G, _color.B).Text(_text);
    }

    public void ReadText(string text)
    {
        _text = text;
    }
}