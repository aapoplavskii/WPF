using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class MainViewModel : ViewModel
    {
        List<Employee> listemployees = new List<Employee>();
        public MainViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            EmployeesBinary = new ObservableCollection<List<EmployeeBinary>>();

        }

        public ICommand AddEmployeeCommand { get { return new Command(AddEmployee); } }
        public ICommand SortEmployeeCommand { get { return new Command(SortEmployee); } }

        public ObservableCollection<Employee> Employees { get; private set; }

        public ObservableCollection<List<EmployeeBinary>> EmployeesBinary { get; private set; }
        public string Name { get; set; }
        public int ZP { get; set; }

        private void AddEmployee()
        {

            var employee = new Employee() { Name = this.Name, ZP = this.ZP };

            listemployees.Add(employee);

            Employees.Add(employee);

            Name = null;
            ZP = 0;
            RaisePropertyChanged(() => Name);
            RaisePropertyChanged(() => ZP);
        }

        private void SortEmployee()
        {
            var workemployee = new WorkData();
            EmployeeBinary employeeBinary = null;

            foreach (var itememployee in listemployees)
            {
                employeeBinary = workemployee.Add(itememployee.Name, itememployee.ZP);

            }

            var employeesbinary = workemployee.Traverse(employeeBinary);


            EmployeesBinary.Add(employeesbinary);


        }


    }
}