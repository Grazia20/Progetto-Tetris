using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe TBlock rappresenta un blocco di forma "T" nel gioco Tetris.
    // Estende la classe astratta Block e implementa le sue proprietà e metodi astratti.
    public class TBlock : Block
    {
        // Le diverse configurazioni dei mattoncini per la forma "T".
        // Ogni riga dell'array rappresenta una rotazione del blocco.
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            // Configurazione 0
            new Position[] {new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(1, 2)},
            
            // Configurazione 1
            new Position[] {new Position(0, 1), new Position(1, 1), new Position(1, 2), new Position(2, 1)},
            
            // Configurazione 2
            new Position[] {new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(2, 1)},
            
            // Configurazione 3
            new Position[] {new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(2, 1)}
        };

        // Proprietà Id che identifica univocamente la forma "T" con un numero intero.
        public override int Id => 6;

        // Proprietà Tiles che restituisce le diverse configurazioni dei mattoncini per la forma "T".
        public override InterfacePosition[][] Tiles => tiles;

        // Proprietà StartOffset che rappresenta l'offset di inizio per la forma "T".
        // Specifica la posizione iniziale in cui il blocco viene posizionato nel campo di gioco.
        public override InterfacePosition StartOffset => new Position(0, 3);
    }
}
