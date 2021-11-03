using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class MainViewModel : ViewModel
    {
        List<Employee> listemployee = new List<Employee>();

        
        EmployeeBinary employeebinaryitem = new EmployeeBinary();


        public MainViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            EmployeesBinary = new ObservableCollection<EmployeeBinary>();
            
        }

        public ICommand AddEmployeeCommand { get { return new Command(AddEmployee); } }
        public ICommand SortEmployeeCommand { get { return new Command(SortEmployee); } }
        public ICommand FindEmployeeCommand { get { return new Command(FindEmployee); } }

        public ObservableCollection<Employee> Employees { get; private set; }
        public ObservableCollection<EmployeeBinary> EmployeesBinary { get; private set; }
        

        public string Name { get; set; }
        public int ZP { get; set; }

       public string ResultFind { get; set; }

        private void AddEmployee()
        {

            var employee = new Employee() { Name = this.Name, ZP = this.ZP };

            listemployee.Add(employee);

            Employees.Add(employee);

            Name = null;
            ZP = 0;
            RaisePropertyChanged(() => Name);
            RaisePropertyChanged(() => ZP);
        }

        private void SortEmployee()
        {
            EmployeesBinary.Clear();

            var workemployeebinary = new WorkData();
            employeebinaryitem = null;

            foreach (var itememployee in listemployee)
            {
                employeebinaryitem = workemployeebinary.Add(itememployee.Name, itememployee.ZP);

            }

            Traverse(employeebinaryitem);

        }


        public void Traverse(EmployeeBinary node)
        {

            if (node.LeftNode != null)
            {
                Traverse(node.LeftNode);
            }

            EmployeesBinary.Add(node);

            if (node.RightNode != null)
            {

                Traverse(node.RightNode);
            }

        }

        public void FindEmployee()
        {
            var workemployeebinary = new WorkData();

            var FindEmployeeBinary = workemployeebinary.Seach(employeebinaryitem, this.ZP);


            if (FindEmployeeBinary == null)
            {

                ResultFind = "Ничего не найдено!";

            }
            else
            {

                ResultFind = FindEmployeeBinary.NameBinary;

            }
            RaisePropertyChanged("ResultFind");
        }

        


    }
}