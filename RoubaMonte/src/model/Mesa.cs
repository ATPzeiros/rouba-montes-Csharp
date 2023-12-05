using System;
using System.Collections.Generic;

class Mesa
{
    Baralho Baralho = new Baralho();
    Discarte Discarte = new Discarte();
    private List<Carta> discarteMesa = new List<Carta>();
    private Stack<Carta> monte = new Stack<Carta>();

    public void inicializandoMesa(int x){
        monte = Baralho.GerarBaralho(x);
        discarteMesa = Discarte.InicializandoDiscarte(monte);
    }
}