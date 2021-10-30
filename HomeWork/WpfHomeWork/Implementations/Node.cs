using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class Node
    {

        public string Name { get; set; }
        public int ZP { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public override string ToString()
        {
            return Name + " - " + ZP.ToString();
        }

        

    }
}
