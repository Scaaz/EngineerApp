using EngineerApp.MachineLearning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using TaxiFarePrediction;

namespace EngineerApp.Controllers
{
    public class Data
    {
        public float Temperature { get; set; }
        public float ShearStress { get; set; }
        public string WhichModel { get; set; }
    }

    public class MainController : Controller
    {
        public static float PredictedViscosity { get; set; }
        static readonly string _AZ91Model = Path.Combine(Environment.CurrentDirectory, "Data", "AZ91Model.zip");
        static readonly string _E21Model = Path.Combine(Environment.CurrentDirectory, "Data", "E21Model.zip");
        static readonly string _WE43BModel = Path.Combine(Environment.CurrentDirectory, "Data", "WE43BModel.zip");

        [HttpPost]
        [Route("api/Calculate", Name = "Calculate")]
        public void CalculateViscosity([FromBody] Data data)
        {
            MachineLearningMain ml = new MachineLearningMain();
            MetalViscosity sample = new MetalViscosity(data);

            switch (data.WhichModel)
            {
                case "AZ91":
                    PredictedViscosity = ml.UseModel(sample, _AZ91Model);
                    ml.EvaluateExistingModel(_AZ91Model, data.WhichModel);
                    break;
                case "E21":
                    PredictedViscosity = ml.UseModel(sample, _E21Model);
                    ml.EvaluateExistingModel(_E21Model, data.WhichModel);
                    break;
                case "WE43B":
                    PredictedViscosity = ml.UseModel(sample, _WE43BModel);
                    ml.EvaluateExistingModel(_WE43BModel, data.WhichModel);
                    break;
            }
            //PredictedViscosity = ml.MachineLearning(sample, data.WhichModel); //DO TRENOWANIA NOWYCH MODELI
        }

        [HttpGet]
        [Route("api/Get", Name = "GetResult")]
        public float GetResultValue()
        {
            return PredictedViscosity;
        }
    }
}

