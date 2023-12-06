using System.Collections.Generic;
class Menu {
    public string Title { get; set; }
    public bool IsSelected { get; set; }
    public NivelMenu NextMenu { get; set; }

    public Menu(string title, NivelMenu next){
        Title = title;
        IsSelected = false;
        NextMenu = next;
    }

    public Menu(string title, bool isSelected, NivelMenu next){
        Title = title;
        IsSelected = isSelected;
        NextMenu = next;
    }
}