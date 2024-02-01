using Microsoft.AspNetCore.Mvc;
using Utils;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageResizeController : ControllerBase
    {
        [HttpPost]
        public IActionResult ResizeImage(IFormFile formFile)
        {
            return File(ImageResizer.Instance.ResizedImage(formFile.OpenReadStream()), "image/jpeg");
        }
    }
}
