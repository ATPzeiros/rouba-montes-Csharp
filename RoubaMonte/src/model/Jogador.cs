using System;
using System.IO;
using System.Collections.Generic;

class Jogador {
    public string id {get;set;}
    public string name {get;set;}
    public Stack<Carta> carta {get;set;}
    // private string lastGamePosition;
    // private string lastGameHand;
    // private Queue<string> Ranking;


    public static string [] GetPlayersToMatriz(){
        string [] jogadores = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/src/model/jogador.txt");
        return jogadores;
    }

    public Jogador(string id, string name){
        this.id = id;
        this.name = name;
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


    //Function To Select a Player that alredy played 
    
    /* public string [] PickPlayer(){

    } */
    public void SavePlayersInTxt(string [] players){

    }
}