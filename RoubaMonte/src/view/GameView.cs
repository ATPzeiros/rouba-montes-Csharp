using System.Collections.Generic;
using System;

class GameView: BaseView
{

    GameController gameController = new();

    public GameView(List<Jogador> jogadores, Baralho baralho){
        
        gameController.AtualizarJogo(jogadores, baralho);

        do{
            Console.WriteLine("É a vez do jogador: " + gameController.JogadorDaVez().name);
            Console.ReadKey();
            gameController.PassarVez();
        }while(!gameController.FinalizarJogo());

        Console.WriteLine("Need implementation");
        Console.ReadKey();
    }
}