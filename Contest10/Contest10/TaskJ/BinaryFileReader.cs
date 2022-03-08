using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
internal class BinaryFileReader
{
    private int sumInt16;
    private int sumInt32;
    public BinaryFileReader(string path)
    {
        using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader reader = new BinaryReader(file))
            {
                while (file.Position + 4 <= file.Length)
                {
                    sumInt32 += reader.ReadInt32();
                }            
                file.Seek(0, SeekOrigin.Begin);
                while (file.Position + 2 <= file.Length)
                {
                    sumInt16 += reader.ReadInt16();
                }
            }
        }
    }

    public int GetDifference()
    {
        return Math.Abs(sumInt32 - sumInt16);
    }
}