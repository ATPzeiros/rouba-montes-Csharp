﻿using System;

namespace RoubaMonte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new MenuView().MostrarMenu();
            Baralho B = new Baralho();
            var pilha = B.GerarBaralho(2);

            foreach (var p in pilha)
            {
                Console.WriteLine(p.Numero+" "+p.Nipe);
            }
        }
    }
}