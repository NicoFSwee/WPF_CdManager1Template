using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CdManager.WPF
{
    /// <summary>
    /// Interaction logic for NewCDWindow.xaml
    /// </summary>
    public partial class NewCDWindow : Window
    {
        private Cd _cd;
        private bool isNewCd;
        public NewCDWindow(Cd cd)
        {
            InitializeComponent();
            _cd = cd;
            Loaded += NewCDWindow_Loaded;
        }

        private void NewCDWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancle.Click += BtnCancle_Click;
            btnSave.Click += BtnSave_Click;

            if(_cd == null)
            {
                DataContext = new Cd();
                tbHeader.Text = "Neue CD anlegen";
                isNewCd = true;
            }
            else
            {
                DataContext = new Cd() { AlbumTitle = _cd.AlbumTitle, Artist = _cd.Artist };
                tbHeader.Text = "CD bearbeiten";
                isNewCd = false;
            }
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(isNewCd)
            {
                Repository.GetInstance().AddCd(DataContext as Cd);
                this.Close();
            }
            else
            {
                Repository.GetInstance().DeleteCd(_cd);
                Repository.GetInstance().AddCd(DataContext as Cd);
                this.Close();
            }

        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
