using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe SBlock rappresenta un blocco di forma "S" utilizzato nel gioco Tetris.
    // Deriva dalla classe astratta Block, che definisce il comportamento di base di un blocco.
    public class SBlock : Block
    {
        // Matrice di posizioni che rappresentano le quattro rotazioni possibili del blocco "S".
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            new Position[] { new(0,1), new(0,2), new(1,0), new(1,1) },
            new Position[] { new(0,1), new(1,1), new(1,2), new(2,2) },
            new Position[] { new(1,1), new(1,2), new(2,0), new(2,1) },
            new Position[] { new(0,0), new(1,0), new(1,1), new(2,1) }
        };

        // Identificatore univoco per il blocco "S".
        public override int Id => 5;

        // Proprietà protetta che fornisce la matrice di posizioni del blocco.
        // Questa proprietà viene implementata dalla classe base astratta Block.
        public override InterfacePosition[][] Tiles => tiles;

        // Proprietà protetta che indica la posizione di partenza del blocco.
        // Questa proprietà viene implementata dalla classe base astratta Block.
        public override InterfacePosition StartOffset => new Position(0, 3);
    }
}
