using System.Threading.Tasks;
using BusinessLayer.IServices;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rentals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageCopyController : ControllerBase
    {
        private readonly IImageCopyService _imageCopyService;

        public ImageCopyController(IImageCopyService imageCopyService)
        {
            _imageCopyService = imageCopyService;
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            var imageDto = await _imageCopyService.UploadImage(imageFile);

            if (imageDto == null)
            {
                return BadRequest("No file uploaded");
            }

            return Ok(imageDto);
        }
    }
}
