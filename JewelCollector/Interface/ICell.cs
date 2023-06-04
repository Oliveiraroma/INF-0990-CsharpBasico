using System;

namespace JewelCollector.Interface
{

    // Interface que representa uma célula do mapa
    public interface ICell
    {
        ConsoleColor GetBackgroundColor();
        ConsoleColor GetForegroundColor();
        string GetSymbol();
    }

}