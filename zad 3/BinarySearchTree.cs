using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace zad_4
{
    internal class BinarySearchTree
    {
        internal TreeNode Root { get; set; }
        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }
        private TreeNode InsertRecursive(TreeNode currentNode, int value)
        {
            if (currentNode == null)
                return new TreeNode(value);
            if (value < currentNode.Value)
                currentNode.Left = InsertRecursive(currentNode.Left, value);
            else if (value > currentNode.Value)
                currentNode.Right = InsertRecursive(currentNode.Right, value);
            return currentNode;
        }
    }
}
