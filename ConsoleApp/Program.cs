namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "data.txt";

            ConsoleMenu menu = new ConsoleMenu(fileName);
            menu.Start();
        }
    }
}
