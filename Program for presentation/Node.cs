using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_for_presentation
{
    enum Color { RED, BLACK }
    internal class Node
    {
        public int data;
        public Color color;
        public Node left, right, parent;

        public Node(int data)
        {
            this.data = data;
            this.color = Color.RED;
            left = right = parent = null;
        }
    }
}
