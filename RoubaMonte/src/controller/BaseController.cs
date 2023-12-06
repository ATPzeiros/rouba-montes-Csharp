using System;
using System.Collections.Generic;
using System.Text;

abstract class BaseController {
    protected Stack<List<Menu>> menuStack = new Stack<List<Menu>>();
    private int selectionPos = 0;
    protected Action<Menu> OnMeunSelected;

    protected NivelMenu nivelMenu = NivelMenu.INICIAL;

    public void UpdateMenu(ConsoleKeyInfo keyInfo){
        List<Menu> currentMenu = menuStack.Peek();

        if(keyInfo.Key == ConsoleKey.UpArrow && selectionPos -1 >= 0){
            selectionPos--;
        } else if(keyInfo.Key == ConsoleKey.DownArrow && selectionPos + 1 < currentMenu.Count) {
            selectionPos++;
        } else if(keyInfo.Key == ConsoleKey.Enter){
            nivelMenu = currentMenu[selectionPos].NextMenu;
            OnMeunSelected(currentMenu[selectionPos]);
        }

        for(int i=0;i<currentMenu.Count; i++){
            currentMenu[i].IsSelected = i == selectionPos;
        }
    }

    public static string Logo(){
        StringBuilder logo = new();
        logo.AppendLine("  _____             _             __  __             _       ");
        logo.AppendLine(" |  __ \\           | |           |  \\/  |           | |      ");
        logo.AppendLine(" | |__) |___  _   _| |__   __ _  | \\  / | ___  _ __ | |_ ___ ");
        logo.AppendLine(" |  _  // _ \\| | | | '_ \\ / _` | | |\\/| |/ _ \\| '_ \\| __/ _ \\");
        logo.AppendLine(" | | \\ \\ (_) | |_| | |_) | (_| | | |  | | (_) | | | | ||  __/");
        logo.AppendLine(" |_|  \\_\\___/ \\__,_|_.__/ \\__,_| |_|  |_|\\___/|_| |_|\\__\\___|");
        logo.AppendLine("");
        return logo.ToString();
    }

    abstract public List<Menu> GetMenu();

    abstract public bool ShouldFinish();
}