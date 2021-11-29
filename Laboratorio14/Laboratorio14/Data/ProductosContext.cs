using Laboratorio14.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace Laboratorio14.Data
{
    public class ProductosContext : DbContext
    {
        public DbSet<ProductoModel> TbProductos { get; set; }

        public ProductosContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Lab14.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
