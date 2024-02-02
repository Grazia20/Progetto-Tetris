using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // La classe GameState gestisce lo stato del gioco Tetris, incluso il posizionamento dei blocchi,
    // la gestione del punteggio, il mantenimento del blocco corrente e il suo movimento.
    // Implementa l'interfaccia InterfaceGameState, che definisce i metodi pubblici disponibili
    // per il controllo del gioco da parte del ViewModel o di altre parti dell'applicazione.
    public class GameState : InterfaceGameState
    {
        private InterfaceBlock currentBlock = null!;

        // Rappresenta il blocco corrente nel gioco.
        public InterfaceBlock CurrentBlock
        {
            get => currentBlock;
            private set
            {
                // Resetta il blocco corrente (posizione e rotazione)
                currentBlock = value;
                currentBlock.Reset();

                // Controlla se il blocco può essere posizionato nella posizione iniziale,
                // altrimenti prova a spostarlo leggermente verso il basso finché non trova
                // una posizione valida.
                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        // Rappresenta la griglia di gioco.
        public InterfaceGrid Grid { get; }

        // Rappresenta la coda di blocchi per la generazione dei nuovi blocchi.
        public InterfaceBlockQueue Queue { get; }

        // Indica se il gioco è finito (true) o meno (false).
        public bool GameOver { get; private set; }

        // Rappresenta il punteggio corrente del giocatore.
        public int Score { get; private set; }

        // Rappresenta il blocco tenuto dall'utente. Può essere scambiato con il blocco corrente.
        public InterfaceBlock HeldBlock { get; private set; }

        // Indica se è possibile tenere un blocco o se è già stato utilizzato durante l'attuale turno.
        public bool CanHold { get; private set; }

        // Costruttore della classe GameState. Crea una griglia di gioco e una coda di blocchi
        // per la generazione dei nuovi blocchi. Inizializza il blocco corrente e permette l'utilizzo
        // della funzione HoldBlock per tenere un blocco.
        public GameState()
        {
            Grid = new Grid(22, 10);
            Queue = new BlockQueue();
            CurrentBlock = Queue.GetAndUpdate();
            CanHold = true;
            
        }

        // Verifica se il blocco corrente può essere posizionato nella sua posizione attuale.
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePosition())
            {
                Console.WriteLine($"Checking position ({p.Row}, {p.Column}): IsEmpty? {Grid.IsEmpty(p.Row, p.Column)}");
                if (!Grid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }

            return true;
        }

        // Tenta di tenere il blocco corrente scambiandolo con il blocco precedentemente tenuto.
        // Solo un blocco può essere tenuto in un determinato turno.
        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }

            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = Queue.GetAndUpdate();
            }
            else
            {
                InterfaceBlock tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = (Block)tmp;
            }

            CanHold = false;
        }

        // Ruota il blocco corrente in senso orario (CW). Se la rotazione non è valida, viene
        // annullata tornando alla rotazione precedente.
        public void RotateBlockCW()
        {
            Console.WriteLine("Before Rotate CW:");
            foreach (var position in CurrentBlock.TilePosition())
            {
                Console.WriteLine($"Row: {position.Row}, Column: {position.Column}");
            }

            CurrentBlock.RotateCW();

            Console.WriteLine("After Rotate CW:");
            foreach (var position in CurrentBlock.TilePosition())
            {
                Console.WriteLine($"Row: {position.Row}, Column: {position.Column}");
            }

            if (!BlockFits())
            {
                Console.WriteLine("Block doesn't fit after CW rotation. Trying CCW rotation.");
                CurrentBlock.RotateCCW();
            }
        }

        // Ruota il blocco corrente in senso antiorario (CCW). Se la rotazione non è valida, viene
        // annullata tornando alla rotazione precedente.
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        // Sposta il blocco corrente verso sinistra. Se lo spostamento non è valido, viene annullato
        // ripristinando la posizione precedente del blocco.
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        // Sposta il blocco corrente verso destra. Se lo spostamento non è valido, viene annullato
        // ripristinando la posizione precedente del blocco.
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        // Controlla se il gioco è finito. Il gioco termina quando i primi due livelli della griglia
        // di gioco non sono vuoti.
        private bool IsGameOver()
        {
            return !(Grid.IsRowEmpty(0) && Grid.IsRowEmpty(1));
        }

        // Posiziona il blocco corrente nella griglia di gioco. Controlla se ci sono righe complete
        // da eliminare e aggiorna il punteggio di conseguenza. Se il gioco è finito, imposta la
        // variabile GameOver su true.
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePosition())
            {
                Grid[p.Row, p.Column] = CurrentBlock.Id;
            }

            Score += Grid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = Queue.GetAndUpdate();
                CanHold = true;
            }
        }

        // Sposta il blocco corrente verso il basso. Se lo spostamento non è valido, il blocco
        // viene posizionato nella griglia e si procede al controllo delle righe complete.
        public void MoveBlockDown()
        {
            Console.WriteLine("Before Move Down:");
            foreach (var position in CurrentBlock.TilePosition())
            {
                Console.WriteLine($"Row: {position.Row}, Column: {position.Column}");
            }

            CurrentBlock.Move(1, 0);

            Console.WriteLine("After Move Down:");
            foreach (var position in CurrentBlock.TilePosition())
            {
                Console.WriteLine($"Row: {position.Row}, Column: {position.Column}");
            }

            if (!BlockFits())
            {
                Console.WriteLine("Block doesn't fit. Trying to place the block.");
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        // Calcola la distanza di caduta per il blocco corrente in base alla sua posizione attuale.
        // Questa funzione calcola quante righe può scendere il blocco prima di toccare un altro blocco
        // o il fondo della griglia di gioco.
        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (Grid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            return drop;
        }

        // Calcola la distanza di caduta per l'intero blocco corrente. Restituisce il numero di righe
        // che può scendere senza collidere con altri blocchi o il fondo.
        public int BlockDropDstance()
        {
            int drop = Grid.Rows;

            foreach (Position p in CurrentBlock.TilePosition())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        // Fa cadere il blocco corrente nella sua posizione più bassa possibile e lo posiziona nella griglia.
        // Successivamente, controlla se ci sono righe complete da eliminare e aggiorna il punteggio di conseguenza.
        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDstance(), 0);
            PlaceBlock();
        }
    }
}
