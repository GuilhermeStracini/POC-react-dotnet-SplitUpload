using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace POCSplitUpload.API.Controllers
{
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public void Post()
        {
            Trace.WriteLine("POST");
        }
    }
}
