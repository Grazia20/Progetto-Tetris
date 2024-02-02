using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe IBlock rappresenta un blocco di forma "I" nel gioco Tetris.
    // Si estende dalla classe base Block, ereditando funzionalità e proprietà comuni a tutti i blocchi.
    public class IBlock : Block
    {
        // Array multidimensionale che contiene tutte le posizioni dei blocchi per le diverse rotazioni del blocco "I".
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) }, // Prima rotazione
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2) }, // Seconda rotazione
            new Position[] { new(2,0), new(2,1), new(2,2), new(2,3) }, // Terza rotazione
            new Position[] { new(0,1), new(1,1), new(2,1), new(3,1) }  // Quarta rotazione
        };

        // Proprietà per ottenere l'ID del blocco "I".
        public override int Id => 1;

        // Proprietà per ottenere le posizioni dei blocchi nelle diverse rotazioni.
        public override InterfacePosition[][] Tiles => tiles;

        // Proprietà che definisce lo spostamento iniziale del blocco rispetto alla griglia di gioco.
        public override InterfacePosition StartOffset => new Position(-1, 3);
    }
}
