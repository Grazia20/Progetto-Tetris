using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe ZBlock rappresenta un blocco di forma "Z" nel gioco Tetris.
    // La classe eredita dalla classe astratta Block e ne implementa i membri astratti.
    public class ZBlock : Block
    {
        // Matrice contenente le posizioni relative dei tiles (quadratini) che compongono il blocco "Z".
        // La matrice contiene 4 configurazioni diverse del blocco, una per ogni possibile rotazione.
        // Le posizioni sono rappresentate da oggetti Position, che specificano la riga e la colonna del tile.
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            new Position[] { new Position(0, 0), new Position(0, 1), new Position(1, 1), new Position(1, 2) },
            new Position[] { new Position(0, 2), new Position(1, 1), new Position(1, 2), new Position(2, 1) },
            new Position[] { new Position(1, 0), new Position(1, 1), new Position(2, 1), new Position(2, 2) },
            new Position[] { new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(2, 0) }
        };

        // Proprietà "Id" che rappresenta l'identificativo univoco del blocco "Z".
        // L'identificativo è utilizzato per riconoscere il tipo del blocco all'interno del gioco.
        public override int Id => 7;

        // Proprietà "Tiles" che restituisce la matrice delle posizioni dei tiles del blocco.
        // La proprietà viene ereditata dalla classe base "Block" e implementa il metodo astratto.
        public override InterfacePosition[][] Tiles => tiles;

        // Proprietà "StartOffset" che rappresenta la posizione di partenza del blocco.
        // L'offset viene utilizzato per posizionare il blocco nella griglia di gioco iniziale.
        public override InterfacePosition StartOffset => new Position(0, 3);
    }
}
