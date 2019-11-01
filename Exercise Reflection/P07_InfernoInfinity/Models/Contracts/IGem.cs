using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Contracts
{
    public interface IGem
    {
        int GemStrengthIncreasement { get; }
        int GemAgilityIncreasement { get; }
        int GemVitalityIncreasement { get; }
    }
}
