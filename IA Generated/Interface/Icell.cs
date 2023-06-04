using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IA_Generated.Interface
{

    // Interface que representa uma célula do mapa
    public interface ICell
    {
        ConsoleColor GetBackgroundColor();
        ConsoleColor GetForegroundColor();
        string GetSymbol();
    }

}