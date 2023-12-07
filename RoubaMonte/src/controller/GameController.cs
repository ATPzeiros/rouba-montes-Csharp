using System;
using System.IO;
using System.Collections.Generic;

class GameController: BaseController
{

    List<Jogador> jogadores;
    Baralho baralho;
    Discarte discarte = new();
    string arquivoBaralhoJogoAtual = System.IO.Directory.GetCurrentDirectory() + "/src/txt/baralhoPartida.txt";
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

        Console.WriteLine(baralho.Pilha.Count);
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
        if(baralho.Pilha.Count != 0){
            baralho.Pilha.Pop();
        }
        File.WriteAllText(arquivoBaralhoJogoAtual, string.Empty);
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
    public Carta CartaDaVez(){
        Carta CartaDaVez = baralho.Pilha.Peek();
        return CartaDaVez;
    }
    public void PegarDescarte(){
        discarte.PegarDescarte(JogadorDaVez(), baralho.Pilha.Pop());
    }

}