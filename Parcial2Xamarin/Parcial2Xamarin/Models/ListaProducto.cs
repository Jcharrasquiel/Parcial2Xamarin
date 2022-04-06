using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial2Xamarin.Models
{
    public static class Managerlist
    {
        private static List<Producto> gList = new List<Producto>();

        public static List<Producto> GList { get => gList; set => gList = value; }
    }

    public class ListaProducto
    {
        public List<Producto> dataproducto = new List<Producto>();

        public void Predeterminada()
        {
            dataproducto.Add(new Producto()
            {
                Nombres = "Acer",
                Precios = 4500000,
                Cantidads = 5,
                Descripcion = "Corre xamarin de forma genial, ahora si podras ganar esa materia"

            });
        }

    }
}
