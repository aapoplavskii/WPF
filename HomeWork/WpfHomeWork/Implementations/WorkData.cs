using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHomeWork.Implementations
{
    class WorkData
    {
        EmployeeBinary root = null;

        public List<EmployeeBinary> listemployeeBinaries = new List<EmployeeBinary>();
        public void Traverse(EmployeeBinary node)
        {

            if (node.LeftNode != null)
            {
                Traverse(node.LeftNode);
            }

            listemployeeBinaries.Add(node);

            if (node.RightNode != null)
            {

                Traverse(node.RightNode);
            }

        }

        public EmployeeBinary Seach(EmployeeBinary current, int zp)
        {
            if (zp < current.ZPBinary)
            {

                if (current.LeftNode != null)
                {

                    return Seach(current.LeftNode, zp);

                }
                else
                {
                    return null;
                }

            }
            else if (zp > current.ZPBinary)
            {
                if (current.RightNode != null)
                {

                    return Seach(current.RightNode, zp);

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return current;
            }



        }

        public EmployeeBinary Add(string name, int zp)
        {
            if (root == null)
            {
                root = new EmployeeBinary
                {
                    NameBinary = name,
                    ZPBinary = zp
                };

            }
            else
            {
                Add(root, new EmployeeBinary
                {
                    NameBinary = name,
                    ZPBinary = zp
                });

            }

            return root;
        }
        private void Add(EmployeeBinary currentNode, EmployeeBinary addedNode)
        {

            if (addedNode.ZPBinary < currentNode.ZPBinary)
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
