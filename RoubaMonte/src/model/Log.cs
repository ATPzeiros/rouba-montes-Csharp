using System;
using System.IO;

class Log {
    private string path = System.IO.Directory.GetCurrentDirectory() + "/src/txt/mesa/"+ string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}.txt",DateTime.Now);
    private string rankingPath = System.IO.Directory.GetCurrentDirectory() + "/src/txt/ranking/ranking.txt";
    private string playerHandPath = System.IO.Directory.GetCurrentDirectory() + "/src/txt/jogadorlastgamehand.txt";

    public Log(){
        File.Create(path).Close();

        if(!File.Exists(rankingPath)){
            File.Create(rankingPath).Close();
        }

        if(!File.Exists(playerHandPath)){
            File.Create(playerHandPath).Close();
        }
    }

    public void SalvarArcao(Jogador jogador, string acao){
        using(StreamWriter writetext = new StreamWriter(path, true)){
            writetext.WriteLine(jogador.name + "," + acao);
            writetext.Close();
        }
    }

    public void SalvarRoubo(Jogador atual, Jogador roubado){
        using(StreamWriter writetext = new StreamWriter(path, true)){
            writetext.WriteLine(atual.name + " ROUBOU MONTE DE " + roubado.name);
            writetext.Close();
        }
    }

    public void SalvarInicializacao(Jogador jogador, Carta carta){
        using(StreamWriter writetext = new StreamWriter(path, true)){
            writetext.WriteLine(jogador.name + " INICIALIZOU COM " + carta.Numero);
            writetext.Close();
        }
    }

    public void SalvarRanking(List<Jogador> jogadores){
        using(StreamWriter writetext = new StreamWriter(rankingPath, append: true)){
            int pos = 0;
            int points = 3;
            foreach (Jogador jogador in jogadores.OrderBy(x => x.monte.Count).Reverse())
            {

                writetext.Write(jogador.id);
                writetext.Write(",");
                writetext.Write(pos);
                writetext.Write(",");
                writetext.Write(pos < 3 ? points : 1);
                writetext.Write("\n");

                if(pos < 3){   
                    points--;
                }
                pos++;
            }

            Console.ReadKey();
        }
    }

    public void SalvarMao(string id, Stack<Carta> cartas){
         using(StreamWriter writetext = new StreamWriter(playerHandPath, append: true)){
            string record = id + "-";
            foreach (Carta carta in cartas)
            {
                record += carta.Numero + " ";
            }

            writetext.WriteLine(record.Trim());
         }
    }
}