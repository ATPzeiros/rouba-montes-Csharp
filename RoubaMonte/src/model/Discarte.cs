using System;
using System.Collections.Generic;
using System.ComponentModel;
class Discarte{
    public List<Carta> lista = new List<Carta>() ;
    
    //INICIALIZA O DESCARTE, COLOCANDO 6 CARTAS NA MESA/LISTA
    public List<Carta> InicializarDiscarte(Stack<Carta> x){
        for(int i = 0; i < 6; i++){
            lista.Add(x.Pop());
        }
        return lista;
    }
    public void PegarDescarte(Jogador jogador, Carta cartaMonte){
        for(int i = 0; i < lista.Count; i++){
            if(lista[i].Numero == cartaMonte.Numero){
                jogador.monte.Push(lista[i]);
                lista.RemoveAt(i);
            }
        }
    }
}