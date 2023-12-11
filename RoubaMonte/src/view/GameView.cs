using System.Collections.Generic;
using System;
class GameView: BaseView
{
    static GameController gameController = new(OnMenuSelectec);
    public GameView(List<Jogador> jogadores, Baralho baralho){
        gameController.AtualizarJogo(jogadores, baralho);
        MostrarMenu(gameController, ShowStatus);
        gameController.FinalizarJogo();
    }
    public static void ShowStatus(int x){
        Console.WriteLine("Carta da vez: " +gameController.CartaDaVez().Numero);
        Console.WriteLine("Jogador da vez: "+gameController.JogadorDaVez().name);
        Console.WriteLine("");
        foreach(Jogador  jogador in gameController.jogadores){
            Console.WriteLine("id: "+jogador.id+ " \t Nome do jogador: "+jogador.name );
            if(jogador.monte.Count != 0){
                Console.WriteLine("Carta topo do jogador: " +jogador.monte.Peek().Numero);
            } else {
                Console.WriteLine("Monte vazio!");
            }
        }   
        Console.WriteLine("Quantidade de carta do descarte: ");
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
            Console.WriteLine("Pegar do descarte");
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