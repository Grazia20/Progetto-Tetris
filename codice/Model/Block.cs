using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // La classe astratta Block rappresenta un blocco del gioco Tetris.
    // Implementa l'interfaccia InterfaceBlock che fornisce metodi comuni per i blocchi.
    public abstract class Block : InterfaceBlock
    {
        // Matrice di posizioni che rappresentano le diverse rotazioni del blocco.
        // Ogni riga della matrice rappresenta una configurazione del blocco dopo una rotazione.
        public abstract InterfacePosition[][] Tiles { get; }

        // Posizione di partenza del blocco.
        public abstract InterfacePosition StartOffset { get; }

        // Identificatore univoco del blocco.
        public abstract int Id { get; }

        private int rotationState;
        private InterfacePosition offset;

        // Costruttore della classe Block.
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        // Restituisce una sequenza di posizioni relative delle tessere del blocco.
        // Ogni posizione è calcolata sommando l'offset del blocco alla posizione nella matrice Tiles.
        public IEnumerable<InterfacePosition> TilePosition()
        {
            foreach (InterfacePosition p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Ruota il blocco in senso orario di 90 gradi.
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Ruota il blocco in senso antiorario di 90 gradi.
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        // Sposta il blocco lungo le righe e le colonne specificate.
        public void Move(int rows, int columns)
        {
            offset.Column += columns;
            offset.Row += rows;
        }

        // Reimposta il blocco alla posizione di partenza e lo riporta nella rotazione iniziale.
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
