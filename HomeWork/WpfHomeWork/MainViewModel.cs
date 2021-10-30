using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
        internal class MainViewModel : ViewModel
        {
        Employee employee = null;
        public MainViewModel()
        {
            Employees = new ObservableCollection<Employee>();
        }

        public ICommand AddEmployeeCommand { get { return new Command(AddEmployee); } }

        public ObservableCollection<Employee> Employees { get; private set; }
        public string Name { get; set; }
        public int ZP { get; set; }

        private void AddEmployee()
        {
            //var employee = new Employee() { Name = this.Name, ZP = this.ZP };

            if (employee == null)
            {
                employee = new Employee() { Name = this.Name, ZP = this.ZP };
            }
            else
            {
                employee.Add(employee, new Employee
                {
                    Name = this.Name,
                    ZP = this.ZP
                });

            }
            
            Employees.Add(employee);

            Name = null;
            ZP = 0;
            RaisePropertyChanged(() => Name);
            RaisePropertyChanged(() => ZP);
        }

        }
}