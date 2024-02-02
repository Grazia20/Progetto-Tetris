using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // La classe Position rappresenta una posizione nel gioco Tetris.
    // Implementa l'interfaccia InterfacePosition, che fornisce proprietà o metodi comuni per le posizioni.
    public class Position : InterfacePosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object? obj)
        {
            if (obj is InterfacePosition otherPosition)
            {
                return Row == otherPosition.Row && Column == otherPosition.Column;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}




