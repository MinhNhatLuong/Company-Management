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
        private readonly DepartmentService _departmentService;
        public Account User { get; set; } //lưu thông tin đăng nhập

        public MainWindow()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            LoadEmployees();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            cbDepartment.ItemsSource = _departmentService.GetDepartments();
            cbDepartment.DisplayMemberPath = "Name";
            cbDepartment.SelectedValuePath = "Id";
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (User.Role == 2) //manager
            {
                btnDelete.IsEnabled = false;
            }
            if (User.Role == 2) //staff
            {
                btnDelete.IsEnabled = false;
                btnCreate.IsEnabled = false;
                btnUpdate.IsEnabled = false;
            }
        }

        private void dgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //sự kiện này sẽ gọi khi double click vào data grid
            //kiểm tra dòng đang click có phải employee không
            if (dgEmployees.SelectedItem is Employee employee)
            {
                txtName.Text = employee.Name;
                txtAdress.Text = employee.Address;
                txtAge.Text =  employee.Age.ToString();
                cbDepartment.SelectedValue = employee.DepartmentId;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Chỉ cần thêm được, new một employee từ các text box, combobox
            Employee employee = new Employee()
            {
                Name = txtName.Text,
                Address = txtAdress.Text,
                Age = int.Parse(txtAge.Text),
                DepartmentId = (int)cbDepartment.SelectedValue
            };
            _employeeService.AddAnEmployee(employee);
            LoadEmployees();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //update theo id -> lấy theo id
            //lấy thông tin từ các textbox, combo box
            Employee employee = new Employee()
            {
                Id = ((Employee)dgEmployees.SelectedItem).Id,
                Name = txtName.Text,
                Address = txtAdress.Text,
                Age = int.Parse(txtAge.Text),
                DepartmentId = (int)cbDepartment.SelectedValue
            };
            _employeeService.UpdateAnEmployee(employee);
            LoadEmployees();
        }
    }
}