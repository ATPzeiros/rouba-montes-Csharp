using System.Collections.Generic;
using System;

class GameView: BaseView
{

    static GameController gameController = new(OnMenuSelectec);

    public GameView(List<Jogador> jogadores, Baralho baralho){
        gameController.AtualizarJogo(jogadores, baralho);
        MostrarMenu(gameController, ShowStatus);
        Console.ReadKey();
        // gameController.AtualizarJogo(jogadores, baralho);

        // do{
        //     Console.WriteLine("É a vez do jogador: " + gameController.JogadorDaVez().name);
        //     Console.WriteLine("Qual ação você Tomará? ");
        //     Console.WriteLine("2 - Passar vez");
        //     Console.WriteLine("");
        //     Console.WriteLine("");
        //     Console.ReadKey();
        //     gameController.roubarMonte(gameController.JogadorRoubado(gameController.JogadorDaVez().id, gameController.JogadorDaVez().name),gameController.CartaDaVez(baralho));
        //     gameController.PassarVez();

        // }while(!gameController.FinalizarJogo());

        // Console.WriteLine("Need implementation");
        // Console.ReadKey();
    }
    public static void ShowStatus(int x){
        Console.WriteLine(gameController.JogadorDaVez().name);
        Console.WriteLine(gameController.CartaDaVez().Numero);
        }
    static void OnMenuSelectec(Menu menu){
        if(menu.NextMenu == NivelMenu.GAME_ROUBAR){
            Console.WriteLine("Roubar monte");
            // gameController.roubarMonte(gameController.JogadorDaVez(), gameController.CartaDaVez());
            Console.ReadKey();
        }
        else if(menu.NextMenu == NivelMenu.GAME_DISCARTE){
            Console.WriteLine("Pegar do discarte");
            // gameController.PegarDescarte(); 
            Console.ReadKey();         
        }
        else if(menu.NextMenu == NivelMenu.GAME_PASSAR_VEZ){
            Console.WriteLine("Passar a vez");
            // gameController.PassarVez();
            Console.ReadKey();
        }
    }
}