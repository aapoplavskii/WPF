using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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

        private SolidColorBrush _background;
        public SolidColorBrush Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
                RaisePropertyChanged(() => Background);
            }
        }

        public bool FocusZP { get; set; }
        public bool FocusName { get; set; }
        private void AddEmployee()
        {
            if (this.ZP != 0)
            {
                var employee = new Employee() { Name = this.Name, ZP = this.ZP };


                listemployee.Add(employee);

                Employees.Add(employee);

                Name = null;
                ZP = 0;
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => ZP);

                FocusName = true;
                RaisePropertyChanged("FocusName");
            }
            else
            {
                MessageBox.Show("ВВЕДЕНЫ НЕКОРРЕКТНЫЕ ДАННЫЕ ЗАРАБОТНОЙ ПЛАТЫ!!", "Предупреждение");


                ZP = 0;

                RaisePropertyChanged(() => ZP);



                FocusName = true;
                RaisePropertyChanged("FocusName");

            }
        }

        private void SortEmployee()
        {

            if (listemployee.Count != 0)
            {

                EmployeesBinary.Clear();

                var workemployeebinary = new WorkData();
                employeebinaryitem = null;

                foreach (var itememployee in listemployee)
                {
                    employeebinaryitem = workemployeebinary.Add(itememployee.Name, itememployee.ZP);

                }

                workemployeebinary.Traverse(employeebinaryitem);

                foreach (var itememployeebinary in workemployeebinary.listemployeeBinaries)
                {

                    EmployeesBinary.Add(itememployeebinary);

                }
                

            }
            else
            {
                MessageBox.Show("НЕ ВВЕДЕНО НИ ОДНО ЗНАЧЕНИЕ!!!", "Предупреждение");

                Name = null;
                ZP = 0;
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => ZP);

                FocusName = true;
                RaisePropertyChanged("FocusName");



            }


        }


        public void FindEmployee()
        {

            if (this.ZP != 0)
            {

                var workemployeebinary = new WorkData();

                var FindEmployeeBinary = workemployeebinary.Seach(employeebinaryitem, this.ZP);


                if (FindEmployeeBinary == null)
                {

                    ResultFind = "Ничего не найдено!";

                    Background = new SolidColorBrush(Colors.Green);


                }
                else
                {

                    ResultFind = FindEmployeeBinary.NameBinary;
                    Background = new SolidColorBrush(Colors.Black);

                }
                RaisePropertyChanged("ResultFind");
                
                FocusZP = false;
                RaisePropertyChanged("FocusZP");
            }
            else
            {

                MessageBox.Show("ВВЕДЕНЫ НЕКОРРЕКТНЫЕ ДАННЫЕ ДЛЯ ПОИСКА ПО ЗАРАБОТНОЙ ПЛАТЕ!!!", "Предупреждение");

                ZP = 0;

                RaisePropertyChanged(() => ZP);

                FocusZP = true;
                RaisePropertyChanged("FocusZP");


            }
        }




    }
}