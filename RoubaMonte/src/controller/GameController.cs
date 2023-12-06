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
    public Jogador JogadorRoubado(string id, string name){
        Jogador a = new Jogador(id, name);
        return a;
    }
    public Stack<Carta> roubarMonte( Jogador jogador , Carta CartaDaVez){
        if(CartaDaVez.Numero == jogador.monte.Peek().Numero){
            return jogador.monte;
        }
        else{
            Stack<Carta> a = new();
            return a;
        }
    }
    public Carta CartaDaVez(Baralho baralho){
        Carta CartaDaVez = baralho.Pilha.Pop();
        return CartaDaVez;
    }
}