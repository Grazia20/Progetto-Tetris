using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // L'interfaccia InterfaceGrid rappresenta una griglia di gioco per il gioco Tetris.
    // Questa interfaccia definisce le proprietà e i metodi che devono essere implementati
    // da qualsiasi classe che voglia rappresentare una griglia di gioco Tetris.

    public interface InterfaceGrid
    {
        // Il numero di righe nella griglia.
        int Rows { get; }

        // Il numero di colonne nella griglia.
        int Columns { get; }

        // Indicizza la griglia con le coordinate (r, c) e restituisce o imposta il valore
        // nella cella corrispondente.
        int this[int r, int c] { get; set; }

        // Verifica se le coordinate (r, c) sono all'interno della griglia.
        bool IsInside(int r, int c);

        // Verifica se la cella alla posizione (r, c) è vuota (contiene un valore 0).
        bool IsEmpty(int r, int c);

        // Verifica se l'intera riga r è completamente riempita (non contiene celle vuote).
        bool IsRowFull(int r);

        // Verifica se l'intera riga r è completamente vuota (tutte le celle sono vuote).
        bool IsRowEmpty(int r);

        // Cancella tutte le righe completamente riempite nella griglia e restituisce il numero
        // di righe cancellate.
        int ClearFullRows();
    }
}
