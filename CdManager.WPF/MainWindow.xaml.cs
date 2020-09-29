using CdManager.Model;
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

namespace CdManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cd> _cds;
        private Cd _highlightedCd;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewCDWindow editWindow = new NewCDWindow(listBoxCds.SelectedItem as Cd);
            editWindow.ShowDialog();

            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            _highlightedCd = listBoxCds.SelectedItem as Cd;
           
            Repository repository = Repository.GetInstance();

            if(_highlightedCd != null)
            {
                repository.DeleteCd(_highlightedCd);
            }
            else
            {
                MessageBox.Show("Keine CD ausgewählt!");
            }

            _cds = repository.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            NewCDWindow newWindow = new NewCDWindow(null);
            newWindow.ShowDialog();

            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }
    }
}
