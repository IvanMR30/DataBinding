using DataBinding.DataObject.Models;

namespace DataBinding.DataObject
{
    public partial class MainPage : ContentPage
    {
        private int _conteo;
        //_conteo lleva el conteo de la aplicacion
        private Contador contador;
        public MainPage()
        {
            InitializeComponent();
            contador =new Contador();
            BindingContext=contador;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           contador.Contar();

        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            contador.Reiniciar();

        }
    }
}
