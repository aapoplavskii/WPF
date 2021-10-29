using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class MainViewModel : ViewModel
    {
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
            var employee = new Employee() { Name = this.Name, ZP = this.ZP };

            Employees.Add(employee);

            Name = null;
            ZP = 0;
            RaisePropertyChanged(() => Name);
            RaisePropertyChanged(() => ZP);
        }
    }
}