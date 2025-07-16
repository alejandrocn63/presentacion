using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Negocios;

namespace presentacion
{
    public partial class Form1 : Form
    {
        private ContactoNegocio negocio = new ContactoNegocio();
        private CancellationTokenSource cts = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var nuevo = new Contacto { Nombre = "Nuevo", Correo = "nuevo@correo.com", Telefono = "123456" };
            negocio.Agregar(nuevo);
            ActualizarLista();
        }

        private void ebtneditar_Click(object sender, EventArgs e)
        {
            if (grandvista.CurrentRow != null)
            {
                var seleccionado = (Contacto)grandvista.CurrentRow.DataBoundItem;
                var nuevo = new Contacto { Nombre = "Editado", Correo = seleccionado.Correo, Telefono = seleccionado.Telefono };
                negocio.Editar(seleccionado, nuevo);
                ActualizarLista();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (grandvista.CurrentRow != null)
            {
                var seleccionado = (Contacto)grandvista.CurrentRow.DataBoundItem;
                negocio.Eliminar(seleccionado);
                ActualizarLista();
            }
        }
        private void ActualizarLista()
        {
            grandvista.DataSource = null;
            grandvista.DataSource = negocio.ObtenerTodos();
        }
        private async void btnbuscar_Click(object sender, EventArgs e)
        {
            cts.Cancel(); // Cancelar búsqueda anterior
            cts = new CancellationTokenSource();
            var token = cts.Token;

            lblEstado.Text = "Buscando...";

            try
            {
                await Task.Delay(300, token); // Debounce
                string texto = txtBuscar.Text.Trim().ToLower();

                var resultados = await Task.Run(() =>
                {
                    Task.Delay(200).Wait(); // Simula retraso de base de datos
                    return negocio.Buscar(texto);
                });

                if (!token.IsCancellationRequested)
                {
                    grandvista.Invoke(new Action(() =>
                    {
                        grandvista.DataSource = null;
                        grandvista.DataSource = resultados;
                        lblEstado.Text = resultados.Count == 0 ? "No hay resultados." : "";
                    }));
                }
            }
            catch (TaskCanceledException) { }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            grandvista.AutoGenerateColumns = true;
            grandvista.DataSource = negocio.ObtenerTodos();
        }


    }
}