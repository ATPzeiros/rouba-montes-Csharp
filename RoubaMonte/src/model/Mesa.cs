using System;
using System.Collections.Generic;

class Mesa
{
    Baralho Baralho = new Baralho();
    Discarte Discarte = new Discarte();
    private List<Carta> discarteMesa = new List<Carta>();
    private Stack<Carta> monte = new Stack<Carta>();

    public void inicializandoMesa(){
        int x = 2;
        int pe = 0;
        monte = Baralho.GerarBaralho(x);
        discarteMesa = Discarte.InicializandoDiscarte(monte);
         Console.Write("[");
        foreach (var l in discarteMesa)
        {
            Console.Write(l.Numero+" "+l.Nipe);
        }
        Console.Write("]");
        Console.Write("[");
        foreach (var p in monte)
        {
            pe++;
            Console.Write(p.Numero+" "+p.Nipe);
        }
        Console.Write("]");
        Console.WriteLine(pe);
    }
}