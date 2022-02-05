using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineerApp.MachineLearning
{
    public class TestCases
    {
        internal static readonly MetalViscosity[] AZ91 =
        {
            new MetalViscosity() { ShearStress = 1.28F, Viscosity = 0.128F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.1F, Viscosity = 0.11F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.6F, Viscosity = 0.16F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.57F, Viscosity = 0.157F, Temperature = 640, },
        };

        internal static readonly MetalViscosity[] E21 =
        {
            new MetalViscosity() { ShearStress = 4.13f, Viscosity = 0.413f, Temperature = 620, },
            new MetalViscosity() { ShearStress = 4.12F, Viscosity = 0.412F, Temperature = 674, },
            new MetalViscosity() { ShearStress = 20.6F, Viscosity = 2.06F, Temperature = 690, },
            new MetalViscosity() { ShearStress = 20.7F, Viscosity = 4.14F, Temperature = 690, },
        };

        internal static readonly MetalViscosity[] WE43B =
        {
            new MetalViscosity() { ShearStress = 2.32f, Viscosity = 0.232f, Temperature = 642, },
            new MetalViscosity() { ShearStress = 1.77F, Viscosity = 0.177F, Temperature = 682, },
            new MetalViscosity() { ShearStress = 2.38F, Viscosity = 0.238F, Temperature = 682, },
            new MetalViscosity() { ShearStress = 3.02F, Viscosity = 0.604F, Temperature = 682, },
        };
    }
}
