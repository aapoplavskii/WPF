using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHomeWork.Implementations
{
    class WorkData
    {
        EmployeeBinary root = null;
        List<EmployeeBinary> employeeBinaries = new List<EmployeeBinary>();

        public List<EmployeeBinary> Traverse(EmployeeBinary node)
        {

            if (node.LeftNode != null)
            {
                Traverse(node.LeftNode);
            }

            employeeBinaries.Add(node);

            if (node.RightNode != null)
            {

                Traverse(node.RightNode);
            }

            return employeeBinaries;
        }
        public EmployeeBinary Add(string name, int zp)
        {
            if (root == null)
            {
                root = new EmployeeBinary
                {
                    Name = name,
                    ZP = zp
                };

            }
            else
            {
                Add(root, new EmployeeBinary
                {
                    Name = name,
                    ZP = zp
                });

            }

            return root;
        }
        private void Add(EmployeeBinary currentNode, EmployeeBinary addedNode)
        {

            if (addedNode.ZP < currentNode.ZP)
            {
                if (currentNode.LeftNode != null)
                {
                    Add(currentNode.LeftNode, addedNode);
                }
                else
                {
                    currentNode.LeftNode = addedNode;
                }
            }
            else
            {
                if (currentNode.RightNode != null)
                {
                    Add(currentNode.RightNode, addedNode);
                }
                else
                {
                    currentNode.RightNode = addedNode;
                }
            }
        }
    }
}
