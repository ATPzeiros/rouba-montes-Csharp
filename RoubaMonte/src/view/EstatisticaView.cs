class EstatisticaView: BaseView
{

    EstatisticaController estatisticaController = new(OnMenuSelected);

    public EstatisticaView(){
        MostrarMenu(estatisticaController);
    }

    static void OnMenuSelected(Menu menu){
        if(menu.NextMenu == NivelMenu.ESTATISTICA_GERAL){
            Console.Clear();
            Console.WriteLine("Ranking Geral\n");
            
            Console.WriteLine(EstatisticaController.GetEstatisticaGeral());
            Console.ReadKey();
        } else if(menu.NextMenu == NivelMenu.ESTATISTICA_NOME) {
            Console.WriteLine("Nome");
            Console.ReadKey();
        }
    }
}