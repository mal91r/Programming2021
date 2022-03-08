using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

internal class ReadWriter
{
    public static (char, char) GetMostAndLeastCommonLetters(string path)
    {
        int[] alphabet = new int[26];
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadToEnd();
            string pattern = @"[^A-Za-z]";
            string target = "";
            Regex regex = new Regex(pattern);
            line = regex.Replace(line, target);
            foreach (char c in line)
            {
                if (char.IsUpper(c))
                {
                    alphabet[c - 'A']++;
                }
                else
                {
                    alphabet[c - 'a']++;
                }
            }
            return (line.ToLower().ToCharArray().FirstOrDefault(x => alphabet[x-'a'] == alphabet.Where(x => x > 0).Min()), line.ToLower().ToCharArray().FirstOrDefault(x => alphabet[x - 'a'] == alphabet.Where(x => x > 0).Max()));
        }
    }

    public static void ReplaceMostRareLetter((char, char) leastAndMostCommon, string inputPath, string outputPath)
    {
        using (StreamReader sr = new StreamReader(inputPath))
        {
            string text = sr.ReadToEnd();
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                char least, most;
                (least, most) = leastAndMostCommon;
                text = text.Replace(least, most);
                text = text.Replace((char)(least-'a'+'A'), (char)(most-'a'+'A'));
                sw.WriteLine(text);
            }
        }
    }
}