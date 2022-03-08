using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
internal class Program
{ 
    private static void Main(string[] args)
    {
        string path = "input.txt";
        ushort[] numberArray;
        ushort n;
        using (StreamReader sr = new StreamReader(path))
        {
            n = ushort.Parse(sr.ReadLine());
            numberArray = new ushort[n];
            for (int i = 0; i < n; i++)
            {
                numberArray[i] = ushort.Parse(sr.ReadLine());
            }
        }
        using (FileStream fs = new FileStream("output.bin", FileMode.Create))
        {
            using (BinaryWriter binwriter = new BinaryWriter(fs))
            {
                binwriter.Write(n);
                foreach (ushort i in numberArray)
                {
                    binwriter.Write(i);
                }
            }
        }
    }
}
