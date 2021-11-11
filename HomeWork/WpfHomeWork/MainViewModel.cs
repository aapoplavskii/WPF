using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        private string _warningtext;
        public string Warningtext
        {
            get
            {
                return _warningtext;
            }

            set
            {
                _warningtext = value;
                RaisePropertyChanged(() => Warningtext);
            }
        }

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
            }
            else
            {

                Warningtext = "ВВЕДЕНЫ НЕКОРРЕКТНЫЕ ДАННЫЕ ЗАРАБОТНОЙ ПЛАТЫ!!!";

                WarningWindowShow();

                ZP = 0;

                RaisePropertyChanged(() => ZP);

                ((MainWindow)System.Windows.Application.Current.MainWindow).EnterZP.Focus();

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

                Warningtext = "НЕ ВВЕДЕНО НИ ОДНО ЗНАЧЕНИЕ!!!";

                WarningWindowShow();

                Name = null;
                ZP = 0;
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => ZP);

                ((MainWindow)System.Windows.Application.Current.MainWindow).EnterName.Focus();



            }


        }

        private async void WarningWindowShow()
        {

            WarningWindow warning = new WarningWindow();
            warning.Show();
            await Task.Delay(3000);
            warning.Close();

        }

        public void FindEmployee()
        {

            if (this.ZP)
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
            }
            else
            {


                Warningtext = "ВВЕДЕНЫ НЕКОРРЕКТНЫЕ ДАННЫЕ ДЛЯ ПОИСКА ПО ЗАРАБОТНОЙ ПЛАТЕ!!!";

                WarningWindowShow();

                ZP = 0;

                RaisePropertyChanged(() => ZP);

                ((MainWindow)System.Windows.Application.Current.MainWindow).FindZP.Focus();



            }
        }




    }
}