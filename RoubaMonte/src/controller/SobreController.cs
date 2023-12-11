using System.Text;

class SobreController {
    public string GetSobreText(){
        StringBuilder sobre = new();

        sobre.AppendLine("------------------------------------------------------------ROUBA MONTES------------------------------------------------------------");
        sobre.AppendLine("                                                   Trabalho da disciplina de AED");
        sobre.AppendLine("");
        sobre.AppendLine("  Nosso trabalho consiste em construir o jogo Rouba Montes na Linguagem C#");
        sobre.AppendLine("  O jogo consiste em pegar a carta do topo do baralho aleatoriamente gerado e verrificar se: ");
        sobre.AppendLine("    tem a mesma carta no monte de outro jogador;");
        sobre.AppendLine("    se tem a mesma carta na pilha de descarte.");
        sobre.AppendLine("  Se não tiver carta igual ao número que você pegou do baralho poderá passar a vez, passando a vez você irá colocar a carta no descarte.");
        sobre.AppendLine("");
        sobre.AppendLine("  Além disso, teremos registros dos rankings dos jogadores que alguma vez jogaram e também o historico das partidas");
        sobre.AppendLine("  Todos esses registrados em arquivo para facilitar a escrita e a leitura");
        sobre.AppendLine("");
        // sobre.AppendLine("Para melhor Visualização da interface utilizamos uma biblioteca que se chama TERMINAL-GUI");
        sobre.AppendLine("  Estamos utilizando uma estruturaa chamada MVC que consiste em:");
        sobre.AppendLine("  E por fim os MODELS (de fato onde estão implementadas as nossas classes);");
        sobre.AppendLine("  Utilizamos a estrutura VIEW (para mostrar ao usuário o que ele está requisitando);");
        sobre.AppendLine("  Controlamos o que será mostrado pelos CONTROLLERS (onde este faz as requisições e retorna para a VIEW);");
        sobre.AppendLine("  Assim podemos ter maior controle e organização do nosso código facilitando a leitura e diminuindo o tempo de procura da classe que queremos modificar.");
        sobre.AppendLine("");
        sobre.AppendLine("  Os autores desse trabalho são");
        sobre.AppendLine("    Gabriel Serafim");
        sobre.AppendLine("    Gustavo Soares");
        sobre.AppendLine("    Leandro Costa");

        return sobre.ToString();
    }
}