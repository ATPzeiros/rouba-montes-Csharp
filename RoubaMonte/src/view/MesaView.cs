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
        Console.WriteLine("Todos os jogadores Cadastrados");
        Console.WriteLine("Digite -1 para sair");
        Console.WriteLine("");
        foreach (Jogador jogador in mesaController.TodosJogadores())
        {
            Console.WriteLine(jogador.id + " " + jogador.name);
        }
    }

    static void AdicionarJogadoresAoJogo(){
        Console.WriteLine("Selecione os jogadores");
        Console.WriteLine("");
        string id;
        string verificar;
        do {
            Console.WriteLine("1- ADICIONAR JOGADOR JÁ EXISTENTE");
            Console.WriteLine("2- ADICIONAR NOVO JOGADOR");
            Console.WriteLine("-1 Para Sair");
             verificar = Console.ReadLine();
            if(verificar == "-1")
                break;
            else if(verificar == "2"){
                 Console.WriteLine("Informe o id do jogador");
                id = Console.ReadLine();
                Console.WriteLine("Informe o nome do jogador");
                string name = Console.ReadLine();
                Jogador.addPlayer(id, name);
            }
                
            else if(verificar == "1"){
                Console.WriteLine("Informe o id do jogador");
                id = Console.ReadLine();
                mesaController.SelecionarJogador(id);
            }
        }while(verificar != "-1");
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