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
    /// Interaction logic for AddRequisicao.xaml
    /// </summary>
    public partial class AddRequisicao : Window
    {
        #region Construtores
        public AddRequisicao()
        {
            InitializeComponent();
            CamadaNegocio.Requisicao requisicao = new CamadaNegocio.Requisicao(); 
            DateTime inicio = DateTime.Today;
            DateTime fim = DateTime.Today.AddDays(10);

            //datas
            requisicao.DataInicio = inicio;
            requisicao.DataFim = fim;
            this.DataContext = requisicao;

            //Obter lista livros

            CamadaNegocio.LivroCollection livros = CamadaNegocio.Livro.ObterListaLivros();

            List<string> livrosFechados = (from element in livros
                                         where (element.Aberto == false)
                                         select element.Titulo).ToList();

            this.comboBoxLivro.DataContext = livrosFechados;
           

            //Obter lista requisitores
            CamadaNegocio.RequisitorCollection requisitores = CamadaNegocio.Requisitor.ObterListaRequisitores();
            this.comboBoxRequisitor.DataContext = requisitores;

            if (requisitores != null)
            {

                List<string> nomes = (from element in requisitores
                                      select element.Nome).ToList();
                this.comboBoxRequisitor.DataContext = nomes;
            }

        }
        #endregion

        #region Propriedades
        private CamadaNegocio.LivroCollection livro;

        public CamadaNegocio.LivroCollection Livro
        {
            get
            {
                return this.livro;

            }
            set
            {
                this.livro = value;

            }
        }

        #endregion

        #region Metodos


        private void GravarRegisto()
        {
            string sErro = string.Empty;
            CamadaNegocio.Requisicao requisicao = (CamadaNegocio.Requisicao)this.DataContext;

            if (comboBoxLivro.SelectedItem != null)
            {
                String tituloSelecionado = comboBoxLivro.SelectedItem.ToString();

                int idLivro = (from element in CamadaNegocio.Livro.ObterListaLivros()
                          where (element.Titulo.Contains(tituloSelecionado))
                          select element.Id).First();
                requisicao.IdLivro = idLivro;

                //Selecionar livro a partir do titulo
                CamadaNegocio.Livro livroSelecionado= (from element in CamadaNegocio.Livro.ObterListaLivros()
                                    where (element.Id==idLivro)
                                    select element).First();

                if (livroSelecionado != null)
                {
                    livroSelecionado.Aberto = true;

                    if (livroSelecionado.Gravar(ref sErro))

                    {
                        //MessageBox.Show("Livro selecionado com Sucesso!");
                        //refrescarListaLivros(Livro.ObterListaLivros());
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Erro {0}", sErro));
                    }

                }

            }


            if (comboBoxRequisitor.SelectedItem != null)
            {
                String nomeSelecionado = comboBoxRequisitor.SelectedItem.ToString();

                int idRequisitor = (from element in CamadaNegocio.Requisitor.ObterListaRequisitores()
                          where (element.Nome.Contains(nomeSelecionado))
                          select element.Id).First();
                requisicao.IdRequisitor = idRequisitor;

            }
             // Criar o count para o ID da requisição

            List <int> idRequisicoes = (from element in CamadaNegocio.Requisicao.ObterListaRequisicoes()
                                select element.Id).ToList();
            idRequisicoes.Count();

            requisicao.Id = idRequisicoes.Count()+1;


            if (requisicao.Gravar(ref sErro))
            {
                MessageBox.Show("Livro requisitado com Sucesso!");
            }
            else
            {
                MessageBox.Show(string.Format("Erro {0}", sErro));
            }
        }

        #endregion


        private void BtnConfirmarRequisicao_Click(object sender, RoutedEventArgs e)
        {
            this.GravarRegisto();
            Close();
        }

        private void ComboBoxRequisitor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnVoltarMain_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
