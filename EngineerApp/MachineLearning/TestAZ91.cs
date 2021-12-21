using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineerApp.MachineLearning
{
    public class TestAZ91
    {
        internal static readonly MetalViscosity AZ91 = new MetalViscosity
        {
            ShearStress = 1.28f,
            Viscosity = 0.128f,// predict it. actual = 0.128f
            Temperature = 640,
        };
    }
}
