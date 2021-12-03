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
            Viscosity = 0 ,// predict it. actual = 0.128f
            Speed = 57.3f,
            Torque = 20.2f,
            Temperature = 640,
            NormalForce = -0.0388f
        };
    }
}
