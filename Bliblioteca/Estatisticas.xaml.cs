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
    /// Interaction logic for Estatisticas.xaml
    /// </summary>

    public partial class Estatisticas : Window
    {
        public Estatisticas()
        {
            InitializeComponent();
            MostrarListaEstatistica();
           
            
        }
        
        private void MostrarListaEstatistica()
        { //obter estatistica do total de livros
            List<int> IdLivros = (from element in CamadaNegocio.Livro.ObterListaLivros()
                                  select element.Id).ToList();
            int totalLivros = IdLivros.Count();

            textBoxLivros.Text = totalLivros.ToString();


            //obter estatistica do total de livros requisitados
            List<int> IdLivrosRequisitados = (from element in CamadaNegocio.Livro.ObterListaLivros()
                                              where (element.Aberto==true)
                                  select element.Id).ToList();
            int totalLivrosRequisitados = IdLivrosRequisitados.Count();

            textBoxLivrosRequisitados.Text = totalLivrosRequisitados.ToString();

            //obter estatistica do total de livros disponiveis
            List<int> IdLivrosDisponiveis = (from element in CamadaNegocio.Livro.ObterListaLivros()
                                              where (element.Aberto == false)
                                              select element.Id).ToList();
            int totalLivrosDisponiveis = IdLivrosDisponiveis.Count();

           textBoxLivrosDisponiveis.Text = totalLivrosDisponiveis.ToString();


            //obter estatistica do total de requisicoes
            List<int> IdRequisicoes = (from element in CamadaNegocio.Requisicao.ObterListaRequisicoes()
                                             select element.Id).ToList();
            int totalRequisicoes = IdRequisicoes.Count();

            textBoxRequisicoes.Text = totalRequisicoes.ToString();

        }

        private void ListBoxEstatistica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnVoltarLivros_Click(object sender, RoutedEventArgs e)
        {
            Close();
        
        }
    }
}
