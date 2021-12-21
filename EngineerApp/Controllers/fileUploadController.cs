using EngineerApp.MachineLearning;
using Microsoft.AspNetCore.Mvc;
using TaxiFarePrediction;

namespace EngineerApp.Controllers
{
    public class Data
    {
        public float Temperature { get; set; }
        public float ShearStress { get; set; }
    }

    public class FileUploadController : Controller
    {
        public static float Value { get; set; }

        [HttpPost]
        [Route("api/Calculate", Name = "Calculate")]
        public void CalculateViscosity([FromBody] Data data)
        {
            MachineLearningMain ml = new MachineLearningMain();           
            MetalViscosity sample = new MetalViscosity(data);
            string whichModel = "asd";
            //ml.UseModel(sample, whichModel);
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

