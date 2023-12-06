using System.Collections.Generic;
using System;

class GameView: BaseView
{

    GameController gameController = new();

    public GameView(List<Jogador> jogadores, Baralho baralho){
        
        gameController.AtualizarJogo(jogadores, baralho);

        do{
            Console.WriteLine("É a vez do jogador: " + gameController.JogadorDaVez().name);
            Console.WriteLine("Qual ação você Tomará? ");
            Console.ReadKey();
            gameController.roubarMonte(gameController.JogadorRoubado(gameController.JogadorDaVez().id, gameController.JogadorDaVez().name),gameController.CartaDaVez(baralho));
            gameController.PassarVez();

        }while(!gameController.FinalizarJogo());

        Console.WriteLine("Need implementation");
        Console.ReadKey();
    }
}