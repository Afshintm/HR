using System;

namespace HR.Api.Models
{
    public class Person: Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        public static Person CreateNew(string firstName, string lastName, Gender gender, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                throw new ApplicationException($"FirstName or lastName cannot be null or empty");
            }
            var person = new Person {FirstName = firstName,LastName = lastName,BirthDate = birthDate,Gender = gender};
            return person;

        }

        public void ApplyForJob()
        {
            
        }
    }
}