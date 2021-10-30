using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class Employee : ViewModel
    {
        public string Name { get; set; }
        public int ZP { get; set; }

        public Employee LeftNode { get; set; }

        public Employee RightNode { get; set; }

        public override string ToString()
        {
            return Name + " - " + ZP.ToString();
        }

        public void Add(Employee currentNode, Employee addedNode)
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