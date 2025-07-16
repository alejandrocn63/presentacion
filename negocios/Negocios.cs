using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Datos;


namespace Negocios
{
    public class ContactoNegocio
    {
        private ContactoDatos datos = new ContactoDatos();

        public List<Contacto> ObtenerTodos() => datos.ObtenerTodos();

        public void Agregar(Contacto c) => datos.Agregar(c);

        public void Editar(Contacto viejo, Contacto nuevo) => datos.Editar(viejo, nuevo);

        public void Eliminar(Contacto c) => datos.Eliminar(c);

        public List<Contacto> Buscar(string filtro) => datos.Buscar(filtro);
    }
}

