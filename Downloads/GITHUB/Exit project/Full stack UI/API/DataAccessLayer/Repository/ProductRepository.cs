using DataAccessLayer.data;
using DataAccessLayer.IRepository;
using DataAccessLayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly APIDbContext _dbContext;

		public ProductRepository(APIDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<Product> AddProduct(Product product)
		{
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();
			return product;
		}

		public async Task<Product> EditProduct(Product product)
		{
			_dbContext.Products.Update(product);
			await _dbContext.SaveChangesAsync();
			return product;
		}

		public async Task<bool> DeleteProduct(Guid productId)
		{
			var product = await _dbContext.Products.FindAsync(productId);

			if (product == null)
			{
				return false;
			}

			_dbContext.Products.Remove(product);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<Product> GetProductById(Guid productId)
		{
			return await _dbContext.Products.FindAsync(productId);
		}
	}
}
