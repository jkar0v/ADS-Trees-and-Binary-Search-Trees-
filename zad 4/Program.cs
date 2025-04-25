namespace zad_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(1);
            
            List<TreeNode> list = tree.FindMinimum(tree.Root);
            Console.WriteLine(list[list.Count-1].Value);
        }
    }
}
