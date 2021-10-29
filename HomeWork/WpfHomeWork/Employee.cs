using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class Employee: ViewModel
    {
        public string Name { get; set; }
        public int ZP { get; set; }

        public Employee LeftNode { get; set; }

        public Employee RightNode { get; set; }

        public override string ToString()
        {
            return Name + " - " + ZP.ToString();
        }
    }
}