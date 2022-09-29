using Business;
using Entity;
using System;
using System.CodeDom;
using System.Collections.Generic;
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

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int iD)
        {
            InitializeComponent();
            ID = iD;
            btnEliminar.IsEnabled = false;
            if (ID>0)
            {
                BProducto bProducto = new BProducto();
                List<Productos> productos = new List<Productos>();
                productos = bProducto.Listar(ID);
                btnEliminar.IsEnabled = true;

                if (productos.Count>0)
                {
                    lblID.Content = productos[0].IdProducto.ToString();
                    txtNombreProducto.Text = productos[0].NombreProducto;
                    numPrecioUnidad.Text = productos[0].PrecioUnidad.ToString();
                    numSuspendido.Text = productos[0].Suspendido.ToString();
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto Bproducto = null;
            bool result = true;

            try
            {
                Bproducto = new BProducto();
                if (ID > 0)
                {
                    result = Bproducto.Actualizar(new Productos { IdProducto = ID, 
                        NombreProducto = txtNombreProducto.Text, 
                        PrecioUnidad = Convert.ToDouble(numPrecioUnidad.Text), 
                        Suspendido = Convert.ToInt32(numSuspendido.Text)
                    });
                }
                else
                {
                    var produc = new Productos
                    {
                        NombreProducto = txtNombreProducto.Text,
                        PrecioUnidad = Convert.ToDouble(numPrecioUnidad.Text),
                        Suspendido = Convert.ToInt32(numSuspendido.Text)
                    };
                    Console.WriteLine(produc.NombreProducto + " debe ser string " + produc.NombreProducto.GetType());
                    Console.WriteLine(produc.PrecioUnidad + " debe ser double " + produc.PrecioUnidad.GetType());
                    Console.WriteLine(produc.Suspendido + " debe ser int " + produc.Suspendido.GetType());
                    result = Bproducto.Insertar(new Productos { 
                        NombreProducto = txtNombreProducto.Text, 
                        PrecioUnidad = Convert.ToDouble(numPrecioUnidad.Text), 
                        Suspendido = Convert.ToInt32(numSuspendido.Text)
                    });
                }

                if (!result)
                {
                    MessageBox.Show("No se coloco nada");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Bproducto = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto Bproducto = null;
            bool result = true;

            try
            {
                Bproducto = new BProducto();
                if (ID > 0)
                {
                    result = Bproducto.Eliminar(ID);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numSuspendido_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
