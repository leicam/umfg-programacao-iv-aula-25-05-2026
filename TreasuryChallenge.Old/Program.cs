using System.Diagnostics;

namespace TreasuryChallenge.Old;

internal class Program
{
    static List<string> Lines;
    static string AllLines = string.Empty;

    static void Main(string[] args)
    {
        Console.WriteLine("Diga-me o numero de linhas que voce precisa e pressionne enter.");

        Lines = new List<string>();

        int l = int.Parse(Console.ReadLine());

        var t = Stopwatch.StartNew();

        Write(l);

        t.Stop();

        Console.WriteLine(t.ElapsedMilliseconds);
        Console.ReadKey();
    }

    static string GetChar()
    {
        Random random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

        return chars[random.Next(25)].ToString();
    }

    static void Write(int l)
    {
        for (int i = 0; i < l; i++)
        {
            Lines.Add(GetLine() + "\n");
        }

        var partialLines = new List<string>();

        foreach (var line in Lines)
        {
            AllLines += line;

            partialLines.Add(AllLines);
        }

        Console.WriteLine($"Um arquivo com {partialLines.Count} linhas foi gerado.");
        File.WriteAllText("arquivo-aleatorio.txt", AllLines);
    }

    static string GetLine(string l = "")
    {
        if (l.Length == 7) return l;

        var c = GetChar();
        int totalL = l.Length;
        int count = 0;
        bool found = false;

        while (totalL != count)
        {
            for (int i = 0; i < totalL; i++)
            {
                if (l[i].ToString() == c)
                {
                    found = true;
                    break;
                }

                count++;
            }

            if (found)
            {
                c = GetChar();
                count = 0;
                found = false;
            }
        }

        return GetLine(l + c);
    }
}