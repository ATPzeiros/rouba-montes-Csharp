using System;
using System.Collections.Generic;

class GameController
{

    List<Jogador> jogadores;
    Baralho baralho;
    int index = 0;

    public void AtualizarJogo(List<Jogador> jogadores, Baralho baralho)
    {
        this.jogadores = jogadores;
        this.baralho = baralho;

        Console.WriteLine(baralho.Pilha.Count);
    }

    public bool FinalizarJogo(){
        if(baralho.Pilha.Count != 0)
            baralho.Pilha.Pop();
        return baralho.Pilha.Count == 0;
    }

    public Jogador JogadorDaVez(){
        return jogadores[index % jogadores.Count];
    }

    public void PassarVez(){
        index++;
    }
}