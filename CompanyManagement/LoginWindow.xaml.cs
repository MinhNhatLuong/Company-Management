using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using BLL.Services;
using DAL.Entities;

namespace CompanyManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //Bước 1: private readonly
        private readonly AccountService _accountServices;
        //Bước 2: ctor
        public LoginWindow()
        {
            InitializeComponent();
            _accountServices = new AccountService();
        }
        //bước 3: viết hàm liên quan
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //thì lấy thông tin từ các textbox
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            //sau đó nhờ service kiểm tra có tài khoản đó không
            Account? account = _accountServices.GetAccount(email, password);
            //nếu có thì cho vào
            if (account != null)
            {
                if (account.Role != 4)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.User = account; //đưa thông tin đăng nhập cho mainWindown
                    mainWindow.Show();
                    this.Close(); //đóng cửa sổ login lại
                }
                else
                {
                    MessageBox.Show("You have no permission to access this function", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                //nếu không thì hiện thông báo
                MessageBox.Show("Invalid Email or Password", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
