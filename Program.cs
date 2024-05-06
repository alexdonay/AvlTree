using AvlTree;

internal class Program
{
    private static void Main(string[] args)
    {
        AVLTree<int> avl = new AVLTree<int>();
        int[] data = { 10,9,1,2,4,3,5,7,11 };
        foreach (int dt in data)
        {
            avl.Add(dt);
            
        }
        
        
        Console.WriteLine(avl.ToString());
        avl.PrintTree();

    }
}