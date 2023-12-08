using System.Collections.Generic;
using System;

class GameView: BaseView
{

    static GameController gameController = new(OnMenuSelectec);

    public GameView(List<Jogador> jogadores, Baralho baralho){
        gameController.AtualizarJogo(jogadores, baralho);
        MostrarMenu(gameController, ShowStatus);
    
        gameController.FinalizarJogo();
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
        Console.WriteLine("Carta Da Vez:" +gameController.CartaDaVez().Numero);
        Console.WriteLine("Jogador Da Vez: "+gameController.JogadorDaVez().name);
        Console.WriteLine("");
        foreach(Jogador  jogador in gameController.jogadores){
            Console.WriteLine("ID: "+jogador.id+ " \t Nome do Jogador: "+jogador.name );
            if(jogador.monte.Count != 0){
                Console.WriteLine("Topo do Jogador: " +jogador.monte.Peek().Numero);
            } else {
                Console.WriteLine("Monte vazio!");
            }
        }   
        Console.WriteLine("QUANTIDADE DO DESCARTE:");
        foreach(Carta carta in gameController.discarte.lista){
            Console.Write(carta.Numero+ ",");
            
        }
        Console.WriteLine("");
    }
    static void OnMenuSelectec(Menu menu){
        if(menu.NextMenu == NivelMenu.GAME_ROUBAR){
            Console.WriteLine("Roubar monte");
            gameController.roubarMonte(gameController.JogadorRoubado(), gameController.CartaDaVez());
            Console.ReadKey();
        }
        else if(menu.NextMenu == NivelMenu.GAME_DISCARTE){
            Console.WriteLine("Pegar do discarte");
             gameController.PegarDescarte(); 
            Console.ReadKey();         
        }
        else if(menu.NextMenu == NivelMenu.GAME_PASSAR_VEZ){
            Console.WriteLine("Passar a vez");
             gameController.PassarVez();
            Console.ReadKey();
        }
    }
}