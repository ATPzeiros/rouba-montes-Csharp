class GameView: BaseView
{

    GameController gameController = new();

    public GameView(List<Jogador> jogadores, Baralho baralho){
        gameController.AtualizarJogo(jogadores, baralho);
        Console.WriteLine("Need implementation");
        Console.ReadKey();
    }
}