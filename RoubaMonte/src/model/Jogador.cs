using System;
using System.IO;
using System.Collections.Generic;

class Jogador {
    private string id;
    private string name;
    private string lastGamePosition;
    private string lastGameHand;
    private Queue<string> Ranking;


    public string [] GetPlayersToMatriz(){
        String [] jogadores = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/model/jogador.txt");
        return jogadores;
    }
    public Jogador(){
        string [] players = GetPlayersToMatriz();
        for(int i =0; i< players.Length;i++){
            id = (players.Length).ToString();
            Console.WriteLine(id);
        }
        
    }
    
    public void SavePlayersInTxt(string [] players){

    }
}