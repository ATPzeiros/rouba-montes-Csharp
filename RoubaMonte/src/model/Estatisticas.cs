class Estatistica{
    private static List<Jogador> jogadores;
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
                    foreach(string rank in a.Ranking){
                        Console.WriteLine(rank);
                    }
                }
                else{
                    Console.WriteLine("");
                }
            }   
        }while(id_usuario != null);
        
        
     }

}