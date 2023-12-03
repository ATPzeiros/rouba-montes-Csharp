using System.Text;

class SobreController {
    public string GetSobreText(){
        StringBuilder sobre = new();

        sobre.AppendLine("========Rouba Monte========");
        sobre.AppendLine("Trabalho para a disciplina de AED");
        sobre.AppendLine("");
        sobre.AppendLine("Gabriel Serafim");
        sobre.AppendLine("Gustavo Soares");
        sobre.AppendLine("Leandro Augusto");

        return sobre.ToString();
    }
}