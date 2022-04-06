using Parcial2Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parcial2Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleProducto : ContentPage
    {
        private Producto sendProducts;

        public DetalleProducto()
        {
           
        }

        public DetalleProducto(Producto sendProducts)
        {
            this.sendProducts = sendProducts;
        }

        public DetalleProducto(int idd, string nombress, string precioss, string cantidadss, string descripcionss)
        {
            InitializeComponent();
            id.Text = idd.ToString();
            nombres.Text = nombress;
            precios.Text = precioss;
            cantidads.Text = cantidadss;
            descripcions.Text = descripcionss;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}