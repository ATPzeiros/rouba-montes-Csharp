using System;
using System.Collections.Generic;

class Mesa
{   
    Baralho Baralho = new Baralho();
    Discarte Discarte = new Discarte();
    private List<Carta> discarteMesa = new List<Carta>();//DISCARTE DA MESA
    private Stack<Carta> monte = new Stack<Carta>();//MONTE(BARALHO) DA MESA

    public void inicializandoMesa(int x){
        monte = Baralho.GerarBaralho(x);//GERANDO O MONTE(BARALHO)
        discarteMesa = Discarte.InicializarDiscarte(monte);//GERANDO O DISCARTE DA MESA
        foreach (var item in discarteMesa)
        {
            Console.WriteLine(item.Nipe+" "+item.Numero);
        }
    } 
}