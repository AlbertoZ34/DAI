using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Info : System.Web.UI.Page
{
    protected OdbcConnection abrirConexion()
    {
        OdbcConnection conexion = null;
        try
        {
            String conectar = "Driver= {SQL Server Native Client 11.0}; Server=112SALAS13; Uid=sa; Pwd=sqladmin; Database=Ventas";
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
        if (Session["vendedor"] != null && Session["vendedor"]!="")
        {
            OdbcConnection conexion = abrirConexion();
            String nombreV = Session["vendedor"].ToString();
            String query = "Select SueldoBase from Vendedor where Vendeor= '" + nombreV + "'";
            OdbcCommand cmm = new OdbcCommand(query, conexion);
            OdbcDataReader lec = cmm.ExecuteReader();
            int sB = 0;
            if (lec.Read())
            {
                sB = lec.GetInt32(0);
                
            }
            
            String query2 = "Select TotalVenta from Vendedor where Vendeor = '" + nombreV + "'";
            OdbcCommand cmm2 = new OdbcCommand(query2, conexion);
            OdbcDataReader lec2 = cmm2.ExecuteReader();
            int venta= 0;
            if (lec2.Read())
            {
                venta = lec2.GetInt32(0);

            }
            double comision = 0;

            if (venta >= 100 && venta <= 1000)
            {
                comision = venta * .1;
            }
            else {
                if (venta >= 1000 && venta <= 2000)
                    comision = venta * .2;
                else {
                    if (venta >= 2000 && venta <= 4000)
                        comision = venta * .25;
                    else {
                        if (venta >= 4000)
                            comision = venta * .35;
                    }

                }
            
            }
            double sueldo = sB + comision;
            Response.Write("su sueldo es: "+sueldo);

            conexion.Close();

        }
        else
            Response.Write("no existe vendedor");
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}