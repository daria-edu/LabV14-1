namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вказуємо ім'я файлу для збереження даних
            string fileName = "data.txt";

            // Створюємо та запускаємо наше меню
            ConsoleMenu menu = new ConsoleMenu(fileName);
            menu.Start();
        }
    }
}
