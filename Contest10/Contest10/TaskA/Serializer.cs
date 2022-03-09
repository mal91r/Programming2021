using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

internal static class Serializer
{
    static List<Student> students;
    public static void ReadStudents(string pathToInputFile)
    {
        students = new List<Student>();
        using (StreamReader reader = new StreamReader(pathToInputFile))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                students.Add(Parse(line));
            }
        }
    }
    private static Student Parse(string line)
    {
        string[] parts = line.Split();
        string name = parts[0];
        string lastName = parts[1];
        List<int> grades = new List<int>();
        int groupNumber = int.Parse(parts[2]);
        for (int i = 3; i < parts.Length; i++)
        {
            grades.Add(int.Parse(parts[i]));
        }
        return new Student(name, lastName, groupNumber, grades);

    }
    public static void SerializeStudents(string pathToOutputFile)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(pathToOutputFile, FileMode.Create))
        {
            binaryFormatter.Serialize(fs, students);
        }
    }
}