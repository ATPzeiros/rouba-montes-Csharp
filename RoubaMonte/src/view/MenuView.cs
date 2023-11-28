using System;

class MenuView {

    private static MenuController menuController = new MenuController();
    private ConsoleKeyInfo opcao;

    public void MostrarMenu(){
        do{
            Console.Clear();
            foreach(Menu menu in menuController.GetMenu() ){
                if(menu.IsSelected){
                    Console.WriteLine("-> " + menu.Title);
                } else {
                    Console.WriteLine("   " + menu.Title);
                }
            }

            opcao = Console.ReadKey();
            menuController.UpdateMenu(opcao);
        }while(!menuController.ShouldFinish());
    }
}
