using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ImageCopyRepository : IImageCopyRepository
    {
        public async Task<string> SaveImageAsync(byte[] imageBytes, string fileName)
        {

            var uploadsFolder = @"C:\Car rental assignment\frontend\car-rental-frontend\src\assets\Images";
            var filePath = Path.Combine(uploadsFolder, fileName);

            await File.WriteAllBytesAsync(filePath, imageBytes);

            var imageUrl = $"/assets/images/{fileName}";

            return imageUrl;
        }
    }
}
