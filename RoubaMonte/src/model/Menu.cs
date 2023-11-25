using System.Collections.Generic;
class Menu {
    public string Title { get; set; }
    public bool IsSelected { get; set; }
    public NivelMenu NextMenu { get; set; }

    public Menu(string title, NivelMenu nivel){
        Title = title;
        IsSelected = false;
        NextMenu = nivel;
    }

    public Menu(string title, bool isSelected, NivelMenu nivel){
        Title = title;
        IsSelected = isSelected;
        NextMenu = nivel;
    }
}