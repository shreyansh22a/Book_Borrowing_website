using Business_Layer.Interfaces;
using Business_Layer.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _productService.GetAllProducts();
			return Ok(products);
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
		{
			var addedProduct = await _productService.AddProduct(productDto);
			return Ok(addedProduct);
		}

		[HttpPut("{productId}")]
		public async Task<IActionResult> EditProduct(Guid productId, [FromBody] ProductDto productDto)
		{
			var updatedProduct = await _productService.EditProduct(productId, productDto);

			if (updatedProduct == null)
			{
				return NotFound(new { message = "Product not found" });
			}

			return Ok(updatedProduct);
		}

		[HttpDelete("{productId}")]
		public async Task<IActionResult> DeleteProduct(Guid productId)
		{
			var isDeleted = await _productService.DeleteProduct(productId);

			if (!isDeleted)
			{
				return NotFound(new { message = "Product not found" });
			}

			return Ok(new { message = "Product deleted successfully" });
		}

		[HttpGet("{productId}")]
		public async Task<IActionResult> GetProductById(Guid productId)
		{
			var product = await _productService.GetProductById(productId);

			if (product == null)
			{
				return NotFound(new { message = "Product not found" });
			}

			return Ok(product);
		}

		[HttpPost("{productId}/updatequantity/{selectedQuantity}")]
		public async Task<IActionResult> UpdateProductQuantity(Guid productId, int selectedQuantity)
		{
			var updatedProduct = await _productService.UpdateProductQuantity(productId, selectedQuantity);

			if (updatedProduct == null)
			{
				return NotFound(new { message = "Product not found" });
			}

			return Ok(updatedProduct);
		}
	}
}
