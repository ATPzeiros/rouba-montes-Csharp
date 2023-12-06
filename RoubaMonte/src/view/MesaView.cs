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
        }
        else if (menu.NextMenu == NivelMenu.MESA_INIT_GAME)
        {
            new GameView(mesaController.jogadoresSelecionados, mesaController.baralho);
        }
    }

    static void MostrarTodosJogadores()
    {
        Console.WriteLine("Jogadores");
        foreach (Jogador jogador in mesaController.TodosJogadores())
        {
            Console.WriteLine(jogador.id);
        }

        Console.ReadKey();
    }
}