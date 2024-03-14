using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
            Name = name;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count<5)
            {
                throw new InvalidOperationException();
            }
            
            List<double> avgGrades = new List<double> { averageGrade };
            foreach (var student in Students)
            {
                avgGrades.Add(student.AverageGrade);
            }
            avgGrades = avgGrades.OrderByDescending(x => x).ToList();
            int top20students = (int)(avgGrades.Count*0.2);

            if ((avgGrades.Take(top20students).Contains(averageGrade) || ((avgGrades.Take(top20students).Last() < averageGrade))))
            { return 'A'; }
            else if (avgGrades.Skip(top20students).Take(top20students).Last() <= averageGrade && avgGrades.Skip(top20students).Take(top20students).First() >= averageGrade)
                return 'B';
            else if (avgGrades.Skip(top20students * 2).Take(top20students).Last() <= averageGrade && avgGrades.Skip(top20students * 2).Take(top20students).First() >= averageGrade)
                return 'C';
            else if (avgGrades.Skip(top20students * 3).Take(top20students).Last() <= averageGrade && avgGrades.Skip(top20students * 3).Take(top20students).First() >= averageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
            else 
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
        }
    }
    
}
