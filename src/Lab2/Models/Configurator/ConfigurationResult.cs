using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record ConfigurationResult(bool Success, IEnumerable<string> Comments);