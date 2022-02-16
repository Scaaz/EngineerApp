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
            new MetalViscosity() { ShearStress = 1.29F, Viscosity = 0.129F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.1F, Viscosity = 0.11F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.6F, Viscosity = 0.16F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.62F, Viscosity = 0.162F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.15F, Viscosity = 0.115F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.18F, Viscosity = 0.118F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.12F, Viscosity = 0.112F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.21F, Viscosity = 0.121F, Temperature = 640, },
            new MetalViscosity() { ShearStress = 1.16F, Viscosity = 0.116F, Temperature = 640, },
        };

        internal static readonly MetalViscosity[] E21 =
        {
            new MetalViscosity() { ShearStress = 4.13f, Viscosity = 0.413f, Temperature = 620, },
            new MetalViscosity() { ShearStress = 4.12F, Viscosity = 0.412F, Temperature = 674, },
            new MetalViscosity() { ShearStress = 20.6F, Viscosity = 2.06F, Temperature = 690, },
            new MetalViscosity() { ShearStress = 20.7F, Viscosity = 4.14F, Temperature = 690, },
            new MetalViscosity() { ShearStress = 4.3F, Viscosity = 0.43F, Temperature = 674, },
            new MetalViscosity() { ShearStress = 3.91F, Viscosity = 0.391F, Temperature = 674, },
        };

        internal static readonly MetalViscosity[] WE43B =
        {
            new MetalViscosity() { ShearStress = 2.32f, Viscosity = 0.230f, Temperature = 642, },
            new MetalViscosity() { ShearStress = 1.77F, Viscosity = 0.177F, Temperature = 682, },
            new MetalViscosity() { ShearStress = 2.38F, Viscosity = 0.238F, Temperature = 682, },
            new MetalViscosity() { ShearStress = 3.02F, Viscosity = 0.604F, Temperature = 682, },
            new MetalViscosity() { ShearStress = 2.33F, Viscosity = 0.233F, Temperature = 668, },
            new MetalViscosity() { ShearStress = 2.35F, Viscosity = 0.235F, Temperature = 658, },
            new MetalViscosity() { ShearStress = 2.37F, Viscosity = 0.122F, Temperature = 652, },
            new MetalViscosity() { ShearStress = 1.99F, Viscosity = 0.127F, Temperature = 652, },
            new MetalViscosity() { ShearStress = 2.87F, Viscosity = 0.0529F, Temperature = 652, },
            new MetalViscosity() { ShearStress = 5.75F, Viscosity = 0.0585F, Temperature = 652, },
        };
    }
}
