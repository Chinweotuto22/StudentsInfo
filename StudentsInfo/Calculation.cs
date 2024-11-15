using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInfo
{
    public class Calculation
    {
        public void Average(List<Student> students)
        {
            if (students.Count > 0) // Check if the list has students
            {
                double average = students.Average(student => student.Score);
                double highest = students.Max(student => student.Score);
                double lowest = students.Min(student => student.Score);

                // Sort students by Score in descending order using LINQ
                var sortedStudents = students.OrderByDescending(student => student.Score).ToList();

                // Output results
                Console.WriteLine($"\nAverage Score: {average:F2}");
                Console.WriteLine($"Highest Score: {highest}");
                Console.WriteLine($"Lowest Score: {lowest}");

                Console.WriteLine("\nSorted Students by Score:");
                foreach (var student in sortedStudents)
                {
                    string GradeCategory = GetGradeCategory(student.Score);
                    Console.WriteLine($"{student.Name}: {student.Score} {GradeCategory}");
                }
            }
            else
            {
                Console.WriteLine("No students were entered.");
            }
        }

        private string GetGradeCategory(double score)
        {
            if (score >= 70)
                return "(A - Distinction)";
            else if (score >= 60)
                return "(B - VeryGood)";
            else if (score >= 50)
                return "(C - Good)";
            else if (score >= 40)
                return "(D - Pass)";
            else
                return "(F - Fail)";
        }

    }
}
