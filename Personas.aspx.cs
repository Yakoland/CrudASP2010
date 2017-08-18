using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using stefanini2.Modelo;

namespace stefanini2
{
    public partial class Personas : System.Web.UI.Page
    {
        steffDbo consulta = new steffDbo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["accion"] == "MostrarTodo")
            {
                PanelMod.Visible = false;
                PanelCon.Visible = true;
                PanelAdd.Visible = false;
                GridView1.DataSource = consulta.MostrarRegistros("BusinessEntityID AS Id,FirstName AS Nombre,MiddleName AS Inicial,LastName AS Apellido", "Person.Person","");
                GridView1.DataBind();

            }
        }
        protected void paginacion(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = consulta.MostrarRegistros("BusinessEntityID AS Id,FirstName AS Nombre,MiddleName AS Inicial,LastName AS Apellido", "Person.Person","");
            GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = consulta.MostrarRegistros("BusinessEntityID AS Id,FirstName AS Nombre,MiddleName AS Inicial,LastName AS Apellido", "Person.Person", txtNombre.Text);
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow fila = GridView1.Rows[index];
                TableCell celda = fila.Cells[1];
                string idregistro = celda.Text;
                bool borrado = consulta.Eliminar("Person.Person", idregistro);
                GridView1.DataSource = consulta.MostrarRegistros("BusinessEntityID AS Id,FirstName AS Nombre,MiddleName AS Inicial,LastName AS Apellido", "Person.Person", txtNombre.Text);
                GridView1.DataBind();
            }
        }
    }
}