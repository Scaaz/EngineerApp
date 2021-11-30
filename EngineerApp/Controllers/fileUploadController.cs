using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using TaxiFarePrediction;

namespace EngineerApp.Controllers
{
    public class Data
    {
        public float MeasPts { get; set; }
        public float Gap { get; set; }
        public float ShearRate { get; set; }
        public float ShearStress { get; set; }
    }

    public class FileUploadController : Controller
    {
        public static float Value { get; set; }

        [HttpPost]
        [Route("api/Calculate", Name = "Calculate")]
        public void CalculateViscosity([FromBody] Data data)
        {
            Value = data.Gap + data.MeasPts + data.ShearStress + data.ShearRate;
            machineLearning ml = new machineLearning();
            ml.MachineLearning();
        }

        [HttpGet]
        [Route("api/Get", Name = "GetResult")]
        public float GetResultValue()
        {
            //wyświetlam Value
            return Value;
        }

        //[HttpPost]
        //[Route("api/UploadFile", Name = "UploadFile")]
        //public void UploadFile(IFormFile file)
        //{
        //    List<DataRow> rows = new List<DataRow>();
        //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //    using (var stream = new MemoryStream())
        //    {
        //        file.CopyTo(stream);
        //        stream.Position = 0;
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            while (reader.Read()) //Each row of the file
        //            {
        //                for (int i = 0; i < 17; i++)
        //                {
        //                    if (reader.GetValue(i)?.ToString() == "Meas.Pts.")
        //                    {
        //                        Console.WriteLine(reader.GetValue(0).ToString());
        //                    }
        //                }

        //                //rows.Add(new Row { measPts = reader.GetInt32(0), gap = reader.GetInt32(1), shearRate = reader.GetInt32(2), ShearStress = reader.GetFloat(3) });
        //            }
        //        }
        //    }

        //    Console.WriteLine(rows);
        //    // return Ok(users);
        //}
    }
}

