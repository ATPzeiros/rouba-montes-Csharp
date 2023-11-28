using System.Collections.Generic;
using System;
class MenuController {

    private NivelMenu nivelMenu = NivelMenu.INICIAL;
    private Stack<List<Menu>> menuStack = new Stack<List<Menu>>();
    private int selectionPos = 0;

    public MenuController(){
        menuStack.Push(BuildInicialOptions());
    }

    private List<Menu> BuildInicialOptions() => new(){
        new("Jogar", true, NivelMenu.MESA),
        new("Estatistica", NivelMenu.ESTATISTICA),
        new("Sair", NivelMenu.SAIR),
    };

    private List<Menu> BuildEstatisticaOptions() => new(){
        new("Ranking Geral", true, NivelMenu.ACAO),
        new("Buscar Por Nome", NivelMenu.ACAO),
        new("Voltar", NivelMenu.VOLTAR),
    };

    private List<Menu> BuildMesaOptions() => new(){
        new("Pegar carta", true, NivelMenu.ACAO),
        new("Roubar", NivelMenu.ACAO),
        new("Passar a vez", NivelMenu.ACAO),
        new("Sair da Mesa", NivelMenu.VOLTAR),
    };

    public List<Menu> GetMenu(){
        return menuStack.Peek();
    }

    public bool ShouldFinish() => nivelMenu == NivelMenu.SAIR;

    public void UpdateMenu(ConsoleKeyInfo keyInfo){
        List<Menu> currentMenu = menuStack.Peek();

        if(keyInfo.Key == ConsoleKey.UpArrow && selectionPos -1 >= 0){
            selectionPos--;
        } else if(keyInfo.Key == ConsoleKey.DownArrow && selectionPos + 1 < currentMenu.Count) {
            selectionPos++;
        } else if(keyInfo.Key == ConsoleKey.Enter){
            UpdateSubMenu();
        }

        for(int i=0;i<currentMenu.Count; i++){
            currentMenu[i].IsSelected = i == selectionPos;
        }
    }

    private void UpdateSubMenu(){
        List<Menu> currentMenu = menuStack.Peek();

        if(currentMenu[selectionPos].NextMenu == NivelMenu.INICIAL){
            menuStack.Push(BuildInicialOptions());
        }else if(currentMenu[selectionPos].NextMenu == NivelMenu.MESA){
            menuStack.Push(BuildMesaOptions());
        } else if(currentMenu[selectionPos].NextMenu == NivelMenu.ESTATISTICA) {
            menuStack.Push(BuildEstatisticaOptions());
        } else if(currentMenu[selectionPos].NextMenu == NivelMenu.VOLTAR){
            menuStack.Pop();
        } else if(currentMenu[selectionPos].NextMenu == NivelMenu.SAIR){
            nivelMenu = NivelMenu.SAIR;
        }

        selectionPos = 0;
    }
}
