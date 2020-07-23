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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void BtnAdicionarLivro_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnAdicionarRequisitor_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AddRequisitor addRequisitor = new AddRequisitor();
            addRequisitor.ShowDialog();
        }

        private void BtnAdminLivros_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AdminLivro adminLivro = new AdminLivro();
            adminLivro.ShowDialog();
        }

        private void BtnAdminRequisitor_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AdminRequisitor adminRequisitor = new AdminRequisitor();
            adminRequisitor.ShowDialog();
        }

        private void HeaderControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVoltarMain_Click(object sender, RoutedEventArgs e)
        {
            
                Close();
        }
    }
}
