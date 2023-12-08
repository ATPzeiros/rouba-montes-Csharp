using System;
using System.IO;


static class Log{
    //int count = dir.GetFiles().Length;

    public static void Iniciar(){
       string path = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}.txt",DateTime.Now);
       string arquivo = System.IO.Directory.GetCurrentDirectory() + "/src/txt/mesa/"+path;
       File.Create(arquivo);
    }
}