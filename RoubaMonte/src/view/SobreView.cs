using System.Text;
using System.Collections.Generic;
using System;

class SobreView
{
    SobreController sobreController = new();
    public SobreView(){
        Console.WriteLine(sobreController.GetSobreText());
        Console.ReadKey();
    }
}
