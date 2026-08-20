using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Student_Management
{
    internal class Program
    {
        public class Student
        {
            private string name;
            private double score;
            private static int totalStudents = 0;

            public Student(string name, double score)
            {
                this.name = name;
                this.score = score;
                totalStudents++;
            }
            // TODO: write instance methods here
            public string GetName() { return name; }
            public double GetScore() { return score; }
            public bool IsPassed() { return score >= 5.0; }
            public string GetClassification()
            {
                if (score >= 8.0) return "Excellent";
                else if (score >= 6.5) return "Good";
                else if (score >= 5.0) return "Average";
                else return "Weak";
            }
            
            // TODO: write static methods here
            public static int GetTotalStudents() { return totalStudents; }
            public static Student FindTopStudent(Student[] students)
            {
                if (students == null || students.Length == 0) return null;
                Student topStudent = students[0];
                foreach (var student in students)
                {
                    if (student.score > topStudent.score)
                    {
                        topStudent = student;
                    }
                }
                return topStudent;
            }
            public static double CalculateAverageScore(Student[] students)
            {
                if (students == null || students.Length == 0) return 0.0;
                double totalScore = 0.0;
                foreach (var student in students)
                {
                    totalScore += student.score;
                }
                return totalScore / students.Length;
            }
        }

        static void Main(string[] args)
        {
            Student[] students = new Student[]
           {
                new Student("Minh", 9.0),
                new Student("Hieu", 7.5),
                new Student("Dang", 4.0),
                new Student("Huy", 6.0),
                new Student("Bao", 8.5)
           };
            Console.WriteLine($"TotalStudent: {Student.GetTotalStudents()}");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.GetName()}, Score: {student.GetScore()}, Passed: {student.IsPassed()}, Classification: {student.GetClassification()}");
            }
            Student topStudent = Student.FindTopStudent(students);
            if (topStudent != null)
            {
                Console.WriteLine($"Top Student: {topStudent.GetName()} with highest score: {topStudent.GetScore()}");
            }
            double averageScore = Student.CalculateAverageScore(students);
            Console.WriteLine($"Average Score: {averageScore}");
        }
    }
}
