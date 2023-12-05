using System;
using System.Collections.Generic;
class Discarte{
    Baralho B = new Baralho();
    Stack<Carta> p = new Stack<Carta>();
    List<Carta> l = new List<Carta>();
    
    //INICIALIZA O DESCARTE, COLOCANDO 6 CARTAS NA MESA/LISTA
    public List<Carta> InicializandoDiscarte(Stack<Carta> x){
        for(int i = 0; i < 6; i++){
            l.Add(x.Pop());
        }
        return l;
    }
}