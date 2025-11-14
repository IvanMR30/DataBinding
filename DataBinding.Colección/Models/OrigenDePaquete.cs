using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding.Colección.Models
{
    public class OrigenDePaquete : INotifyPropertyChanged
    {
        //public string Nombre { get; set; } = string.Empty;
        //public string Origen { get; set; } = string.Empty;
        //public bool EstaHabilitado { get; set; }=false;
        private string? _nombre=string.Empty;
        private string? _origen=string.Empty;
        private bool? _estaHabilitado =false;
        public string? Nombre
        {
            get => _nombre; set
            {
                if (value != _nombre)
                {
                    _nombre = value;
                    Onpropertychanged(nameof(Nombre));
                }
                
            }
        }
        public string? Origen
        {
            get => _origen; set
            {
                if (value != _origen)
                {
                    _origen = value;
                    Onpropertychanged(nameof(Origen));
                }

            }
        }
        public bool? EstaHabilitado
        {
            get => _estaHabilitado; set
            {
                if (value != _estaHabilitado)
                {
                    _estaHabilitado = value;
                    Onpropertychanged(nameof(EstaHabilitado));
                }

            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {                
                return $"{Nombre}  -  {Origen}";
        }
        private void Onpropertychanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
            );
        }

    }
}
