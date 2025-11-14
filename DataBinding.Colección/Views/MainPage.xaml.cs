using System.Collections.ObjectModel;
using DataBinding.Colección.Models;

namespace DataBinding.Colección.Views;

public partial class MainPage : ContentPage
{
	public ObservableCollection<OrigenDePaquete> Origenes{ get; }
    private OrigenDePaquete? _origenseleccionado=null;
    private string? _nombreDelOrigen=string.Empty;
    private string? _rutaDelOrigen=string.Empty ;
    public OrigenDePaquete? OrigenSeleccionado {  
        get=>_origenseleccionado;
        set {
            if (_origenseleccionado!=value) 
            { 
                _origenseleccionado = value; 
                OnPropertyChanged(nameof(OrigenSeleccionado));
            } 
        } 
    }
    public string NombreDelOrigen
    {
        get => _nombreDelOrigen;
        set
        {
            if (_nombreDelOrigen != value)
            {
                _nombreDelOrigen = value!;
                OnPropertyChanged(nameof(NombreDelOrigen));
            }
        }
    }
    public string RutaDelOrigen
    {
        get => _rutaDelOrigen; 
        set
        {
            if (_rutaDelOrigen != value)
            {
                _rutaDelOrigen = value!;
                OnPropertyChanged(nameof(RutaDelOrigen));
            }
        }
    }
	public MainPage()
	{      
		InitializeComponent();
        OrigenSeleccionado =null;

        Origenes = new ObservableCollection<OrigenDePaquete>();
		CargarDatos();

        BindingContext = this;

        OrigenesListView.ItemsSource= Origenes;
        if (Origenes.Count > 0)
        {
            OrigenSeleccionado = Origenes[0];
        }
        //OrigenesListView.ItemsSource = _origenes;
        //OrigenesListView.SelectedItem = origenSeleccionado;
    }
	private void CargarDatos() {

        Origenes.Add(new OrigenDePaquete { Nombre = "nuget.org", Origen = "https://api.nuget.org/v3/index.json", EstaHabilitado = true });
        Origenes.Add(new OrigenDePaquete { Nombre = "Microsoft Visual Studio Offline Packages", Origen = @"C:\Program Files(x86)\Microsoft SDKs\NugetPackages", EstaHabilitado = false });
        
	}

    private void OnAgregarButtonClicked(object sender, EventArgs e) {
        var origen = new OrigenDePaquete
        {
         Nombre = "OrigenDePaquete", Origen = "URL o ruta", EstaHabilitado = false, 
        };
        Origenes.Add(origen);
        OrigenSeleccionado = origen;
    }
    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (OrigenSeleccionado !=null)
        {
            var indice= Origenes.IndexOf(OrigenSeleccionado);
            OrigenDePaquete? nuevoSeleccionado;
            if (Origenes.Count>1) {
                //hay mas de un elemento
                if (indice < Origenes.Count-1) {
                    nuevoSeleccionado= Origenes[indice+1];
                }
                else
                {
                    //El elemento seleccionado es el utlimo 
                    nuevoSeleccionado=Origenes[indice-1];
                }
            }
            else
            {
                //Solo hay un elemento
                nuevoSeleccionado=null;
            }
            Origenes.Remove(OrigenSeleccionado);
            OrigenSeleccionado = nuevoSeleccionado;
            //OrigenesListView.ItemsSource = null;
            //OrigenesListView.ItemsSource = _origenes;
            //OrigenesListView.SelectedItem = nuevoSeleccionado;
        }
    }

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        NombreDelOrigen = string.Empty;
        RutaDelOrigen = string.Empty;

        if (OrigenSeleccionado !=null)
        {
            NombreDelOrigen = OrigenSeleccionado.Nombre;
            RutaDelOrigen = OrigenSeleccionado.Origen;
        }
        else
        {
            NombreDelOrigen = string.Empty;
            RutaDelOrigen = string.Empty;
        }
    }

    private void Actualizar(object sender, EventArgs e)
    {
        if (OrigenSeleccionado != null) {
          OrigenSeleccionado.Nombre= NombreDelOrigen;
          OrigenSeleccionado.Origen = RutaDelOrigen;
        }
    }
}