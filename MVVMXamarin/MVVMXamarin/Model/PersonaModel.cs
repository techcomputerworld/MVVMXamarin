using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMXamarin.Model
{
    public class PersonaModel : INotifyPropertyChanged
    {
        private string id;
        private string apellido;
        private string nombre;
        private int edad;
        private string nombreCompleto;
        private bool isBusy = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public bool IsBusy
        {
            get { return isBusy = false; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellido}";
            }
            set
            {
                nombreCompleto = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                edad = value;
                OnPropertyChanged();
            }
        }
        public string Mensaje
        {
            get
            {
                return $"Tu nombre es {NombreCompleto}";
            }
        }
       


    }
}
