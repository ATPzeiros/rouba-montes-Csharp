using System.Text;

class SobreView
{
    SobreController sobreController = new();
    public SobreView(){
        Console.WriteLine(sobreController.GetSobreText());
        Console.ReadKey();
    }
}
