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
            AdicionarJogadoresAoJogo();
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
        Console.WriteLine("");
        Console.WriteLine("---Jogadores já cadastrados---");
        // Console.WriteLine("Digite -1 para sair");
        foreach (Jogador jogador in mesaController.TodosJogadores())
        {
            Console.WriteLine("   [id: "+jogador.id + " - Nome: " + jogador.name+"]");
        }
    }

    static void AdicionarJogadoresAoJogo(){
        Console.WriteLine(" ");
        Console.WriteLine("---Selecione os jogadores---");
        string id;
        string verificar;
        do {
            Console.WriteLine("1 - Selecionar jogador existente");
            Console.WriteLine("2 - Novo jogador");
            Console.WriteLine("0 - Sair");
             verificar = Console.ReadLine();
            if(verificar == "0")
                break;
            else if(verificar == "2"){
                 Console.Write("Id jogador: ");
                id = Console.ReadLine();
                Console.Write("Nome do jogador: ");
                string name = Console.ReadLine();
                Jogador.addPlayer(id, name);
                mesaController.lerJogadores();
            }
                
            else if(verificar == "1"){
                Console.Write("Id do jogador: ");
                id = Console.ReadLine();
                mesaController.SelecionarJogador(id);
            }
        }while(verificar != "-1");
    }

    static void MostrarJogadoresSelecionados(){
        Console.WriteLine("Jogadores selecionados");
        foreach (Jogador jogador in mesaController.JogadoresSelecionados())
        {
            Console.WriteLine("\t"+jogador.id + " " + jogador.name);
        }
        Console.ReadKey();
    }

    static void GerarBaralho(){
        Console.WriteLine("Com quantos baralhos quer jogar: ");
        int qnt = int.Parse(Console.ReadLine());
        mesaController.GerarBaralho(qnt);
    }
}