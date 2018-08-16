using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMXamarin.Model;

namespace MVVMXamarin.Servicio
{
    public class PersonaServicio 
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }
        

        public PersonaServicio()
        {
            //esto para que solo nos cree un objeto si es nulo, si no usaremos el objeto que habiamos creado o se creara solo una vez.
            if (Personas == null)
            {
                Personas = new ObservableCollection<PersonaModel>();
            }
        }
        public ObservableCollection<PersonaModel> Consultar()
        {
            return Personas;
        }
        public void Guardar(PersonaModel modelo)
        {
            Personas.Add(modelo);
        }
        public void Modificar (PersonaModel modelo)
        {
            for (int i = 0; i < Personas.Count; i++)
            {
                if (Personas[i].Id == modelo.Id)
                {
                    Personas[i] = modelo;
                }
            }
        }
        public void Eliminar(string idPersona)
        {
            PersonaModel modelo = Personas.FirstOrDefault(p => p.Id == idPersona);
            Personas.Remove(modelo);
        }
        
    }
}
