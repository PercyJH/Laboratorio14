using System;
using Xamarin.Forms;
using Laboratorio14.Models;
using Laboratorio14.ViewModels;


namespace Laboratorio14.Views
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosList : ContentPage
    {
        public ProductosList()
        {
            InitializeComponent();
        }

        MainViewModel Vm { get { return BindingContext as MainViewModel; } }

        public async void UpdateRow_Tapped(object sender, EventArgs e)
        {
            var contenedor = ((Frame)sender).GestureRecognizers[0];

            ProductoModel productoModel = ((TapGestureRecognizer)contenedor).CommandParameter as ProductoModel;

            /*Nombre*/
            string Nombre = await DisplayPromptAsync("Nombre", "Nombre del producto: ", "OK", null, productoModel.ProductoNombre, initialValue: productoModel.ProductoNombre, keyboard:  Keyboard.Text);
            productoModel.ProductoNombre = Nombre;
            if (Nombre == "")
            {
                productoModel.ProductoNombre = "Sin especificar";
            }
            else
            {
                productoModel.ProductoNombre = Nombre;
            }

            /*FechaIngreso*/

            /*Cantidad*/
            string cantidad = await DisplayPromptAsync("Cantidad", "Cantidad de unidades restantes: ", "OK", null, Convert.ToString(productoModel.ProductoCantidad), initialValue: Convert.ToString(productoModel.ProductoCantidad), keyboard:Keyboard.Numeric);
            if (cantidad == "")
            {
                productoModel.ProductoCantidad = 0;
            }
            else {
                var Cantidad = Convert.ToInt32(cantidad);
                productoModel.ProductoCantidad = Cantidad;
            }
           
            /*Stock*/
            bool Stock = await DisplayAlert("Stock", "¿Hay Stock?", "Sí", "No");
            productoModel.ProductoStock = Stock;


            Vm.UpdateRowCommand.Execute(productoModel);
        }

        private async void DeleteRow_Swiped(object sender, SwipedEventArgs e)
        {

            bool resultado = await DisplayAlert("Eliminar", "¿Seguro que desea eliminar el producto registrado?", "Si", "No");

            if (resultado)
            {
                var contenedor = ((Frame)sender).GestureRecognizers[0];

                ProductoModel productoModel = ((TapGestureRecognizer)contenedor).CommandParameter as ProductoModel;

                Vm.DeleteRowCommand.Execute(productoModel);
            }

        }
    }
}