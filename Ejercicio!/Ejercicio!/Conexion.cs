using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio_
{
    class Conexion
    {
       SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public static SqlConnection agregaConexion() {
            SqlConnection cnn;
            //nombre de la maquina
            String maquina = "112SALAS25";
            String query = "Data Source="+maquina+";Initial Catalog=Ejercicio!;Persist Security Info=True;User ID=sa;Password=sqladmin";
            cnn = new SqlConnection(query);
            cnn.Open();
            //MessageBox.Show("Conexión exitosa");
            return cnn;
        }


//_______________________________________________________________________________________________________________________________________



        public void llenarComboPrograma(ComboBox cb)
        {
            try
            {
                String query = "select nombre from programas";
                cmd = new SqlCommand(query,agregaConexion());
                dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    cb.Items.Add(dr["nombre"].ToString());
                }
                cb.SelectedIndex = 0;
                dr.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Llenado incorrecto: \n"+e.Message);
            }

        }


//____________________________________________________________________________________________________________________________

        public void llenarComboAlumnos(ComboBox cbAlumnos)
        {
            try
            {
                String query = "select nombre from Aspirante1";
                cmd = new SqlCommand(query, agregaConexion());
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cbAlumnos.Items.Add(dr["nombre"].ToString());
                }
                cbAlumnos.SelectedIndex = 0;
                dr.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Llenado incorrecto: \n" + e.Message);
            }
        }

//______________________________________________________________________________________________________________________________




    }
}
