using System.Collections.Generic;
using System;

class MesaView : BaseView
{

    static MesaController mesaController = new(OnMenuSelected);
    public MesaView()
    {
        MostrarMenu(mesaController);
    }

    static void OnMenuSelected(Menu menu)
    {
        if (menu.NextMenu == NivelMenu.MESA_ADD_PLAYER)
        {
            MostrarTodosJogadores();
            AdicionarJogadores();
            MostrarJogadoresSelecionados();
            GerarBaralho();
        }
        else if (menu.NextMenu == NivelMenu.MESA_INIT_GAME)
        {
            new GameView(mesaController.jogadoresSelecionados, mesaController.baralho);
        }
    }

    static void MostrarTodosJogadores()
    {
        Console.WriteLine("Todos os jogadores");
        foreach (Jogador jogador in mesaController.TodosJogadores())
        {
            Console.WriteLine(jogador.id + " " + jogador.name);
        }
    }

    static void AdicionarJogadores(){
        Console.WriteLine("Selecione os jogadores");
        string id;
        do {
            Console.WriteLine("Informe o id do jogador");
            id = Console.ReadLine();
            if(id == "-1")
                break;
            mesaController.SelecionarJogador(id);
        }while(id != "-1");
    }

    static void MostrarJogadoresSelecionados(){
        Console.WriteLine("Jogadores selecionados");
        foreach (Jogador jogador in mesaController.JogadoresSelecionados())
        {
            Console.WriteLine(jogador.id + " " + jogador.name);
        }
        Console.ReadKey();
    }

    static void GerarBaralho(){
        Console.WriteLine("Informe a quantidade de baralhos:");
        int qnt = int.Parse(Console.ReadLine());
        mesaController.GerarBaralho(qnt);
    }
}