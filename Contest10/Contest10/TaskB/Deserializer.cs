using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

internal static class Deserializer
{
    public static BinaryFormatter BinaryFormatterbinformatter { get; private set; }

    public static List<Student> DeserializeStudents(string pathToFile)
    {
        BinaryFormatter binformatter = new BinaryFormatter();
        List<Student> students = null;
        using (FileStream file = new FileStream(pathToFile, FileMode.Open))
        {
            students = (List<Student>)binformatter.Deserialize(file);
        }
        return students;
    }
}