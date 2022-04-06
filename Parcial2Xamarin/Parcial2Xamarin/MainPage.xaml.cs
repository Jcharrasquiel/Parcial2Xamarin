using Parcial2Xamarin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Parcial2Xamarin
{
    public partial class MainPage : ContentPage
    {
        private ListaProducto list = new ListaProducto();
        Producto producto = new Producto();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BuscarUno(object sender, EventArgs e){

            await Navigation.PushModalAsync(new NavigationPage(new DetalleProducto()));
        }

        private async Task<bool> ValidarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null

            if (String.IsNullOrWhiteSpace(nombres.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo Nombre es obligatorio.", "OK");
                return false;
            }
            //Valida si la cantidad de digitos ingresados es menor a 10
            else if (precios.Text == "$0.00")
            {
                await this.DisplayAlert("Advertencia", "Ingrese un precio mayor a 0.", "OK");
                return false;
            }
            if (String.IsNullOrWhiteSpace(nombres.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo nombre es obligatorio.", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(precios.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo precio es obligatorio.", "OK");
                return false;
            }
            //Valida que solo se ingresen letras

            if (String.IsNullOrWhiteSpace(cantidads.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del  Cantidad es obligatorio.", "OK");
                return false;
            }


            //Valida si la cantidad de digitos ingresados es menor a 10

            if (String.IsNullOrWhiteSpace(descripcions.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del  descripcion es obligatorio.", "OK");
                return false;
            }


            return true;
        }

            private async void Insertar(object sender, EventArgs e){

            producto.Nombres = nombres.Text;
            producto.Precios = int.Parse(precios.Text);
            producto.Cantidads = int.Parse(cantidads.Text);
            producto.Descripcion = descripcions.Text;

            list.dataproducto.Add(producto);
            Managerlist.GList.Add(producto);

            if (await ValidarFormulario())
            {
                await DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones.", "OK");

                //var resultado = await App.list.Add(producto); 
                //Registra nuevo producto
            }
            LimpiarCampos();
            }

            private async void VerTodos(object sender, EventArgs e){

                await Navigation.PushModalAsync(new NavigationPage(new ListadoProducto()));
            }

        private void Limpiar(object sender, EventArgs e)
        {
            id.Text = null;
            nombres.Text = "";
            precios.Text = "";
            cantidads.Text = "";
            descripcions.Text = "";
        }

        private void LimpiarCampos()
        {
            id.Text = null;
            nombres.Text = "";
            precios.Text = "";
            cantidads.Text = "";
            descripcions.Text = "";
        }
    }
}
