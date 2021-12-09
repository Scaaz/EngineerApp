using EngineerApp.MachineLearning;
using Microsoft.AspNetCore.Mvc;
using TaxiFarePrediction;

namespace EngineerApp.Controllers
{
    public class Data
    {
        public float Speed { get; set; }
        public float Torque { get; set; }
        public float Temperature { get; set; }
        public float NormalForce { get; set; }
    }

    public class FileUploadController : Controller
    {
        public static float Value { get; set; }

        [HttpPost]
        [Route("api/Calculate", Name = "Calculate")]
        public void CalculateViscosity([FromBody] Data data)
        {
            //Value = data.Gap + data.MeasPts + data.ShearStress + data.ShearRate;
            MachineLearningMain ml = new MachineLearningMain();
            //ml.UseModel();
            MetalViscosity sample = new MetalViscosity(data);
            Value = ml.MachineLearning(sample);
        }

        [HttpGet]
        [Route("api/Get", Name = "GetResult")]
        public float GetResultValue()
        {
            //wyświetlam Value
            return Value;
        }      
    }
}

