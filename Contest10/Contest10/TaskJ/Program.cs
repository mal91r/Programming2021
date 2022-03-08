using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arCircuit = {1, 2, 3 }; 
        using (FileStream fs = new FileStream("input.bin", FileMode.Create))
        {
            BinaryWriter bw = new BinaryWriter(fs);
            foreach (int i in arCircuit)
            {
                bw.Write(i);
            }
        }
           // Выполнение сериализациимассива объектов: binformatter.Serialize(fs, arCircuit);}
        var bfr = new BinaryFileReader("input.bin");
        Console.WriteLine(bfr.GetDifference());
    }
}