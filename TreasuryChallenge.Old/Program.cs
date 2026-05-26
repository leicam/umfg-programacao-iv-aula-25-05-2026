using System.Collections;
using System.Diagnostics;
using System.Text;

namespace TreasuryChallenge.Old;

internal class Program
{
    //Implementação mais simples do que o dicionario -> Hashtable.
    private static Hashtable _caracteresUtilizados = new Hashtable(); //loop até não repetir letra.
    private static Hashtable _codigoGerado = new Hashtable();

    static void Main(string[] args)
    {
        Console.WriteLine("Diga-me o numero de linhas que voce precisa e pressione enter.");
        var quantidadeDeCodigos = int.Parse(Console.ReadLine());
        var stopwatch = Stopwatch.StartNew();

        Write(quantidadeDeCodigos);

        stopwatch.Stop();
        Console.WriteLine(TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds));
        
        Console.ReadKey();
    }

    static string GetChar()
    {

        Random random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

        return chars[random.Next(26)].ToString();
    }

    static void Write(int quantidadeCodigoSolicitados)
    {
        using (var stream = new StreamWriter("Arquivo_teste.txt"))
        {
            for(int i = 0; i < quantidadeCodigoSolicitados; i++)
            {
                string codigo = string.Empty;
                do
                {
                    codigo = GetLine();
                } while (_codigoGerado.ContainsKey(codigo));
                
                stream.WriteLine(codigo);
            }
            _codigoGerado.Clear();
        }
        Console.WriteLine($"Foi gerado o arquivo com {quantidadeCodigoSolicitados} códigos");

        //for (int i = 0; i < l; i++)
        //{
        //    Lines.Add(GetLine() + "\n");
        //}

        //var partialLines = new List<string>();

        //foreach (var line in Lines)
        //{
        //    AllLines += line;

        //    partialLines.Add(AllLines);
        //}

        //Console.WriteLine($"Um arquivo com {partialLines.Count} linhas foi gerado.");
        //File.WriteAllText("arquivo-aleatorio.txt", AllLines);
    }

    static string GetLine(string linha = "")
    {
        // Usar recursividade 

        if (linha.Length == 7)
        {
            // Break do metodo recursivo
            _caracteresUtilizados.Clear();
            return linha;
        }

        string caracter = string.Empty;

        do
        {
            caracter = GetChar();
        }
        while (_caracteresUtilizados.ContainsKey(caracter));

        _caracteresUtilizados.Add(caracter, linha);

        return GetLine(string.Concat(linha, caracter));   


        //var c = GetChar();
        //int totalL = linha.Length;
        //int count = 0;
        //bool found = false;

        //while (totalL != count)
        //{
        //    for (int i = 0; i < totalL; i++)
        //    {
        //        if (linha[i].ToString() == c)
        //        {
        //            found = true;
        //            break;
        //        }

        //        count++;
        //    }

        //    if (found)
        //    {
        //        c = GetChar();
        //        count = 0;
        //        found = false;
        //    }
        //}
        //return GetLine(linha + c);
    }
}