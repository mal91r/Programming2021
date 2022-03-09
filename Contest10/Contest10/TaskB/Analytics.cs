using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal static class Analytics
{
    public static void WriteStudentsWithGpaNoLessThanAverage(List<Student> students, string pathToOutputFile,
        double gpa)
    {
        using (StreamWriter sw = new StreamWriter(pathToOutputFile))
        {
            sw.WriteLine(string.Format("{0:F2}", gpa));
            foreach (var student in students)
            {
                if ((double)((double)student.grades.Sum() / (double)student.grades.Count) >= gpa)
                {
                    sw.WriteLine(student);
                }

            }
        }
    }

    public static double FindGpa(List<Student> students)
    {
        return (double)students
            .Sum(
            x =>
                (double)((double)x.grades
                    .Sum(y => y) / (double)x.grades.Count)
            )
            / students.Count;
    }
}