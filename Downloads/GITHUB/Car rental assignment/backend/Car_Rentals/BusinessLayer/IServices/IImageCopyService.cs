using Microsoft.AspNetCore.Http;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IImageCopyService
    {
        Task<ImageDTO> UploadImage(IFormFile imageFile);
    }
}
