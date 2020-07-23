using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CamadaNegocio.LivroCollection livrosCollection = null;

        public MainWindow()
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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
            admin = null;
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRequisitarLivro_Click(object sender, RoutedEventArgs e)
        {
            AddRequisicao addRequisicao = new AddRequisicao();
            addRequisicao.ShowDialog();
        }

        private void BtnEstatisticas_Click(object sender, RoutedEventArgs e)
        {

            Estatisticas estatisticas = new Estatisticas();
            estatisticas.ShowDialog();
            estatisticas = null;
        }

        private void BtnEntregarLivro_Click(object sender, RoutedEventArgs e)
        {
            EntregarLivro entregarLivro = new EntregarLivro();
            entregarLivro.ShowDialog();
        }

        private void ListBoxLivros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtTeste_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HeaderControl_Loaded(object sender, RoutedEventArgs e)
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
