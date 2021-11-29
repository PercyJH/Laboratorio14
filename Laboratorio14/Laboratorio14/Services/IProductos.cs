using Laboratorio14.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laboratorio14.Services
{
    public interface IProductos
    {
        Task<List<ProductoModel>> GetListProductos();
        Task<ProductoModel> GetProducto(int ProductoId);
        Task<bool> InsertProducto(ProductoModel productoModel);
        Task<bool> UpdateProducto(ProductoModel productoModel);
        Task<bool> DeleteProducto(ProductoModel productoModel);
        Task<bool> DeleteAllProductos();
    }
}
