using System;
using DomainLib;

namespace ConsoleApp
{
    public class ConsoleMenu
    {
        private readonly FileService _fileService;

        public ConsoleMenu(string fileName)
        {
            _fileService = new FileService(fileName);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n================ МЕНЮ ================");
                Console.WriteLine("1. Створити та зберегти початкові дані у файл");
                Console.WriteLine("2. Показати всі записи з файлу");
                Console.WriteLine("3. Виконати завдання Варіанту 14 (Студенти 4 курсу без стипендії)");
                Console.WriteLine("4. Демонстрація вміння малювати (IDrawable)");
                Console.WriteLine("0. Вихід");
                Console.Write("Виберіть дію: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        SeedData();
                        break;
                    case "2":
                        ShowAllData();
                        break;
                    case "3":
                        ProcessVariant14();
                        break;
                    case "4":
                        DemonstrateDrawing();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                        break;
                }
            }
        }

        // 1. Заповнення файлу тестовими даними (більше 5 осіб)
        private void SeedData()
        {
            Person[] people = new Person[]
            {
                new Student("Іван", "Петренко", "АН123456", 4, "KB12345678", 0),       // 4 курс, без стипендії
                new Student("Олена", "Коваль", "АЕ654321", 4, "KB87654321", 2000),    // 4 курс, зі стипендією
                new Student("Максим", "Шевченко", "КМ112233", 4, "KB11223344", 0),    // 4 курс, без стипендії
                new Student("Ольга", "Бойко", "ВН445566", 2, "KB55667788", 1800),     // 2 курс
                new Postman("Василь", "Сидоренко", "СВ998877", "Центральний район"),
                new Mountaineer("Тарас", "Мельник", "РР334455", 4807)
            };

            _fileService.SaveToFile(people);
            Console.WriteLine("Початкові дані успішно збережено у файл!");
        }

        // 2. Виведення всіх даних із файлу
        private void ShowAllData()
        {
            Person[] people = _fileService.ReadFromFile();

            if (people.Length == 0)
            {
                Console.WriteLine("Файл порожній або не існує. Спочатку виберіть пункт 1.");
                return;
            }

            Console.WriteLine("--- Всі записи у файлі ---");
            foreach (var person in people)
            {
                Console.WriteLine(person.GetInfo());
            }
        }

        // 3. Завдання Варіанту 14
        private void ProcessVariant14()
        {
            Person[] people = _fileService.ReadFromFile();
            int count = 0;

            Console.WriteLine("--- Студенти 4-го курсу, які НЕ отримують стипендію ---");

            foreach (var person in people)
            {
                // Перевіряємо, чи це студент
                if (person is Student student)
                {
                    // Перевіряємо умови варіанту 14
                    if (student.Course == 4 && student.Scholarship == 0)
                    {
                        Console.WriteLine(student.GetInfo());
                        count++;
                    }
                }
            }

            Console.WriteLine($"\nЗагальна кількість таких студентів: {count}");
        }

        // 4. Демонстрація поліморфізму та інтерфейсу IDrawable
        private void DemonstrateDrawing()
        {
            Person[] people = _fileService.ReadFromFile();

            Console.WriteLine("--- Демонстрація малювання ---");
            foreach (var person in people)
            {
                if (person is IDrawable drawable)
                {
                    drawable.Draw();
                }
            }
        }
    }
}