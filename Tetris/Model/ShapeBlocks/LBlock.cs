using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe LBlock rappresenta un blocco a forma di "L" nel gioco Tetris.
    public class LBlock : Block
    {
        // Matrici di oggetti Position che rappresentano le diverse rotazioni del blocco "L".
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            new Position[] {new(0,2), new(1,0), new(1,1), new(1,2)},
            new Position[] {new(0,1), new(1,1), new(2,1), new(2,2)},
            new Position[] {new(1,0), new(1,1), new(1,2), new(2,0)},
            new Position[] {new(0,0), new(0,1), new(1,1), new(2,1)}
        };

        // ID del blocco "L" (usato per identificare il tipo di blocco).
        public override int Id => 3;

        // Proprietà protetta che restituisce la matrice di posizioni corrispondente al blocco "L".
        public override InterfacePosition[][] Tiles => tiles;

        // Offset iniziale del blocco "L" quando spawnato nel gioco.
        public override InterfacePosition StartOffset => new Position(0, 3);
    }
}
