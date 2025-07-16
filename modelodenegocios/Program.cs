using conexion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelodenegocios
{
   public class productosbro 
   {
        public void AgregarProducto( Producto productos)
        {
            using (var db = new estudioDB())
            {
                db.Producto.Add(productos);
                db.SaveChanges();
            }
        }

        public void EliminarProducto(int id)
        {
            using (var db = new estudioDB())
            {
                var producto = db.Productos.Find(id);
                if (producto != null)
                {
                    db.Productos.Remove(producto);
                    db.SaveChanges();
                }
            }
        }
    }

    public class personasbr
    {
        public void agregarpersona(persona personas)
        {
            using (var db = new estudioDB())
            {
                persona personas = db.persona.Add(personas);
                db.SaveChanges();
            }
        }
        public void EliminarProducto(int id)
        {
            using (var db = new estudioDB())
            {
                var persona = db.persona.Find(id);
                if (persona != null)
                {
                    db.persona.Remove(persona);
                    db.SaveChanges();
                }
            }
        }
    }
}
