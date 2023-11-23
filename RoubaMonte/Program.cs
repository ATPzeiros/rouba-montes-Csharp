using System;

namespace RoubaMonte // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carta carta = new Carta();
            carta.Numero = 1;

            Console.WriteLine(carta.Numero);
        }
    }
}