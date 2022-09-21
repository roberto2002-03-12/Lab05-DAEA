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
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }
        public ManCategoria(int iD)
        {
            InitializeComponent();
            ID = iD;
            btnEliminar.IsEnabled = false;
            if (ID>0)
            {
                BCategory bCategory = new BCategory();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategory.Listar(ID);
                btnEliminar.IsEnabled = true;

                if (categorias.Count>0)
                {
                    lblID.Content = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategory Bcategory = null;
            bool result = true;

            try
            {
                Bcategory = new BCategory();
                if (ID > 0)
                {
                    result = Bcategory.Actualizar(new Categoria { IdCategoria = ID, NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }
                else
                {
                    result = Bcategory.Insertar(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }

                if (!result)
                {
                    MessageBox.Show("No se coloco nada");
                }

                Close();

            } catch (Exception)
            {
                MessageBox.Show("Cominicarse con el administrador");
            } finally
            {
                Bcategory = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BCategory Bcategory = null;
            bool result = true;
            try
            {
                Bcategory = new BCategory();
                if (ID > 0)
                {
                    result = Bcategory.Eliminar(ID);
                }

                Close();
            } catch (Exception ex)
            {
                MessageBox.Show("No logro eliminarse");
            }
        }
    }
}
