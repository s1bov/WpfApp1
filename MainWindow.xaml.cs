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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestDBEntities _db = new TestDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            DGUserInfo.ItemsSource = _db.Users.ToList();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userModel = _db.Users.FirstOrDefault(t => t.Login == TbLogin.Text && t.Pasword == PBPassword.Password);
                if (userModel != null)
                {
                    MessageBox.Show($"Hello - {userModel.Login}");
                    TbLogin.Text = string.Empty;
                    PBPassword.Password = string.Empty;
                }
                else
                {
                    MessageBox.Show($"Erorr");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin1.Text) || 
                    string.IsNullOrEmpty(PBPassword1.Password))
            {
                MessageBox.Show($"Error Fields");
            }
            else
            {
                try
                {
                    _db.Users.Add(new User()
                    {
                        Login = TbLogin1.Text,
                        Pasword = PBPassword1.Password
                    });
                    _db.SaveChanges();
                    MessageBox.Show($"New User Created!");
                    DGUserInfo.ItemsSource = _db.Users.ToList();
                    TbLogin1.Text = string.Empty;
                    PBPassword1.Password = string.Empty;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
