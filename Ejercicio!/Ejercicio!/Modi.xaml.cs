using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ejercicio_
{
    /// <summary>
    /// Lógica de interacción para Modi.xaml
    /// </summary>
    public partial class Modi : Window
    {
        public Modi()
        {
            InitializeComponent();

            //Decirle a la conexion que llene el combo
            Conexion con1 = new Conexion();
            con1.llenarComboAlumnos(cbAlumnos);
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            String ncorreo,ngrado,nom;
            ncorreo=tbCorreo.Text;
            ngrado=tbGrado.Text;
            nom=cbAlumnos.Text;

            if (ncorreo == "" && ngrado == "")
            {
                MessageBox.Show("No cambiaste aada");

            }
            else
                if (ncorreo == "")
                {
                    String query1 = "update Aspirante1 set grado='" + ngrado + "' where nombre Like '" + nom + "'";
                    SqlCommand cmd = new SqlCommand(query1, Conexion.agregaConexion());
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Modificacion Exitosa");
                    }
                    else
                    {
                        MessageBox.Show("Modificacion Fallida");
                    }
                }else
                    if (ngrado == "")
                    {
                        String query2 = "update Aspirante1 set correo='" + ncorreo + "' where nombre Like '" + nom + "'";
                        SqlCommand cmd = new SqlCommand(query2, Conexion.agregaConexion());
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Modificacion Exitosa");
                        }
                        else
                        {
                            MessageBox.Show("Modificacion Fallida");
                        }
                    }
                    else
                    {
                        //________________________________
                        String query = "update Aspirante1 set grado='" + ngrado + "' ,correo='" + ncorreo + "' where nombre Like '" + nom + "'";
                        SqlCommand cmd = new SqlCommand(query, Conexion.agregaConexion());
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Modificacion Exitosa");
                        }
                        else
                        {
                            MessageBox.Show("Modificacion Fallida");
                        }
                        //_____________________________________________
                    }
        }


    }
}
