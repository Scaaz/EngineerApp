using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineerApp.MachineLearning
{
    public class TestCases
    {
        internal static readonly MetalViscosity AZ91 = new MetalViscosity
        {
            ShearStress = 1.11f,
            Viscosity = 0.11f,
            Temperature = 640,
        };

        internal static readonly MetalViscosity E21 = new MetalViscosity
        {
            ShearStress = 4.13f,
            Viscosity = 0.413f,
            Temperature = 620,
        };

        internal static readonly MetalViscosity WE43B = new MetalViscosity
        {
            ShearStress = 2.32f,
            Viscosity = 0.232f,
            Temperature = 642,
        };
    }
}
