using System.Collections.Generic;
using System.IO;
class Baralho
{
    Stack<string> Pilha = new Stack<string>();

    public void Ordenar(string Pilha)
    {
    }
    public Stack<string> GerarBaralho(int quantidade)
    {
        String arquivoBaralhoPadrao = System.IO.Directory.GetCurrentDirectory() + "/model/baralho.txt";
        String arquivoBaralhoJogoAtual = System.IO.Directory.GetCurrentDirectory() + "/model/baralhoPartida.txt";
        String[] baralho = File.ReadLines(arquivoBaralhoPadrao).ToArray();

        int quantidadeBaralho = 0;
        using (StreamWriter writer = new StreamWriter(arquivoBaralhoJogoAtual, append: true))
        {
            while (quantidadeBaralho != quantidade)
            {
                for (int j = 0; j < baralho.Count(); j++)
                {
                    writer.WriteLine(baralho[j]);
                }
                quantidadeBaralho++;
            }
        }
        String[] baralhoJogoAtual = File.ReadLines(arquivoBaralhoJogoAtual).ToArray();

        int count = baralhoJogoAtual.Count();
        while (count > 1)
        {
            int i = Random.Shared.Next(count--);
            (baralhoJogoAtual[i], baralhoJogoAtual[count]) = (baralhoJogoAtual[count], baralhoJogoAtual[i]);
        }

        for (int i = 0; i < baralhoJogoAtual.Count(); i++)
        {
            Pilha.Push(baralhoJogoAtual[i]);
        }

        return Pilha;
    }
}