using System;
using System.IO;
using System.Collections.Generic;

class Jogador {
    public string id {get;set;}
    private string name;
    private string lastGamePosition;
    private string lastGameHand;
    private Queue<string> Ranking;


    public string [] GetPlayersToMatriz(){
        string [] jogadores = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/model/jogador.txt");
        return jogadores;
    }
    
    //Function to init new Player on table
    public Jogador(){
        string [] players = GetPlayersToMatriz();
        id = players.Length.ToString();
        Console.WriteLine("Digite o nome do Jogador");
        name = Console.ReadLine();
    }
    
    //Funtion to Show Players that already played once
    public void  MostrarJogadoresExistentes(){
        string [] players = GetPlayersToMatriz();
        for(int i=0; i<players.Length;i++){
            string  sub = players[i];
            string [] playerIdName = sub.Split(',');
            Console.Write("Player ID: {0}",playerIdName[0]);
            Console.Write("   ");
            Console.Write("Player NAME: {0}", playerIdName[1]);
            Console.WriteLine("");
        }
    }


    //Function To Select a Player that alredy played 
    
    /* public string [] PickPlayer(){

    } */
    public void SavePlayersInTxt(string [] players){

    }
}