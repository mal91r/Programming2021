using System;
using System.Collections.Generic;

[Serializable]
internal class Student
{
    public string name { get; }
    public string lastName { get; }
    public int groupNumber { get; }
    public List<int> grades { get; }
    public Student(string name, string lastName, int groupNumber, List<int> grades)
    {
        this.name = name;
        this.lastName = lastName;
        this.groupNumber = groupNumber;
        this.grades = grades;
    }
    public override string ToString()
    {
        return $"{name} {lastName} {groupNumber}";
    }
}