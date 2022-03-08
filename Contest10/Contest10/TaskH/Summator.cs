using System;
using System.IO;
using System.Linq;
using System.Text;


internal class Summator
{

    public Summator(string path)
    {
        using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
        {
            #nullable enable
            string? line = null;
            while ((line = sr.ReadLine()) != null)
            {
                Sum += line.Trim().Split('_').Select(x => int.Parse(x)).Sum();
            }
        }
    }

    public int Sum { get; }
}