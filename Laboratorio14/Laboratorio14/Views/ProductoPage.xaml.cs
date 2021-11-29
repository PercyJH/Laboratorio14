using Xamarin.Forms;


namespace Laboratorio14.Views
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoPage : ContentPage
    {
        public ProductoPage()
        {
            InitializeComponent();

            Item1.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ProductosList());
            };
        }


    }
}