using System.Collections.Generic;
using System;

class InicioView: BaseView {

    private static InicioController inicioController = new InicioController(OnMenuSelected);

    public InicioView(){
        MostrarMenu(inicioController);
    }

    static void OnMenuSelected(Menu menu){
        if(menu.NextMenu == NivelMenu.MESA){
            new MesaView();
        } else if(menu.NextMenu == NivelMenu.ESTATISTICA){
            new EstatisticaView();
        } else if(menu.NextMenu == NivelMenu.SOBRE){
            new SobreView();
        }
    }
}
