using System;
using System.IO;
using System.Text;

namespace DomainLib
{
    public class FileService
    {
        private readonly string _fileName;

        public FileService(string fileName)
        {
            _fileName = fileName;
        }

        // 1. Запис масиву людей у файл (Потоковий запис)
        public void SaveToFile(Person[] people)
        {
            using (StreamWriter writer = new StreamWriter(_fileName, false, Encoding.UTF8))
            {
                foreach (var person in people)
                {
                    if (person is Student s)
                    {
                        writer.WriteLine($"Student {s.FirstName}{s.LastName}");
                        writer.WriteLine("{");
                        writer.WriteLine($"  \"firstname\": \"{s.FirstName}\",");
                        writer.WriteLine($"  \"lastname\": \"{s.LastName}\",");
                        writer.WriteLine($"  \"passport\": \"{s.Passport}\",");
                        writer.WriteLine($"  \"studentId\": \"{s.StudentId}\",");
                        writer.WriteLine($"  \"course\": \"{s.Course}\",");
                        writer.WriteLine($"  \"scholarship\": \"{s.Scholarship}\"");
                        writer.WriteLine("};");
                    }
                    else if (person is Postman p)
                    {
                        writer.WriteLine($"Postman {p.FirstName}{p.LastName}");
                        writer.WriteLine("{");
                        writer.WriteLine($"  \"firstname\": \"{p.FirstName}\",");
                        writer.WriteLine($"  \"lastname\": \"{p.LastName}\",");
                        writer.WriteLine($"  \"passport\": \"{p.Passport}\",");
                        writer.WriteLine($"  \"deliveryZone\": \"{p.DeliveryZone}\"");
                        writer.WriteLine("};");
                    }
                    else if (person is Mountaineer m)
                    {
                        writer.WriteLine($"Mountaineer {m.FirstName}{m.LastName}");
                        writer.WriteLine("{");
                        writer.WriteLine($"  \"firstname\": \"{m.FirstName}\",");
                        writer.WriteLine($"  \"lastname\": \"{m.LastName}\",");
                        writer.WriteLine($"  \"passport\": \"{m.Passport}\",");
                        writer.WriteLine($"  \"highestPeak\": \"{m.HighestPeak}\"");
                        writer.WriteLine("};");
                    }
                }
            }
        }

        // 2. Читання з файла (Потокове читання без використання List<T>)
        public Person[] ReadFromFile()
        {
            if (!File.Exists(_fileName))
                return new Person[0];

            // Масив із запасом (оскільки стандартні колекції використовувати заборонено)
            Person[] temp = new Person[100];
            int count = 0;

            using (StreamReader reader = new StreamReader(_fileName, Encoding.UTF8))
            {
                string line;
                string currentType = "";

                string fn = "", ln = "", pass = "", stId = "", zone = "";
                int course = 0, peak = 0;
                double scholarship = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.StartsWith("Student ")) currentType = "Student";
                    else if (line.StartsWith("Postman ")) currentType = "Postman";
                    else if (line.StartsWith("Mountaineer ")) currentType = "Mountaineer";
                    else if (line.Contains(":"))
                    {
                        var parts = line.Split(':');
                        string key = parts[0].Replace("\"", "").Trim();
                        string val = parts[1].Replace("\"", "").Replace(",", "").Trim();

                        switch (key)
                        {
                            case "firstname": fn = val; break;
                            case "lastname": ln = val; break;
                            case "passport": pass = val; break;
                            case "studentId": stId = val; break;
                            case "course": int.TryParse(val, out course); break;
                            case "scholarship": double.TryParse(val, out scholarship); break;
                            case "deliveryZone": zone = val; break;
                            case "highestPeak": int.TryParse(val, out peak); break;
                        }
                    }
                    else if (line.StartsWith("};"))
                    {
                        // Створюємо відповідний об'єкт і додаємо в масив
                        if (currentType == "Student")
                            temp[count++] = new Student(fn, ln, pass, course, stId, scholarship);
                        else if (currentType == "Postman")
                            temp[count++] = new Postman(fn, ln, pass, zone);
                        else if (currentType == "Mountaineer")
                            temp[count++] = new Mountaineer(fn, ln, pass, peak);

                        currentType = "";
                    }
                }
            }

            // Обрізаємо масив до фактичної кількості елементів
            Person[] result = new Person[count];
            Array.Copy(temp, result, count);
            return result;
        }
    }
}