using System;
using System.Text.RegularExpressions;

namespace DomainLib
{
    
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

        
        public bool IsPassportValid()
        {
            return Regex.IsMatch(Passport, @"^[A-ZА-Я]{2}\d{6}$");
        }

        
        public virtual string GetInfo()
        {
            return $"{LastName} {FirstName}, Паспорт: {Passport}";
        }
    }
}