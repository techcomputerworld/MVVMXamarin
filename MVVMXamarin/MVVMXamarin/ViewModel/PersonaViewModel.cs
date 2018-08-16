using MVVMXamarin.Model;
using MVVMXamarin.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMXamarin.ViewModel
{
    public class PersonaViewModel : PersonaModel
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }
        PersonaServicio servicio = new PersonaServicio();
        PersonaModel modelo;
        
        public PersonaModel SelectedPerson { get; set; }
        public PersonaViewModel()
        {
            Personas = servicio.Consultar();
            SelectedCommand = new Command(async () => await Selected(), () => !IsBusy);
            GuardarCommand = new Command(async()=> await Guardar(), ()=> !IsBusy);
            ModificarCommand = new Command(async()=> await Modificar(), ()=> !IsBusy);
            EliminarCommand = new Command(async()=> await Eliminar(), ()=> !IsBusy);
            LimpiarCommand = new Command(Limpiar, () => !IsBusy);
        }

        

        //definir los Command que son los que permiten los eventos entre las Views y los ViewModel
        public Command SelectedCommand { get; set; }
        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

      
        private async Task Selected()
        {
            
        }
        private async Task Guardar()
        {
            IsBusy = true;
            Guid IdPersona = Guid.NewGuid();
            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = IdPersona.ToString()
            };
            servicio.Guardar(modelo);
            //2000 milisegundos que son 2 segundos.
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modificar()
        {
            IsBusy = true;

            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Eliminar()
        {
            IsBusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        }
        
    }
}
