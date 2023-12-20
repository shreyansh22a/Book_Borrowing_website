using Business_Layer.IServices;
using DataAccessLayer.IRepository;
using DataAccessLayer.models;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<ProductDto>> GetAllProducts()
		{
			var products = await _productRepository.GetAllProducts();
			return products.Select(p => MapProductToDto(p));
		}

		public async Task<ProductDto> AddProduct(ProductDto productDto)
		{
			var product = MapDtoToProduct(productDto);
			product.ID = Guid.NewGuid();
			var addedProduct = await _productRepository.AddProduct(product);
			return MapProductToDto(addedProduct);
		}

		public async Task<ProductDto> EditProduct(Guid productId, ProductDto productDto)
		{
			var existingProduct = await _productRepository.GetProductById(productId);

			if (existingProduct == null)
			{
				return null;
			}

			existingProduct.ProductName = productDto.ProductName;
			existingProduct.Price = (long)productDto.Price;
			existingProduct.Description = productDto.Description;
			existingProduct.Category = productDto.Category;
			existingProduct.AvailableQuantity = productDto.AvailableQuantity;
			existingProduct.Image = productDto.image;
			existingProduct.Discount = (long)productDto.Discount;
			existingProduct.Specification = productDto.Specification;

			var updatedProduct = await _productRepository.EditProduct(existingProduct);
			return MapProductToDto(updatedProduct);
		}

		public async Task<bool> DeleteProduct(Guid productId)
		{
			return await _productRepository.DeleteProduct(productId);
		}

		public async Task<ProductDto> GetProductById(Guid productId)
		{
			var product = await _productRepository.GetProductById(productId);
			return MapProductToDto(product);
		}

		public async Task<ProductDto> UpdateProductQuantity(Guid productId, int selectedQuantity)
		{
			var product = await _productRepository.GetProductById(productId);

			if (product == null)
			{
				return null;
			}

			product.AvailableQuantity -= selectedQuantity;

			var updatedProduct = await _productRepository.EditProduct(product);
			return MapProductToDto(updatedProduct);
		}

		private Product MapDtoToProduct(ProductDto productDto)
		{
			return new Product
			{
				ProductName = productDto.ProductName,
				Price = (long)productDto.Price,
				Description = productDto.Description,
				Category = productDto.Category,
				AvailableQuantity = productDto.AvailableQuantity,
				Image = productDto.image,
				Discount = (long)productDto.Discount,
				Specification = productDto.Specification
			};
		}

        private ProductDto MapProductToDto(Product product)
        {
            if (product == null)
            {
                // Handle the case when the product is null
                return null; // Or throw an exception, return a default DTO, or take appropriate action
            }

            return new ProductDto
            {
                id = product.ID,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                AvailableQuantity = product.AvailableQuantity,
                image = product.Image,
                Discount = product.Discount,
                Specification = product.Specification
            };
        }

    }
}
