using System.Collections.Generic;
using System;
class EstatisticaView: BaseView
{

    EstatisticaController estatisticaController = new(OnMenuSelected);

    public EstatisticaView(){
        MostrarMenu(estatisticaController);
    }

    static void OnMenuSelected(Menu menu){
        if(menu.NextMenu == NivelMenu.ESTATISTICA_GERAL){
            Console.Clear();
            Console.WriteLine("Ranking Geral\n");
            Console.WriteLine("Esses são os jogadores existentes: \n");
            List<Jogador> jogadores= Jogador.MostrarJogadoresExistentes();
             foreach(Jogador jogador in jogadores){
            Console.WriteLine(jogador.id + " " + jogador.name);
        }
            Console.WriteLine("Entre com o ID de usuário que você quer ver o ranking \n");
            Estatistica.showPlayerRanking();
            
            Console.WriteLine(EstatisticaController.GetEstatisticaGeral());
            Console.ReadKey();
        } else if(menu.NextMenu == NivelMenu.ESTATISTICA_NOME) {
            Console.WriteLine("Nome");
            Console.ReadKey();
        }
    }
}