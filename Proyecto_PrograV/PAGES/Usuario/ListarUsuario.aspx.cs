using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Autor
{
    public partial class ListarAutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var usuarios = db.sp_listar_usuario().ToList();

                gvUsuarios.DataSource = usuarios;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error en logs)
                Console.WriteLine("Error al cargar usuarios: " + ex.Message);
            }
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarUsuario")
            {
                // Obtener el ID del usuario seleccionado
                string usuarioId = e.CommandArgument.ToString();

                // Verificar si el ID es válido
                if (!string.IsNullOrEmpty(usuarioId))
                {
                    // Redirigir a la página de modificación
                    Response.Redirect("/PAGES/Usuario/ModificarUsuario.aspx?id=" + usuarioId, false);
                    Context.ApplicationInstance.CompleteRequest(); // Asegura que la respuesta se procese correctamente
                }
            }
        }


    }
}
