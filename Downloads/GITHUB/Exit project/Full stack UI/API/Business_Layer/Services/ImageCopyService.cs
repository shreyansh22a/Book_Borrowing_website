using Business_Layer.IServices;
using DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Http;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
	public class ImageCopyService : IImageCopyService
	{
		private readonly IImageCopyRepository _imageCopyRepository;

		public ImageCopyService(IImageCopyRepository imageCopyRepository)
		{
			_imageCopyRepository = imageCopyRepository;
		}

		public async Task<ImageDTO> UploadImage(IFormFile imageFile)
		{
			if (imageFile == null || imageFile.Length == 0)
			{
				return null; // Or throw an exception indicating no file was uploaded
			}

			using (var memoryStream = new MemoryStream())
			{
				await imageFile.CopyToAsync(memoryStream);
				var imageBytes = memoryStream.ToArray();

				var uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid():N}{Path.GetExtension(imageFile.FileName)}";
				var imageUrl = await _imageCopyRepository.SaveImageAsync(imageBytes, uniqueFileName);

				var imageDto = new ImageDTO
				{
					ImageUrl = imageUrl
				};

				return imageDto;
			}
		}
	}
}
