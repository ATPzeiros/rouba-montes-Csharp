using System;
using System.IO;

class Log {

    // string path = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}.txt",DateTime.Now);
    private string path = System.IO.Directory.GetCurrentDirectory() + "/src/txt/mesa/"+ string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}.txt",DateTime.Now);

    public Log(){
       File.Create(path).Close();
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
}