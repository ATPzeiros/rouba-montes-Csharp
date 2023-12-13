using System.Collections.Generic;
using System;
using System.Media;
class GameView: BaseView
{
    static GameController gameController = new(OnMenuSelectec);
    public GameView(List<Jogador> jogadores, Baralho baralho){
        gameController.AtualizarJogo(jogadores, baralho);
        MostrarMenu(gameController, ShowStatus);
        gameController.FinalizarJogo();
        SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory()+"/sounds/ta-dah-notification.wav");
        player.Play(); 
        
        foreach (Jogador jogador in gameController.jogadores)
        {
            Console.WriteLine("Jogador: " + jogador.name);
            Console.WriteLine("Cartas Ordenadas: ");
            foreach (int numeroCarta in jogador.OrdenarMao())
            {
                Console.Write(numeroCarta + ",");
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }
    public static void ShowStatus(int x){
        Console.WriteLine(" ");
        Console.WriteLine("----------------=----------------");
        Console.WriteLine("Carta da vez: ["+gameController.CartaDaVez().Numero+"]");
        Console.WriteLine("Jogador da vez: ["+gameController.JogadorDaVez().name+"]");
        Console.WriteLine("----------------=----------------");
        foreach(Jogador  jogador in gameController.jogadores){
            Console.WriteLine(" ");
            Console.WriteLine("|id: "+jogador.id+" - Nome do jogador: "+jogador.name );
            if(jogador.monte.Count != 0){
                Console.WriteLine("|Carta topo do jogador: ( " +jogador.monte.Peek().Numero+" )\n");
            } else {
                Console.WriteLine("Monte vazio!");
            }
        }
        Console.Write("Quantidade de carta do descarte: ");
        Console.Write("[ ");
        foreach(Carta carta in gameController.discarte.lista){
            Console.Write(carta.Numero+ " ");  
        }
        Console.WriteLine("]");
        Console.WriteLine("");
    }
    static void OnMenuSelectec(Menu menu){
        if(menu.NextMenu == NivelMenu.GAME_ROUBAR){
            Console.WriteLine("Roubar monte");
            gameController.roubarMonte(gameController.JogadorRoubado(), gameController.CartaDaVez());
            SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory()+"/sounds/among.wav");
            player.Play();
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