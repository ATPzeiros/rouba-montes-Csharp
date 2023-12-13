public class Estatistica{
    private static List<Jogador> jogadores;
    private SortedList<int, int> rankingList;

    public Estatistica(){
        rankingList = ReadRankingFromFile();
    }

    public SortedList<int, int> RankingGeral() => rankingList;

    public int RankingPorNome(string id){
        return rankingList.IndexOfKey(int.Parse(id));
    }

    public Queue<int> LastFiveGames(string id){
        Queue<int> lastMatches = new();
        string[] storedRanking = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/txt/ranking/ranking.txt");
        for (int i = 0; i < storedRanking.Length; i++)
        {
            string idUsuario = storedRanking[i].Split(",").First();

            if(id == idUsuario){
                int ranking = int.Parse(storedRanking[i].Split(",")[1]);

                if(lastMatches.Count == 5){
                    lastMatches.Dequeue();
                }

                lastMatches.Enqueue(ranking + 1);
            }
        }

        return lastMatches;
    }

    public string LastGameHand(string id){
        string[] storedHands = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/txt/jogadorlastgamehand.txt");
        for (int i = storedHands.Length - 1; i >= 0 ; i--)
        {
            if(id == storedHands[i].Split("-").First()){
                return storedHands[i].Split("-").Last();
            }
        }

        return "nao encontrado.";
    }

     public static void showPlayerRanking(){
        string id_usuario = "";
        do{
            id_usuario = Console.ReadLine();
            jogadores = Jogador.MostrarJogadoresExistentes(); 
            foreach(Jogador a in jogadores){
                if(id_usuario == a.id){
                    Console.WriteLine("Jogador: " + a.name);
                    Console.WriteLine("Ultima posição: " + a.lastGamePosition);
                    Console.WriteLine("Ultimas _05_ posições: " );
                    foreach(int rank in a.Ranking){
                        Console.WriteLine(rank);
                    }
                }
                else{
                    Console.WriteLine("");
                }
            }   
        }while(id_usuario != null);
     }

    public SortedList<int, int> ReadRankingFromFile(){

        SortedList<int, int> rankingList = new();
        string[] storedRanking = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/txt/ranking/ranking.txt");
        for (int i = 0; i < storedRanking.Length; i++)
        {
            int idUsuario = int.Parse(storedRanking[i].Split(",").First());
            int points = int.Parse(storedRanking[i].Split(",").Last());

            rankingList[idUsuario] = rankingList.GetValueOrDefault(idUsuario) + points;
        }

        return rankingList;
    }
}