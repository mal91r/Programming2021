using System;

internal class Program
{
    private const string InputPath = "input.txt";
    
    private const string OutputPath = "output.txt";

    private static void Main(string[] args)
    {
        Console.WriteLine((int)'a');
        Console.WriteLine((int)'A');
        Console.WriteLine((char)('b'-'a'+'A'));
        var mostAndLeastCommon = ReadWriter.GetMostAndLeastCommonLetters(InputPath);
        Console.WriteLine(mostAndLeastCommon);
        ReadWriter.ReplaceMostRareLetter(mostAndLeastCommon, InputPath, OutputPath);
    }
}