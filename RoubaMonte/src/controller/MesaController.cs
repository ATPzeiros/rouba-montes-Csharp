using System.Collections.Generic;
using System;

class MesaController: BaseController
{

    private List<Jogador> jogadores = Jogador.MostrarJogadoresExistentes();

    public List<Jogador> jogadoresSelecionados = new();

    public Baralho baralho = new();

    public MesaController(Action<Menu> OnMenuSelected){
        OnMeunSelected = OnMenuSelected;
        menuStack.Push(BuildMesaOptions());
        
    }

    private static List<Menu> BuildMesaOptions() => new(){
        new("Selecionar Jogadores", true, NivelMenu.MESA_ADD_PLAYER),
        new("Iniciar jogo", NivelMenu.MESA_INIT_GAME),
        new("Sair da Mesa", NivelMenu.VOLTAR),
    };

    public override List<Menu> GetMenu() => menuStack.Peek();

    public override bool ShouldFinish() => nivelMenu == NivelMenu.VOLTAR;

    public List<Jogador> TodosJogadores() => jogadores;

    public List<Jogador> JogadoresSelecionados() => jogadoresSelecionados;

    public void GerarBaralho(int quantidade){
        baralho.GerarBaralho(quantidade);
    }

    public bool SelecionarJogador(string id){
        Jogador jogador = jogadores.Find(j => j.id == id);
        Console.WriteLine("Jogador {0} encontrado", jogador.name);
        bool verificar = VerificarJogadoresJaSelecionados(id);
        if(jogador == null){
            Console.WriteLine("Jogador não encontrado");
            Console.WriteLine("");
            return false;
        }
        if(verificar){
             jogadoresSelecionados.Add(jogador);
            return true;
        }
        else{
            return false;
        }

    }
    public bool VerificarJogadoresJaSelecionados(string id){
        foreach(Jogador a in jogadoresSelecionados){
             if(a.id == id){
                Console.WriteLine("{0} já foi selecionado", a.name);
                return false;
             }
        }
        
        return true;
    }
}
    