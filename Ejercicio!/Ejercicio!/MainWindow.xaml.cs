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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio_
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Decirle a la conexion que llene el combo
            Conexion con1 = new Conexion();
            con1.llenarComboPrograma(cbInges);

            con1.llenarComboAlumnos(cbAlumnos);
        }

        private void btAlta_Click(object sender, RoutedEventArgs e)
        {
            String sexo, nombre, grado, correo, fecha, inge;
            //
            if (tbNombre.Text != "" && tbSexo.Text != "" && tbCorreo.Text != "" && tbGrado.Text != "" && dpFechaN.SelectedDate.ToString() != "") {
                nombre = tbNombre.Text;
                sexo = tbSexo.Text;
                grado = tbGrado.Text;
                correo = tbCorreo.Text;
                fecha = dpFechaN.Text;
                inge = cbInges.Text;

                try
                {   //traemos una conexion
                    SqlConnection con2 = Conexion.agregaConexion();
                    String query = String.Format("Insert into Aspirante1 Values('{0}','{1}','{2}','{3}','{4}','{5}')",nombre,sexo,fecha,grado,correo,inge);
                    SqlCommand cmd= new SqlCommand(query,con2);
                    int res = cmd.ExecuteNonQuery();
                    con2.Close();

                    if (res > 0) {
                        MessageBox.Show("Alta exitosa!");
                    
                    }else
                        MessageBox.Show("Alta no exitosa!");



                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se hizo la coneccion: \n"+ex.Message);
                    
                }
                
                

            }
        }


        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            String nombre;

            if (cbAlumnos.Text != "") {
                nombre = cbAlumnos.Text;
                try
                {
                     SqlConnection cnn = Conexion.agregaConexion();
                     String query = "Delete from Aspirante1 WHERE Aspirante1.nombre='"+nombre+"'";
                     SqlCommand cmd = new SqlCommand(query, cnn);
                     int res = cmd.ExecuteNonQuery();
                     cnn.Close();
                     if (res > 0)
                     {
                        MessageBox.Show("Baja exitosa!");
                     }
                     else
                        MessageBox.Show("Alta no exitosa!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se hizo la coneccion: \n" + ex.Message);
                    
                }
               
            
            }

            



        }

        
    }
}
