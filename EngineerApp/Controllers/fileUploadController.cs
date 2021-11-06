using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EngineerApp.Controllers
{
    public class fileUploadController : Controller
    {
        [HttpPost]
        [Route("api/UploadFile", Name = "UploadFile")]
        public async void UploadFile(IFormCollection Upload)
        {           
            if (Upload.Files.Count > 0)
            {
                
                //If we have at least one file in the IFormCollection, then perform whatever storage actions
            }
        }
    }
}
