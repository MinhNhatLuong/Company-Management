using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Services;
using DAL.Entities;

namespace CompanyManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeeService _employeeService;
        public MainWindow()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            //If we have comments in Datagrid, we can use these command
            //dgEmployees.Items.Clear();
            dgEmployees.ItemsSource = null;
            dgEmployees.ItemsSource = _employeeService.GetEmployees();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearch.Text;
            dgEmployees.ItemsSource = _employeeService.GetEmployeesBySearch(searchText);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Delete Employee
            //Check the row we choose is a employee or not
            //If it is, then assign employee into variable
            if (dgEmployees.SelectedItem is Employee employee) //is: pattern matching
            {
                //Alert before delete
                MessageBoxResult result = MessageBox.Show("Bạn muốn xóa không?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _employeeService.DeleteAEmployee(employee);
                }
            }
            LoadEmployees();
        }
    }
}