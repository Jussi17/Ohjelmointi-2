using System;

namespace t04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            DateTime dateOfBirth;
            while (true)
            {
                Console.Write("Date of Birth (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            Console.Write("Job Title: ");
            string jobTitle = Console.ReadLine();

            DateTime jobStart;
            while (true)
            {
                Console.Write("Job Start (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out jobStart))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }

            DateTime jobEnd;
            while (true)
            {
                Console.Write("Job End (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out jobEnd))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }

            Employee employee = new Employee
            {
                JobTitle = jobTitle,
                JobStart = jobStart,
                JobEnd = jobEnd,
                Person = person
            };

            person.Print();
            employee.EmploymentLength();
        }
    }

    public struct Person
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;

        public void Print()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                age--;

            Console.WriteLine($"{FirstName} {LastName}, {age} years");
        }
    }

    public struct Employee
    {
        public string JobTitle;
        public DateTime JobStart;
        public DateTime JobEnd;
        public Person Person;

        public void EmploymentLength()
        {
            int employmentLength = JobEnd.Year - JobStart.Year;
            if (JobEnd.DayOfYear < JobStart.DayOfYear)
                employmentLength--;

            Console.WriteLine($"Employment Length: {employmentLength} years");
        }
    }
}
