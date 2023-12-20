using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.IServices
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>> GetAllProducts();
		Task<ProductDto> AddProduct(ProductDto productDto);
		Task<ProductDto> EditProduct(Guid productId, ProductDto productDto);
		Task<bool> DeleteProduct(Guid productId);
		Task<ProductDto> GetProductById(Guid productId);
		Task<ProductDto> UpdateProductQuantity(Guid productId, int selectedQuantity);
	}
}
