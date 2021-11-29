using Laboratorio14.BL;
using Laboratorio14.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratorio14.ViewModels
{
    public  class MainViewModel : ViewModelBase
    {
        Productos productos = new Productos();


        private ObservableCollection<ProductoModel> listProductos;
        public ObservableCollection<ProductoModel> ListProductos
        {
            get { return listProductos; }
            set { listProductos = value; RaisePropetyChanged(); }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; RaisePropetyChanged(); }
        }

        private DateTime fechaIngreso;
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; RaisePropetyChanged(); }
        }

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; RaisePropetyChanged(); }
        }

        private bool stock;
        public bool Stock
        {
            get { return stock; }
            set { stock = value; RaisePropetyChanged(); }
        }

        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel()
        {
            Nombre = "";
            FechaIngreso = DateTime.Now;
            Cantidad = 0;
            Stock = false;

            DeleteRowCommand = new Command<ProductoModel>(execute: async (productoModel) => {
                await productos.DeleteProducto(productoModel);

                LoadListProductos();
            });

            DeleteAllRowCommand = new Command(execute: async () => {
                await productos.DeleteAllProductos();
                LoadListProductos();
            });

            UpdateRowCommand = new Command<ProductoModel>(execute: async (productoModel) => {
                await productos.UpdateProducto(productoModel);

                LoadListProductos();
            });

            InsertRowCommand = new Command(execute: async () => {

                await productos.InsertProducto(new ProductoModel() { 
                    ProductoNombre = Nombre, 
                    ProductoFechaIngreso = FechaIngreso,
                    ProductoCantidad = Cantidad,
                    ProductoStock = Stock
                });

                Nombre = "";
                FechaIngreso = DateTime.Now;
                Cantidad = 0;
                Stock = false;

                LoadListProductos();
            });


            LoadListProductos();


        }
        async void LoadListProductos()
        {

            ListProductos = new ObservableCollection<ProductoModel>(await productos.GetListProductos());
        }

    }
}
