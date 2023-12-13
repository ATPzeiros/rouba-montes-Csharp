using System.Collections.Generic;
using System;
class EstatisticaView: BaseView
{

    static EstatisticaController estatisticaController = new(OnMenuSelected);

    public EstatisticaView(){
        MostrarMenu(estatisticaController);
    }

    static void OnMenuSelected(Menu menu){
        if(menu.NextMenu == NivelMenu.ESTATISTICA_GERAL){
            Console.Clear();
            Console.WriteLine("Ranking Geral\n");

            int pos = 1;
            foreach (Jogador jogador in estatisticaController.ShowRankingGeral())
            {
                Console.WriteLine(pos + "º - " + jogador.name);
                pos++;
            }

            Console.ReadKey();
        } else if(menu.NextMenu == NivelMenu.ESTATISTICA_NOME) {
            Console.WriteLine("Informe o nome do jogador: ");
            string nome = Console.ReadLine();

            Jogador? jogador = estatisticaController.GetEstatisticaNome(nome);

            if(jogador != null){
                Console.WriteLine("O jogador " + nome + " está em " + jogador.rankingGeral + "º do ranking.");
                Console.WriteLine("Posicao da ultima partida: " + jogador.lastGamePosition);
                Console.WriteLine("Cartas da ultima partida: " + jogador.lastGameHand);

                Console.WriteLine("Ranking das ultimas 5 partidas: ");

                foreach (int pos in jogador.Ranking)
                {
                    Console.WriteLine(pos + "º colocado.");
                }
            } else {
                Console.WriteLine("Jogador não encontrado.");
            }
            
            Console.ReadKey();
        }
    }
}