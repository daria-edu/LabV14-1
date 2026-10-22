using System;
using System.Text.RegularExpressions;

namespace DomainLib
{
    public class Student : Person, IDrawable
    {
        public int Course { get; set; }
        public string StudentId { get; set; }
        public double Scholarship { get; set; }

        public Student(string firstName, string lastName, string passport, int course, string studentId, double scholarship)
            : base(firstName, lastName, passport)
        {
            Course = course;
            StudentId = studentId;
            Scholarship = scholarship;
        }

        // Перевірка студентського квитка (2 літери і 8 цифр, наприклад: KB12345678)
        public bool IsStudentIdValid()
        {
            return Regex.IsMatch(StudentId, @"^[A-Z]{2}\d{8}$");
        }

        public override string GetInfo()
        {
            return $"[Студент] {base.GetInfo()}, Курс: {Course}, Квиток: {StudentId}, Стипендія: {Scholarship} грн";
        }

        // Реалізація вміння "Малювати"
        public void Draw()
        {
            Console.WriteLine($"{FirstName} {LastName} (Студент) малює графік для лабораторної.");
        }
    }
}