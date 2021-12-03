using Microsoft.ML.Data;

namespace EngineerApp.MachineLearning
{
    public class MetalViscosity
    {
        //Data that will be loaded to model
        [LoadColumn(0)]
        public float Viscosity;

        [LoadColumn(1)]
        public float Speed;

        [LoadColumn(2)]
        public float Torque;

        [LoadColumn(3)]
        public float Temperature;

        [LoadColumn(4)]
        public float NormalForce;
    }

    public class MetalViscosityPrediction
    {
        //Value that will be predicted
        [ColumnName("Score")]
        public float Viscosity;
    }
}
