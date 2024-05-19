using Microsoft.AspNetCore.Mvc;
using PocSplitUpload.UI.Filters;
using PocSplitUpload.UI.Helpers;
using System.Threading.Tasks;

namespace PocSplitUpload.UI.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [DisableFormValueModelBinding]
        [HttpPost("[action]")]
        public async Task<IActionResult> Index()
        {
            await UploadHelper.Process(Request);
            return Ok(new { Success = true });
        }
    }
}
