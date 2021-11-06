using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EngineerApp.Controllers
{
    public class DataRow
    {
        public int measPts;
        public int gap;
        public int shearRate;
        public float ShearStress;
    }

    public class fileUploadController : Controller
    {
        [HttpPost]
        [Route("api/UploadFile", Name = "UploadFile")]
        public void UploadFile(IFormFile file)
        {
            List<DataRow> rows = new List<DataRow>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read()) //Each row of the file
                    {
                        for (int i = 0; i < 17; i++)
                        {
                            if (reader.GetValue(i)?.ToString() == "Meas.Pts.")
                            {
                                Console.WriteLine(reader.GetValue(0).ToString());
                            }
                        }

                        //rows.Add(new Row { measPts = reader.GetInt32(0), gap = reader.GetInt32(1), shearRate = reader.GetInt32(2), ShearStress = reader.GetFloat(3) });
                    }
                }
            }

            Console.WriteLine(rows);
            // return Ok(users);
        }
    }
}

