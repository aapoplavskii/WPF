using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class EmployeeBinary : ViewModel
    {

        public string NameBinary { get; set; }
        public int ZPBinary { get; set; }

        public EmployeeBinary LeftNode { get; set; }

        public EmployeeBinary RightNode { get; set; }

        public override string ToString()
        {
            return NameBinary + " - " + ZPBinary.ToString();
        }

        
    }
}
