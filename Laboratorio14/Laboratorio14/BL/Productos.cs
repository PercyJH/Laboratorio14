using Laboratorio14.Data;
using Laboratorio14.Models;
using Laboratorio14.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio14.BL
{
    public class Productos : IProductos
    {
        public async Task<List<ProductoModel>> GetListProductos()
        {
            using (var productosContext = new ProductosContext())
            {
                return await productosContext.TbProductos.ToListAsync();
            }
        }

        public async Task<ProductoModel> GetProducto(int ProductoId)
        {
            using (var productosContext = new ProductosContext())
            {
                return await productosContext.TbProductos
                    .Where(p => p.ProductoId == ProductoId).FirstOrDefaultAsync();
            }

        }


        public async Task<bool> InsertProducto(ProductoModel productoModel)
        {
            using (var productosContext = new ProductosContext())
            {
                productosContext.Add(productoModel);

                await productosContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateProducto(ProductoModel productoModel)
        {
            using (var productosContext = new ProductosContext())
            {
                var tracking = productosContext.Update(productoModel);

                await productosContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
        }

        public async Task<bool> DeleteProducto(ProductoModel productoModel)
        {
            using (var productosContext = new ProductosContext())
            {
                var tracking = productosContext.Remove(productoModel);

                await productosContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }

        }


        public async Task<bool> DeleteAllProductos()
        {
            using (var productosContext = new ProductosContext())
            {
                productosContext.RemoveRange(productosContext.TbProductos);

                await productosContext.SaveChangesAsync();
            }
            return true;
        }


    }
}
