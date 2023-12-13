using System;
using System.IO;
using System.Collections.Generic;

class GameController: BaseController
{

    public List<Jogador> jogadores{get;set;}
    Baralho baralho;
    public Discarte discarte = new();
    string arquivoBaralhoJogoAtual = System.IO.Directory.GetCurrentDirectory() + "/src/txt/baralhoPartida.txt";
    int index = 0;

    Log log = new();

    public GameController(Action<Menu> OnMenuSelectec){
        this.OnMeunSelected = OnMenuSelectec;
        menuStack.Push(BuildGameOptions());
    }

    public void AtualizarJogo(List<Jogador> jogadores, Baralho baralho)
    {
        this.jogadores = jogadores;
        this.baralho = baralho;

        discarte.lista.Clear();
        discarte.InicializarDiscarte(baralho.Pilha);
        foreach(Jogador jogador in jogadores){
            jogador.monte.Clear();
            Carta carta = baralho.Pilha.Pop();
            jogador.monte.Push(carta);
            log.SalvarInicializacao(jogador, carta);
        }
        foreach(Jogador jogador in jogadores){
            Console.WriteLine(jogador.name + " " + jogador.monte.Peek().Numero);
        }
        Console.WriteLine(baralho.Pilha.Count);
        Console.ReadKey();
    }

    public override bool ShouldFinish()
    {
        return baralho.Pilha.Count == 0;
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
        if(baralho.Pilha.Count != 0){
            baralho.Pilha.Pop();
        }
        File.WriteAllText(arquivoBaralhoJogoAtual, string.Empty);
        RankingDaPartida();
        return baralho.Pilha.Count == 0;
    }

    public Jogador JogadorDaVez(){
        return jogadores[index % jogadores.Count];
    }

    public void PassarVez(){
        discarte.lista.Add(baralho.Pilha.Pop());
        log.SalvarArcao(JogadorDaVez(), "PASSOU A VEZ");
        index++;
    }

    public Jogador JogadorRoubado(){
        Console.WriteLine("Digite o id de quem quer roubar: ");
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
        if(jogador.monte.Count == 0){
            Console.WriteLine("Monte vazio!");
            return;
        }
        if(CartaDaVez.Numero == jogador.monte.Peek().Numero && JogadorDaVez().id != jogador.id){
            Console.WriteLine("Jogador da vez: "+JogadorDaVez().name+ "\t Jogador roubado: "+jogador.name);
            Console.WriteLine("Carta da vez: "+CartaDaVez.Numero + "\t Carta topo do monte: " +jogador.monte.Peek().Numero );
            while(jogador.monte.Count != 0){
                jogadores[index%jogadores.Count].monte.Push(jogador.monte.Pop());
            }

            log.SalvarRoubo(JogadorDaVez(), jogador);
            index++;
        }
        else{
            Console.WriteLine("Cartas não iguais para efetuar o roubo!");
        }
    }
    public Carta CartaDaVez(){
        Carta CartaDaVez = baralho.Pilha.Peek();
        return CartaDaVez;
    }
    public void PegarDescarte(){
        Carta carta = baralho.Pilha.Pop();
        discarte.PegarDescarte(JogadorDaVez(), carta);
        log.SalvarArcao(JogadorDaVez(), "Carta pega do descarte - " + carta.Numero);
        index++;
    }

     public void RankingDaPartida(){
        string name= "";
        int qtdMontes =0;

        Console.WriteLine();
        foreach(Jogador a in jogadores){
             Console.WriteLine("Jogador {0} tem {1} Cartas no seu monte",a.name,a.monte.Count());
             if(qtdMontes<a.monte.Count()){
                name = a.name;
                qtdMontes = a.monte.Count();
             }
             log.SalvarMao(a.id, a.monte);
        }

        List<Jogador> winners = jogadores.FindAll(x => x.monte.Count == jogadores.MaxBy(j => j.monte.Count)?.monte.Count);

        if(winners.Count > 1){
            Console.WriteLine("\n----Vencedores-----");
        } else if(winners.Count == 1){
            Console.WriteLine("----Vencedor-----");
        }

        foreach (Jogador jogador in winners){
            Console.WriteLine("{0} com {1} Cartas no Monte", jogador.name, jogador.monte.Count);
        }

        log.SalvarRanking(jogadores);

        Console.ReadKey();
    }

}