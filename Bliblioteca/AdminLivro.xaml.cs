using CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for AdminLivro.xaml
    /// </summary>
    public partial class AdminLivro : Window
    {
        CamadaNegocio.LivroCollection livrosCollection = null;

        public AdminLivro()
        {
            InitializeComponent();
            CamadaNegocio.LivroCollection livros = CamadaNegocio.Livro.ObterListaLivros();

            if (livros != null)
            {
                List<string> titulos = (from element in livros
                                      select element.Titulo).ToList();
                this.listBoxLivros.DataContext = titulos;
            }

            livrosCollection = livros;
        }

 

        private void BtnAdicionarLivro_Click(object sender, RoutedEventArgs e)
        {

            Close();
            AddLivro addLivro = new AddLivro();
            addLivro.ShowDialog();
            addLivro = null;
        }

       
        private void BtnVoltarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Admin admin = new Admin();
            admin.ShowDialog();
            admin = null;
        }

        private void ListBoxLivros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEliminarLivro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String textoFiltro = this.textBoxPesquisarLivros.Text;
            CamadaNegocio.LivroCollection livrosFiltrados = this.livrosCollection.Filtrar(textoFiltro);



            List<string> titulos = (from element in livrosFiltrados
                                    select element.Titulo).ToList();




            this.listBoxLivros.DataContext = titulos;
        }
    }
}
