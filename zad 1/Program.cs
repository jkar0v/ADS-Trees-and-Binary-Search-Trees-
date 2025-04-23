namespace zad_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            Console.WriteLine("The answer is: " + FindTreeHeight(root));
        }
        static int FindTreeHeight(TreeNode root)
        {
            if (root == null)
                return -1;

            int leftHeight = FindTreeHeight(root.Left);
            int rightHeight = FindTreeHeight(root.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
