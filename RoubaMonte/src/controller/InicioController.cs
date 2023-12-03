using System.Collections.Generic;
using System;
class InicioController: BaseController {
    public InicioController(Action<Menu> OnMeunSelected){
        this.OnMeunSelected = OnMeunSelected;
        menuStack.Push(BuildInicialOptions());
    }

    private static List<Menu> BuildInicialOptions() => new(){
        new("Jogar", true, NivelMenu.MESA),
        new("Estatistica", NivelMenu.ESTATISTICA),
        new("Sobre", NivelMenu.SOBRE),
        new("Sair", NivelMenu.SAIR),
    };

    public override List<Menu> GetMenu() => menuStack.Peek();

    public override bool ShouldFinish() => nivelMenu == NivelMenu.SAIR;
}
