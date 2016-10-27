using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Indexd : System.Web.UI.Page
{
    protected OdbcConnection abrirConexion()
    {
        OdbcConnection conexion = null;
        try
        {
            String conectar = "Driver= {SQL Server Native Client 11.0}; Server=CC201-13; Uid=sa; Pwd=sqladmin; Database=mensajeria";
            conexion = new OdbcConnection(conectar);
            conexion.Open();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());

        }
        return conexion;

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btSiguiente_Click(object sender, EventArgs e)
    {
        Session["vendedor"] = tbVendedor.Text;
        Response.Redirect("Info.aspx");
    }
}