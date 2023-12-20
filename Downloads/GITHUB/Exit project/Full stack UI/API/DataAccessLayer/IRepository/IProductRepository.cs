using DataAccessLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProducts();
		Task<Product> AddProduct(Product product);
		Task<Product> EditProduct(Product product);
		Task<bool> DeleteProduct(Guid productId);
		Task<Product> GetProductById(Guid productId);
	}
}
