using System;
using System.Collections.Generic;

class EstatisticaController: BaseController
{

    public EstatisticaController(Action<Menu> onMenuSelected){
        OnMeunSelected = onMenuSelected;
        menuStack.Push(BuildEstatisticaOptions());
    }

    private static List<Menu> BuildEstatisticaOptions() => new(){
        new("Ranking Geral", true, NivelMenu.ESTATISTICA_GERAL),
        new("Buscar Por Nome", NivelMenu.ESTATISTICA_NOME),
        new("Voltar", NivelMenu.VOLTAR),
    };

    public override List<Menu> GetMenu() => menuStack.Peek();

    public override bool ShouldFinish() => nivelMenu == NivelMenu.VOLTAR;

    public static string GetEstatisticaGeral(){
        return "1 - Eu\n2 - Voce \n3 - Ele";
    }

    public void GetEstatisticaNome(string nome){

    }
}