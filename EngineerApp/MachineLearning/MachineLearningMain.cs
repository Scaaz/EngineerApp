
using System;
using System.IO;
using EngineerApp.MachineLearning;
using Microsoft.ML;
using static EngineerApp.MachineLearning.MetalViscosity;


namespace TaxiFarePrediction
{
    class MachineLearningMain
    {
        static readonly string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "WE43B.csv");

        public float UseModel(MetalViscosity sample, string modelPath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Define data preparation and trained model schemas
            DataViewSchema modelSchema;//,dataPrepPipelineSchema;

            // Load data preparation pipeline and trained model
            //ITransformer dataPrepPipeline = mlContext.Model.Load("data_preparation_pipeline.zip", out dataPrepPipelineSchema);
            ITransformer loadedModel = mlContext.Model.Load(modelPath, out modelSchema);

            //Evaluate(mlContext, trainedModel);

            return TestSinglePrediction(mlContext, loadedModel, sample);
        }

        public float MachineLearning(MetalViscosity sample)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            MLContext mlContext = new MLContext(seed: 0);
            var model = TrainNewModel(mlContext, _trainDataPath);           

            Evaluate(mlContext, model);
            return TestSinglePrediction(mlContext, model, sample);
        }

        public static ITransformer TrainNewModel(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<MetalViscosity>(dataPath, hasHeader: false, separatorChar: ';');
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Viscosity")

                    .Append(mlContext.Transforms.Concatenate("Features", "Temperature", "ShearStress"))
                    .Append(mlContext.Regression.Trainers.FastTree());

            Console.WriteLine("=============== Create and Train the Model ===============");
            var model = pipeline.Fit(dataView);
            Console.WriteLine("=============== End of training ===============");
            Console.WriteLine();
            mlContext.Model.Save(model, dataView.Schema, "Data/WE43Bmodel.zip"); // SAVE MODEL
            return model;
        }

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<MetalViscosity>(_trainDataPath, hasHeader: false, separatorChar: ';');

            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");

            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
            Console.WriteLine($"*************************************************");
        }

        private static float TestSinglePrediction(MLContext mlContext, ITransformer model, MetalViscosity MetalViscositySample)
        {
            //Prediction test
            // Create prediction function and make prediction.

            var predictionFunction = mlContext.Model.CreatePredictionEngine<MetalViscosity, MetalViscosityPrediction>(model);

            //Sample:
            //vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
            //VTS,1,1,1140,3.75,CRD,15.5

            /*  var MetalViscositySample = new MetalViscosity()
              {
                  Viscosity = 0f,// predict it. actual = 0.128f
                  Speed = 57.3f,
                  Torque = 20.2f,
                  Temperature = 640,
                  ShearStress = -0.0388f
              };*/


            var prediction = predictionFunction.Predict(MetalViscositySample);


            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Input temperature = {MetalViscositySample.Temperature}, Input shearStress = {MetalViscositySample.ShearStress}, Input Viscosity = {MetalViscositySample.Viscosity}");
            Console.WriteLine($"Predicted Viscosity: {prediction.Viscosity:0.###}, actual Viscosity:  0,128");
            Console.WriteLine($"**********************************************************************");
            return prediction.Viscosity;

        }
    }
}