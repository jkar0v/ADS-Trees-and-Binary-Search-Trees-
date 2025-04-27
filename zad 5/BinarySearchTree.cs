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

        //List<TreeNode> list = new List<TreeNode>();
        //internal List<TreeNode> TransferTreeIntoList(TreeNode node)
        //{
        //    if (node != null)
        //    {
        //        TransferTreeIntoList(node.Left);
        //        list.Add(node);
        //        TransferTreeIntoList(node.Right);
        //    }
        //    return list;
        //}
        int number = -1;
        internal int FindNumber(TreeNode node, int search)
        {
            if (node != null)
            {
                if (node.Value <= search)
                {
                    number = node.Value;
                    FindNumber(node.Right, search);
                }
                else if (node.Value > search)
                {
                    FindNumber(node.Left, search);
                }
            }
            return number;
        }
    }
}
