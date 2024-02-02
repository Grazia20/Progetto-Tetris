using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model.ShapeBlocks
{
    // La classe OBlock rappresenta un tipo di blocco nel gioco Tetris chiamato "OBlock".
    // Questo blocco è composto da quattro posizioni disposte in un arrangiamento specifico.
    public class OBlock : Block
    {
        // Matrice di posizioni che rappresenta l'arrangiamento dei quadrati del blocco "OBlock".
        // Il blocco "OBlock" ha una forma quadrata e non ruota, quindi la matrice ha una sola configurazione.
        private readonly InterfacePosition[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) }
        };

        // Identificatore del blocco "OBlock". Utilizzato per identificare il tipo di blocco.
        public override int Id => 4;

        // Matrice di posizioni che rappresenta l'arrangiamento dei quadrati del blocco.
        public override InterfacePosition[][] Tiles => tiles;

        // Posizione di partenza del blocco "OBlock" all'interno della griglia di gioco.
        public override InterfacePosition StartOffset => new Position(0, 4);
    }
}
