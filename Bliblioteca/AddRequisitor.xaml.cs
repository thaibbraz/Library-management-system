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
    /// Interaction logic for AddRequisitor.xaml
    /// </summary>
    public partial class AddRequisitor : Window
    {
        public AddRequisitor()
        {
            InitializeComponent();
            CamadaNegocio.Requisitor requisitor = new CamadaNegocio.Requisitor();

            this.DataContext = requisitor;
        }

        #region Metodos

        private void NovoRegisto()
        {
            CamadaNegocio.Requisitor requisitor = this.DataContext as CamadaNegocio.Requisitor;
            if (requisitor != null)
            {
                requisitor.Novo();
            }
        }

        private void GravarRegisto()
        {
            string sErro = string.Empty;
            CamadaNegocio.Requisitor requisitor = (CamadaNegocio.Requisitor)this.DataContext;



            if (requisitor.Gravar(ref sErro))
            {
                MessageBox.Show("Gravado com sucesso.");
            }
            else
            {
                MessageBox.Show(string.Format("Erro {0}", sErro));
            }
        }

        private void EliminarRegisto()
        {
            string sErro = string.Empty;
            CamadaNegocio.Requisitor requisitor = (CamadaNegocio.Requisitor)this.DataContext;



            if (requisitor.Eliminar(ref sErro))
            {
                MessageBox.Show("Eliminado com sucesso.");
            }
            else
            {
                MessageBox.Show(string.Format("Erro {0}", sErro));
            }
        }
        #endregion

        private void BtnConfirmarAdicionarRequisitor_Click(object sender, RoutedEventArgs e)
        {
                // Criar instância requisitor

                string sErro = string.Empty;

            CamadaNegocio.Requisitor requisitor = this.DataContext as CamadaNegocio.Requisitor;

            if (requisitor.Gravar(ref sErro))

            {
                MessageBox.Show("Requisitor Guardado com Sucesso!");
            }

            else
            {
                MessageBox.Show(string.Format("Erro {0}", sErro));
            }

        }

        private void BtnVoltarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AdminLivro adminLivro = new AdminLivro();
            adminLivro.ShowDialog();
            adminLivro = null;
        }

        private void TextBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnEliminarRequisitor_Click(object sender, RoutedEventArgs e)
        {
            
                string sErro = string.Empty;
                CamadaNegocio.Requisitor requisitor = (CamadaNegocio.Requisitor)this.DataContext;

                if (requisitor.Eliminar(ref sErro))
                {
                    MessageBox.Show("Eliminado com sucesso.");
                }
                else
                {
                    MessageBox.Show(string.Format("Erro {0}", sErro));
                }

            this.Close();
       
        }
    }
}
