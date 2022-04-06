using Parcial2Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parcial2Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoProducto : ContentPage
    {
        
        public ICommand TestReload { get; set; }

        public ICommand GoToDetailCommand { get; set; }

        private Producto _mostrarProducto;

        public Producto MostrarProducto
        {
            get { return _mostrarProducto; }
            set { _mostrarProducto = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Producto> _blist;

        public ObservableCollection<Producto> BList
        {
            get { return _blist; }
            set { _blist = value; OnPropertyChanged(); }
        }
        public ListadoProducto()
        {
            InitializeComponent();

            ListaProducto list = new ListaProducto();

            list.Predeterminada();

            BList = new ObservableCollection<Producto>();

            foreach (var elements in list.dataproducto)
            {
                BList.Add(new Producto()
                {
                    Nombres = elements.Nombres,
                    Precios = elements.Precios,
                    Cantidads = elements.Cantidads,
                    Descripcion = elements.Descripcion
                });
            }



            TestReload = new Command(() =>
            {

                var NewElements = Managerlist.GList.Except(list.dataproducto).ToList();

                foreach (var listelement in NewElements)
                {

                    BList.Add(new Producto()
                    {

                        Nombres = listelement.Nombres,
                        Precios = listelement.Precios,
                        Cantidads = listelement.Cantidads,
                        Descripcion = listelement.Descripcion
                    });

                    list.dataproducto.Add(listelement);
                }
            });

            GoToDetailCommand = new Command(() =>
            {

                if (MostrarProducto != null)
                {
                    Producto sendProducts = new Producto
                    {
                        Nombres = MostrarProducto.Nombres,
                        Precios = MostrarProducto.Precios,
                        Cantidads = MostrarProducto.Cantidads,
                        Descripcion = MostrarProducto.Descripcion
                    };

                    Navigation.PushAsync(new DetalleProducto(sendProducts));

                }
            });



            BindingContext = this;
        }

        private async void ButtonRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {

            Producto sendProducts = new Producto();
            sendProducts.Nombres = MostrarProducto.Nombres; 
            sendProducts.Precios = MostrarProducto.Precios;
            sendProducts.Cantidads = MostrarProducto.Cantidads;
            await Navigation.PushAsync(new DetalleProducto(sendProducts));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));

        }

        //private void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        //{


        // }

        //private async void ButtonRegresar_Clicked(object sender, EventArgs e)
        // {
        //     await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        //}
    }
}