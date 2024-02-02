using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // L'interfaccia InterfaceBlock definisce i metodi che devono essere implementati da tutte le classi
    // che rappresentano un blocco nel gioco Tetris.
    public interface InterfaceBlock
    {
        // Proprietà che restituisce l'ID del blocco.
        int Id { get; }


        InterfacePosition StartOffset { get; }

        // Metodo che restituisce una sequenza di oggetti InterfacePosition
        // che rappresentano le posizioni dei "mattoncini" (tiles) del blocco.
        IEnumerable<InterfacePosition> TilePosition();

        // Metodo per ruotare il blocco in senso orario (Clockwise).
        void RotateCW();

        // Metodo per ruotare il blocco in senso antiorario (Counter Clockwise).
        void RotateCCW();

        // Metodo per spostare il blocco di un numero specificato di righe e colonne.
        void Move(int rows, int columns);

        // Metodo per ripristinare il blocco alle sue condizioni iniziali.
        void Reset();
    }
}
