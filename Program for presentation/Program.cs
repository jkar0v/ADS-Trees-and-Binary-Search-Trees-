namespace Program_for_presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree rbt = new RedBlackTree();

            // Пример 1: Добавяне и търсене
            rbt.Insert(10);
            rbt.Insert(20);
            rbt.Insert(15);
            rbt.Insert(5);
            rbt.PrintInOrder(); // Изход: 5 10 15 20

            Node found = rbt.SearchTree(15);
            Console.WriteLine(found != null ? $"Намерено: {found.data}" : "Не е намерено");

            // Пример 2: Изтриване
            rbt.DeleteNode(10);
            rbt.PrintInOrder(); // Изход: 5 15 20
        }
    }
}
