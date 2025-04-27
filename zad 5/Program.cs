using zad_4;

namespace zad_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] numbers = { 5, 3, 7, 2, 4, 6, 8 };
            foreach (int number in numbers)
            {
                tree.Insert(number);
            }
            Console.WriteLine("Enter a number to find the largest number less than or equal to it in the BST:");
            int search = int.Parse(Console.ReadLine());
            int result = tree.FindNumber(tree.Root, search);
            if (result != -1)
            {
                Console.WriteLine($"The largest number less than or equal to {search} in the BST is: {result}");
            }
            else
            {
                Console.WriteLine($"There is no number less than or equal to {search} in the BST.");
            }
        }
    }
}
