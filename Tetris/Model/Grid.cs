using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // La classe Grid rappresenta la griglia del gioco Tetris in cui vengono posizionati i blocchi.
    // Implementa l'interfaccia InterfaceGrid, che fornisce metodi per manipolare la griglia.
    public class Grid : InterfaceGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        // L'indice per accedere agli elementi della griglia.
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        // Costruttore della classe Grid che inizializza la griglia con il numero di righe e colonne specificato.
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        // Metodo per verificare se una data posizione (r, c) è all'interno della griglia.
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        // Metodo per verificare se una data posizione (r, c) è vuota (valore 0) e all'interno della griglia.
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        // Metodo per verificare se una riga specifica (r) è completamente piena (tutti i valori diversi da 0).
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Metodo per verificare se una riga specifica (r) è completamente vuota (tutti i valori sono 0).
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Metodo privato per cancellare una riga specifica (r) impostando tutti i valori a 0.
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        // Metodo privato per spostare una riga specifica (r) verso il basso di un certo numero di righe (numRows).
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        // Metodo per cancellare tutte le righe completamente piene nella griglia.
        // Restituisce il numero di righe eliminate (celle liberate).
        public int ClearFullRows()
        {
            int cleared = 0; // Celle liberate

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
