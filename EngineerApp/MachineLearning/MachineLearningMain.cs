// <Snippet1>
using System;
using System.IO;
using EngineerApp.MachineLearning;
using Microsoft.ML;
using static EngineerApp.MachineLearning.MetalViscosity;
// </Snippet1>

namespace TaxiFarePrediction
{
    class MachineLearningMain
    {
        // <Snippet2>
        static readonly string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "AZ91.csv"); 
        static readonly string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "AZ91.csv");
        static readonly string _az91Model = Path.Combine(Environment.CurrentDirectory, "Data", "az91Model.zip");
        // </Snippet2>

        public void UseModel(MetalViscosity sample, string modelPath)
        {

            // Create MLContext
            MLContext mlContext = new MLContext();

            // Define data preparation and trained model schemas
            DataViewSchema modelSchema;//,dataPrepPipelineSchema;

            // Load data preparation pipeline and trained model
            //ITransformer dataPrepPipeline = mlContext.Model.Load("data_preparation_pipeline.zip", out dataPrepPipelineSchema);
            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);

            //Evaluate(mlContext, trainedModel);
            // </Snippet14>

            // <Snippet20>
            TestSinglePrediction(mlContext, trainedModel, sample);
        }

        public float MachineLearning(MetalViscosity sample)
        {
            Console.WriteLine(Environment.CurrentDirectory);

            // <Snippet3>
            MLContext mlContext = new MLContext(seed: 0);
            // </Snippet3>

            // <Snippet5>
            var model = Train(mlContext, _trainDataPath);
            // </Snippet5>

            // <Snippet14>
            Evaluate(mlContext, model);
            // </Snippet14>

            // <Snippet20>
            return TestSinglePrediction(mlContext, model, sample);
            // </Snippet20>
        }

        public static ITransformer Train(MLContext mlContext, string dataPath)
        {
            // <Snippet6>
            IDataView dataView = mlContext.Data.LoadFromTextFile<MetalViscosity>(dataPath, hasHeader: false, separatorChar: ';');
            // </Snippet6>

            // <Snippet7>
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Viscosity")
                    // </Snippet7>
                    // <Snippet8>
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "TemperatureEncoded", inputColumnName: "Temperature"))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "ShearStressEncoded", inputColumnName: "ShearStress"))
                    // </Snippet8>
                    // <Snippet9>
                    .Append(mlContext.Transforms.Concatenate("Features", "TemperatureEncoded", "ShearStressEncoded"))
                    // </Snippet9>
                    // <Snippet10>
                    .Append(mlContext.Regression.Trainers.FastTree());
            // </Snippet10>

            Console.WriteLine("=============== Create and Train the Model ===============");

            // <Snippet11>
            var model = pipeline.Fit(dataView);
            // </Snippet11>

            Console.WriteLine("=============== End of training ===============");
            Console.WriteLine();
            mlContext.Model.Save(model, dataView.Schema, "Data/AZ91model.zip"); // SAVE MODEL
            // <Snippet12>
            return model;
            // </Snippet12>
        }

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            // <Snippet15>
            IDataView dataView = mlContext.Data.LoadFromTextFile<MetalViscosity>(_testDataPath, hasHeader: false, separatorChar: ';');
            // </Snippet15>

            // <Snippet16>
            var predictions = model.Transform(dataView);
            // </Snippet16>
            // <Snippet17>
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
            // </Snippet17>

            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");
            // <Snippet18>
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            // </Snippet18>
            // <Snippet19>
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
            // </Snippet19>
            Console.WriteLine($"*************************************************");
        }

        private static float TestSinglePrediction(MLContext mlContext, ITransformer model, MetalViscosity MetalViscositySample)
        {
            //Prediction test
            // Create prediction function and make prediction.
            // <Snippet22>
            var predictionFunction = mlContext.Model.CreatePredictionEngine<MetalViscosity, MetalViscosityPrediction>(model);
            // </Snippet22>
            //Sample:
            //vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
            //VTS,1,1,1140,3.75,CRD,15.5
            // <Snippet23>
          /*  var MetalViscositySample = new MetalViscosity()
            {
                Viscosity = 0f,// predict it. actual = 0.128f
                Speed = 57.3f,
                Torque = 20.2f,
                Temperature = 640,
                ShearStress = -0.0388f
            };*/
            // </Snippet23>
            // <Snippet24>
            var prediction = predictionFunction.Predict(MetalViscositySample);
            // </Snippet24>
            // <Snippet25>
            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Input temperature = {MetalViscositySample.Temperature}, Input shearStress = {MetalViscositySample.ShearStress}, Input Viscosity = {MetalViscositySample.Viscosity}");
            Console.WriteLine($"Predicted Viscosity: {prediction.Viscosity}, actual Viscosity:  0,128");
            Console.WriteLine($"**********************************************************************");
            return prediction.Viscosity;
            // </Snippet25>
        }
    }
}