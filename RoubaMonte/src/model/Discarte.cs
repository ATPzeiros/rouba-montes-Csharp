using System;
using System.Collections.Generic;
using System.ComponentModel;
class Discarte{
    List<Carta> l = new List<Carta>();
    
    //INICIALIZA O DESCARTE, COLOCANDO 6 CARTAS NA MESA/LISTA
    public List<Carta> InicializarDiscarte(Stack<Carta> x){
        for(int i = 0; i < 6; i++){
            l.Add(x.Pop());
        }
        return l;
    }
    public void PegarDescarte(Jogador jogador, Carta cartaMonte){
        for(int i = 0; i < l.Count; i++){
            if(l[i].Numero == cartaMonte.Numero){
                jogador.monte.Push(l[i]);
                l.RemoveAt(i);
            }
        }
    }
}