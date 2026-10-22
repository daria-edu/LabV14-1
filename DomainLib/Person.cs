using System;
using System.Text.RegularExpressions;

namespace DomainLib
{
    // Абстрактний клас — від нього не можна створити об'єкт напряму, тільки через нащадків
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }

        public Person(string firstName, string lastName, string passport)
        {
            FirstName = firstName;
            LastName = lastName;
            Passport = passport;
        }

        // Перевірка паспорта за допомогою регулярного виразу (2 літери і 6 цифр, наприклад: АН123456)
        public bool IsPassportValid()
        {
            return Regex.IsMatch(Passport, @"^[A-ZА-Я]{2}\d{6}$");
        }

        // Віртуальний метод для виведення інформації
        public virtual string GetInfo()
        {
            return $"{LastName} {FirstName}, Паспорт: {Passport}";
        }
    }
}