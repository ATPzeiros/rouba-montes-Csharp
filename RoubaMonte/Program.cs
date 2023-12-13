using System;
using System.ComponentModel.DataAnnotations;
using System.Media;
namespace RoubaMonte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Jogador jogador = new Jogador();
            // jogador.MostrarJogadoresExistentes();
            /*  new MenuView().MostrarMenu();
            Baralho B = new Baralho();
            var pilha = B.GerarBaralho(2);

            foreach (var p in pilha)
            {
                Console.WriteLine(p.Numero+" "+p.Nipe);
            } */
            SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory()+"/sounds/inicio-windows.wav");
            player.Play(); 
            new InicioView();
            player = new SoundPlayer(Directory.GetCurrentDirectory()+"/sounds/preview_4.wav");
            player.PlaySync(); 
        }
    }
}