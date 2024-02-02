using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe JBlock rappresenta il blocco a forma di "J" nel gioco Tetris.
    public class JBlock : Block
    {
        // Matrice di posizioni che definiscono le varie rotazioni del blocco J.
        // Ogni riga della matrice rappresenta una diversa rotazione del blocco.
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            new Position[] {new(0, 0), new(1, 0), new(1, 1), new(1, 2)},
            new Position[] {new(0, 1), new(0, 2), new(1, 1), new(2, 1)},
            new Position[] {new(1, 0), new(1, 1), new(1, 2), new(2, 2)},
            new Position[] {new(0, 1), new(1, 1), new(2, 1), new(2, 0)}
        };

        // Identificatore univoco del blocco J.
        public override int Id => 2;

        // Proprietà che restituisce la matrice di posizioni specifica per il blocco J.
        public override InterfacePosition[][] Tiles => tiles;

        // Proprietà che restituisce l'offset di posizione iniziale per il blocco J.
        public override InterfacePosition StartOffset => new Position(0, 3);
    }
}
