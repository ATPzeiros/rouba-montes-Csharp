using System.Collections.Generic;
using System;
class BaseView
{
    private ConsoleKeyInfo opcao;
    public void MostrarMenu(BaseController controller){
        do{
            Console.Clear();
            Console.WriteLine(BaseController.Logo());
            foreach(Menu menu in controller.GetMenu() ){
                if(menu.IsSelected){
                    Console.WriteLine("-> " + menu.Title);
                } else {
                    Console.WriteLine("   " + menu.Title);
                }
            }
            opcao = Console.ReadKey();
            controller.UpdateMenu(opcao);
        }while(!controller.ShouldFinish());
    }
    public void MostrarMenu(BaseController controller, Action<int> ShowStatus){
        do{
            Console.Clear();
            Console.WriteLine(BaseController.Logo());
            foreach(Menu menu in controller.GetMenu() ){
                if(menu.IsSelected){
                    Console.WriteLine("-> " + menu.Title);
                } else {
                    Console.WriteLine("   " + menu.Title);
                }
            }
            ShowStatus(1);
            opcao = Console.ReadKey();
            controller.UpdateMenu(opcao);
        }while(!controller.ShouldFinish());
    }
}