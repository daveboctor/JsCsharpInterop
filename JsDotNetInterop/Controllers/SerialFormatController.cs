using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JsDotNetInterop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateAntiForgeryToken]
    public class SerialFormatController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Post([FromBody] List<int?> idList)
        {
            List<KeyValuePair<string?, string?>> kvList = [];
            foreach (int? id in idList)
            {
                kvList.Add(new KeyValuePair<string?, string?>(
                    key: id?.ToString(),
                    value: MyFormater.GetFormatedSerial(id))
                );
            }

            return new JsonResult(new
            {
                Success = true,
                SerializedList = kvList
            });
        }
    }
}

//public JsonResult Post(FormatData formatData)
//public class FormatData
//{
//    public int? Id { get; set; }
//}
