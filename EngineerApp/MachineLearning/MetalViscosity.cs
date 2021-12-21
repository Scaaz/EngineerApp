using EngineerApp.Controllers;
using Microsoft.ML.Data;

namespace EngineerApp.MachineLearning
{
    public class MetalViscosity
    {
        //Data that will be loaded to model

        [LoadColumn(0)]
        public float ShearStress;

        [LoadColumn(1)]
        public float Viscosity;

        [LoadColumn(2)]
        public float Temperature;

        public MetalViscosity(Data data)
        {
            Viscosity = 0;//to be predicted
            ShearStress = data.ShearStress;
            Temperature = data.Temperature;
        }
        public MetalViscosity()
        {
        }

        public class MetalViscosityPrediction
        {
            //Value that will be predicted
            [ColumnName("Score")]
            public float Viscosity;
        }
    }
}