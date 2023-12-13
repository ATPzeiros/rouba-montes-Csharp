using System;
using System.Collections.Generic;

class EstatisticaController: BaseController
{

    private Estatistica estatistica = new();

    public EstatisticaController(Action<Menu> onMenuSelected){
        OnMeunSelected = onMenuSelected;
        menuStack.Push(BuildEstatisticaOptions());
    }

    private static List<Menu> BuildEstatisticaOptions() => new(){
        new("Ranking Geral", true, NivelMenu.ESTATISTICA_GERAL),
        new("Buscar Por Nome", NivelMenu.ESTATISTICA_NOME),
        new("Voltar", NivelMenu.VOLTAR),
    };

    public override List<Menu> GetMenu() => menuStack.Peek();

    public override bool ShouldFinish() => nivelMenu == NivelMenu.VOLTAR;

    public static string GetEstatisticaGeral(){
        return "1 - Eu\n2 - Voce \n3 - Ele";
    }

    public Jogador? GetEstatisticaNome(string nome) {
        List<Jogador> todosJogadores = Jogador.MostrarJogadoresExistentes();
        Jogador? jogador = todosJogadores.Find(x => x.name == nome);
        if(jogador != null){
            jogador.UpdateLastFiveRanking(estatistica.LastFiveGames(jogador?.id ?? "0"));
            jogador.rankingGeral = estatistica.RankingPorNome(jogador.id) + 1;
            jogador.lastGameHand = estatistica.LastGameHand(jogador.id);
        }

        return jogador;
    }

    public List<Jogador> ShowRankingGeral() {
        List<Jogador> jogadores = new();
        List<Jogador> todosJogadores = Jogador.MostrarJogadoresExistentes();

        foreach (KeyValuePair<int, int> ranking in estatistica.RankingGeral())
        {
            Jogador? jogador = todosJogadores.Find(j => int.Parse(j.id) == ranking.Key);

            if(jogador != null){
                jogadores.Add(jogador);
            }
        }

        return jogadores;
    }
}