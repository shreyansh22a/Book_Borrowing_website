using Microsoft.AspNetCore.Http;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.IServices
{
	public interface IImageCopyService
	{
		Task<ImageDTO> UploadImage(IFormFile imageFile);
	}
}
