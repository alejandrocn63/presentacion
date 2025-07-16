using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }

    public class ContactoDatos
    {
        private static List<Contacto> lista = new List<Contacto>();

        public List<Contacto> ObtenerTodos()
        {
            return lista;
        }

        public void Agregar(Contacto contacto)
        {
            lista.Add(contacto);
        }

        public void Editar(Contacto viejo, Contacto nuevo)
        {
            var index = lista.IndexOf(viejo);
            if (index >= 0)
                lista[index] = nuevo;
        }

        public void Eliminar(Contacto contacto)
        {
            lista.Remove(contacto);
        }

        public List<Contacto> Buscar(string filtro)
        {
            return lista.Where(c =>
                c.Nombre.ToLower().Contains(filtro.ToLower()) ||
                c.Correo.ToLower().Contains(filtro.ToLower()) ||
                c.Telefono.Contains(filtro)).ToList();
        }
    }
}
