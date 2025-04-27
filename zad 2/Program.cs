using zad_4;

namespace zad_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);
            List<TreeNode> treeNodes = tree.TransferTreeIntoList(tree.Root);
            List<int> list = new List<int>();
            foreach (TreeNode node in treeNodes)
            {
                list.Add(node.Value);
            }
            string input;
            Console.WriteLine("Enter a number to search for:");
            while ((input = Console.ReadLine()).ToLower() != "stop")
            {
                int search = int.Parse(input);
                if(list.Contains(search))
                    Console.WriteLine($"The BST contains {search}\n");
                else
                    Console.WriteLine("There is no such number!\n");
                    Console.WriteLine("Now, enter a number to search for: (\"Stop\" for cancel)");
            }
        }
    }
}
