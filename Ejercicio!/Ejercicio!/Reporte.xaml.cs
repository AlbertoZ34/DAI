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
    /// Lógica de interacción para Reporte.xaml
    /// </summary>
    public partial class Reporte : Window
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Decirle a la conexion que llene el combo
            Conexion con1 = new Conexion();
            con1.llenarComboPrograma(cbInges);
            SqlConnection con;
            con = Conexion.agregaConexion();
            SqlCommand cmm = new SqlCommand(String.Format("SELECT * FROM Aspirante1"), con);
            SqlDataReader lec = cmm.ExecuteReader();
            gdReporte.ItemsSource = lec;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void btRepIng_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con;
            con = Conexion.agregaConexion();
            SqlCommand cmm = new SqlCommand(String.Format("SELECT * FROM Aspirante1 WHERE inge='" + cbInges.Text + "'"), con);
            SqlDataReader lec = cmm.ExecuteReader();
            gdReporte.ItemsSource = lec;

        }
    }
}
