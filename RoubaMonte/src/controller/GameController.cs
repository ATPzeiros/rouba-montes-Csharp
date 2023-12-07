using System;
using System.Collections.Generic;

class GameController: BaseController
{

    public List<Jogador> jogadores{get;set;}
    Baralho baralho;
    public Discarte discarte = new();
    int index = 0;
    public GameController(Action<Menu> OnMenuSelectec){
        this.OnMeunSelected = OnMenuSelectec;
        menuStack.Push(BuildGameOptions());
    }

    public void AtualizarJogo(List<Jogador> jogadores, Baralho baralho)
    {
        this.jogadores = jogadores;
        this.baralho = baralho;
        discarte.InicializarDiscarte(baralho.Pilha);
        foreach(Jogador jogador in jogadores){
            jogador.monte.Push(baralho.Pilha.Pop());
        }
        foreach(Jogador jogador in jogadores){
            Console.WriteLine(jogador.name + " " + jogador.monte.Peek().Numero);
        }
        Console.WriteLine(baralho.Pilha.Count);
        Console.ReadKey();
    }

    public override bool ShouldFinish()
    {
        return nivelMenu == NivelMenu.VOLTAR;
    }
    public override List<Menu> GetMenu()
    {
        return menuStack.Peek();
    }
    private static List<Menu> BuildGameOptions() => new(){
        new("Roubar o monte", true, NivelMenu.GAME_ROUBAR),
        new("Pegar do dicarte", NivelMenu.GAME_DISCARTE),
        new("Passar a vez", NivelMenu.GAME_PASSAR_VEZ),
        new("Voltar", NivelMenu.VOLTAR),
    };

    public bool FinalizarJogo(){
        if(baralho.Pilha.Count != 0)
            baralho.Pilha.Pop();
        return baralho.Pilha.Count == 0;
    }

    public Jogador JogadorDaVez(){
        return jogadores[index % jogadores.Count];
    }

    public void PassarVez(){
        discarte.lista.Add(baralho.Pilha.Pop());
        index++;
    }
    public Jogador JogadorRoubado(){
        Console.WriteLine("Digite o ID de quem você quer Roubar o Monte: ");
        string seFufu = Console.ReadLine();
        foreach(Jogador jogador in jogadores){
            if(seFufu == jogador.id){
            Console.WriteLine(jogador.name);
            return jogador;
            }   
        }
        Jogador a = new(seFufu, seFufu);
        return a;
    }
    public void roubarMonte( Jogador jogador , Carta CartaDaVez){
        if(CartaDaVez.Numero == jogador.monte.Peek().Numero){
            Console.WriteLine("jogador Atual: "+JogadorDaVez().name+ "\t jogador Roubado: "+jogador.name);
            Console.WriteLine("Carta Da Vez:"+CartaDaVez.Numero + "\t Topo do Jogador: " +jogador.monte.Peek().Numero );
            while(jogador.monte.Count != 0){
                jogadores[index%jogadores.Count].monte.Push(jogador.monte.Pop());
            }
        }
        else{
            Console.WriteLine("As Cartas Não são Iguais para roubar o monte!!!!!");
        }
    }
    public Carta CartaDaVez(){
        Carta CartaDaVez = baralho.Pilha.Peek();
        return CartaDaVez;
    }
    public void PegarDescarte(){
        discarte.PegarDescarte(JogadorDaVez(), baralho.Pilha.Pop());
    }

}