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
    /// Interaction logic for AddLivro.xaml
    /// </summary>
    public partial class AddLivro : Window
    {
        public AddLivro()
        {
            InitializeComponent();
            CamadaNegocio.Livro livro = new CamadaNegocio.Livro();

            livro.Titulo = "Inserir Titulo...";
            livro.Autor = "Inserir Autor...";
            livro.Id = 1;
            
            this.DataContext = livro;
        }

        #region Metodos

        private void NovoRegisto()
        {
            CamadaNegocio.Livro novo = this.DataContext as CamadaNegocio.Livro;
                if (novo != null)
                {
                    novo.Novo();
                }
         

        }

        private void GravarRegisto()
        {
            string sErro = string.Empty;
            //CamadaNegocio.Livro livro = new CamadaNegocio.Livro(27, "TesteTrue27", "Teste Autor27");
            CamadaNegocio.Livro livro = this.DataContext as CamadaNegocio.Livro;
            this.DataContext = livro;

            if (livro.Gravar(ref sErro))

            {
                MessageBox.Show("Livro Guardado com Sucesso!");
            }

            else
            {
                MessageBox.Show(string.Format("Erro {0}", sErro));
            }
        }

        private void EliminarRegisto()
        {
            string sErro = string.Empty;
            CamadaNegocio.Livro livro = (CamadaNegocio.Livro)this.DataContext;

            if (livro.Eliminar(ref sErro))
            {
                MessageBox.Show("Eliminado com sucesso.");
            }
            else
            {
                MessageBox.Show(string.Format("Erro {0}", sErro));
            }

            this.Close();
        }

        #endregion

        private void BtnConfirmarAdicionarLivro_Click(object sender, RoutedEventArgs e)
        {
            this.GravarRegisto();
         
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnNovoLivro_Click(object sender, RoutedEventArgs e)
        {
            this.NovoRegisto();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnEliminarLivro_Click(object sender, RoutedEventArgs e)
        {
            this.EliminarRegisto();
        }

        private void TextBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnVoltarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AdminLivro adminLivro = new AdminLivro();
            adminLivro.ShowDialog();
            adminLivro = null;
        }
    }
}
