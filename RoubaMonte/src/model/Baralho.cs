using System;
using System.Collections.Generic;
using System.IO;
class Baralho
{
    public Stack<Carta> Pilha = new Stack<Carta>();
    Random random = new Random();

    public void Ordenar(Stack<Carta> MaoJogador)
    {
        List<Carta> listaOrdenada = new List<Carta>();
        for (int i = 0; i < MaoJogador.Count; i++)
        {
            listaOrdenada.Add(MaoJogador.Pop());
        }
        listaOrdenada.Sort();
    }
    public Stack<Carta> GerarBaralho(int quantidade)
    {
        string arquivoBaralhoPadrao = System.IO.Directory.GetCurrentDirectory() + "/src/txt/baralho.txt";
        string arquivoBaralhoJogoAtual = System.IO.Directory.GetCurrentDirectory() + "/src/txt/baralhoPartida.txt";
        string[] baralho = File.ReadAllLines(arquivoBaralhoPadrao);
        File.WriteAllText(arquivoBaralhoJogoAtual, string.Empty);

        int quantidadeBaralho = 0;
        using (StreamWriter writer = new StreamWriter(arquivoBaralhoJogoAtual, append: true))
        {
            while (quantidadeBaralho != quantidade)
            {
                for (int j = 0; j < baralho.Length; j++)
                {
                    writer.WriteLine(baralho[j]);
                }
                quantidadeBaralho++;
            }
        }
        string[] baralhoJogoAtual = File.ReadAllLines(arquivoBaralhoJogoAtual);

        int count = baralhoJogoAtual.Length;
        while (count > 1)
        {
            int i = random.Next(count--);
            (baralhoJogoAtual[i], baralhoJogoAtual[count]) = (baralhoJogoAtual[count], baralhoJogoAtual[i]);
        }

        for (int i = 0; i < 10; i++)
        {
            string[] splited = baralhoJogoAtual[i].Split(" ");
            Pilha.Push(new Carta(int.Parse(splited[0]), int.Parse(splited[1])));
        }
        return Pilha;
    }
}