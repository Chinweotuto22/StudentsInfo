using StudentsInfo;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        Validation validation = new Validation("Your custom message here");
        Calculation calculation = new Calculation();

        validation.StudentValiadtion(students);

        calculation.Average(students);

    }
}
