using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsInfo
{
    public class Validation : Exception
    {
        public Validation(string message) : base(message) { }
        public void StudentValiadtion(List<Student> students)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Name :  ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        throw new Validation("Invalid name. Please enter a name with letters only.");
                    }

                    Console.Write("Enter Score:   ");
                    if (!double.TryParse(Console.ReadLine(), out double score) && score >= 0 && score <= 100)
                    {
                        throw new Validation("Score has to be from 0 to 100.");
                    }

                    students.Add(new Student(name, score));
                    Console.WriteLine($"Student {name} with Score {score} added successfully.\n");

                        if (students.Count >= 3)
                        {
                            Console.WriteLine("You have entered at least 3 students. Do you want to add more? (yes/no): ");
                            string response = Console.ReadLine()?.Trim().ToLower();

                            if (response == "no")
                            {
                                break;
                            }
                        }
                }

                catch (Validation ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}\n");
                }






            }
        }
    }
}

