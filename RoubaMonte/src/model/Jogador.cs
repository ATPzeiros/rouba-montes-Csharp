using System;
using System.IO;
using System.Collections.Generic;

class Jogador {
    public string id {get;set;}
    public string name {get;set;}
    public Stack<Carta> monte {get;set;}
    // private string lastGamePosition;
    // private string lastGameHand;
    // private Queue<string> Ranking;


    public static string [] GetPlayersToMatriz(){
        string [] jogadores = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/txt/jogador.txt");
        return jogadores;
    }

    public Jogador(string id, string name){
        this.id = id;
        this.name = name;
        this.monte = new Stack<Carta> ();
    }
    
    //Funtion to Show Players that already played once
    public static List<Jogador> MostrarJogadoresExistentes(){
        string [] players = GetPlayersToMatriz();
        List<Jogador> jogadores = new();
        for(int i=0; i<players.Length;i++){
            string  sub = players[i];
            string [] playerIdName = sub.Split(',');
            jogadores.Add(new Jogador(playerIdName[0], playerIdName[1]));
        }

        return jogadores;
    }


    
    public static void addPlayer(string id, string name){
        string filePath = Directory.GetCurrentDirectory() + "/src/model/jogador.txt";
        try{
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                string data = $"{id},{name}";
                writer.WriteLine(data);
               
            }
        }
        catch (Exception e){
            Console.WriteLine(e);
           
        }
    }   

    public int[] OrdenarMao(){
        if(monte.Count != 0){
            int[] cartas =  monte.Select(carta => carta.Numero).ToArray();
            return CountingSort(cartas);
        } else {
            return Array.Empty<int>();
        }
    }

    public int GetMaxVal(int[] array, int size)
{
    var maxVal = array[0];
    for (int i = 1; i < size; i++)
        if (array[i] > maxVal)
            maxVal = array[i];
    return maxVal;
}

public int[] CountingSort(int[] array)
{
    var size = array.Length;
    var maxElement = GetMaxVal(array, size);
    var occurrences = new int[maxElement + 1];
    for (int i = 0; i < maxElement + 1; i++)
    {
        occurrences[i] = 0;
    }
    for (int i = 0; i < size; i++)
    {
        occurrences[array[i]]++;
    }
    for (int i = 0, j = 0; i <= maxElement; i++)
    {
        while (occurrences[i] > 0)
        {
            array[j] = i;
            j++;
            occurrences[i]--;
        }
    }
    return array;
}
}