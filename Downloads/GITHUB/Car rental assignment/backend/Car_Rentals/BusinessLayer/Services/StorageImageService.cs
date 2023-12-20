using BusinessLayer.IServices;
using Microsoft.AspNetCore.Http;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StorageImageService : IImageCopyService
    {
        public Task<ImageDTO> UploadImage(IFormFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
