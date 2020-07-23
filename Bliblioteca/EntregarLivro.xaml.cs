using CamadaNegocio;
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
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for EntregarLivro.xaml
    /// </summary>
    public partial class EntregarLivro : Window
    {
              
        #region Contrutores
        CamadaNegocio.LivroCollection livrosCollection=null;
        public EntregarLivro()
        {

            InitializeComponent();
            CamadaNegocio.LivroCollection livros = CamadaNegocio.Livro.ObterListaLivros();
           

            List<Livro> livrosAbertos = (from element in livros
                                    where (element.Aberto == true)
                                    select element).ToList();
           
            if (livros != null)
            {
                List<string> titulos = (from element in livros
                                        where (element.Aberto == true)
                                        select element.Titulo).ToList();
                this.listBoxRequisicoes.DataContext = titulos;
            }
            livrosCollection = livros;

        }
        private void refrescarListaLivros(CamadaNegocio.LivroCollection livros)
        {

            if (livros != null)
            {
                List<string> titulos = (from element in livros
                                        where (element.Aberto == true)
                                        select element.Titulo).ToList();

                this.listBoxRequisicoes.DataContext = titulos;
            }
        }


        #endregion
                
        #region Fields



        private CamadaNegocio.LivroCollection livros;



        #endregion
     
        #region Propriedades
        public CamadaNegocio.LivroCollection Livros
        {
            get { return this.livros; }
            set { this.livros = value; }
        }



        public CamadaNegocio.Livro livroSelecionado { get; set; }
        #endregion

        //Filtrar livros

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            String textoFiltro = this.textBoxFiltro.Text;
            CamadaNegocio.LivroCollection livrosFiltrados = this.livrosCollection.Filtrar(textoFiltro);



            List<string> titulos = (from element in livrosFiltrados
                                    where (element.Aberto == true)
                                    select element.Titulo).ToList();




            this.listBoxRequisicoes.DataContext = titulos;
        }



        private void btnEntregarLivro_Click(object sender, RoutedEventArgs e)
        {
            String tituloSelecionado = listBoxRequisicoes.SelectedItem.ToString();
            string sErro = string.Empty;
            if (tituloSelecionado != null)
            {
                //Selecionar livro a partir do titulo
                livroSelecionado = (from element in Livro.ObterListaLivros()
                                    where (element.Titulo.Contains(tituloSelecionado))
                                    select element).First();
                if (livroSelecionado != null)
                {
                    livroSelecionado.Aberto = false;

                    if (livroSelecionado.Gravar(ref sErro))

                    {
                        MessageBox.Show("Livro entregue com Sucesso!");
                        refrescarListaLivros(Livro.ObterListaLivros());
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Erro {0}", sErro));
                    }



                }




            }








        }



        private void listBoxRequisicoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }



        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }



        private void textBoxFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            String textoFiltro = this.textBoxFiltro.Text;
            CamadaNegocio.LivroCollection livrosFiltrados = this.livros.Filtrar(textoFiltro);
            this.listBoxRequisicoes.DataContext = livrosFiltrados;



        }

        private void BtnVoltarMain_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
