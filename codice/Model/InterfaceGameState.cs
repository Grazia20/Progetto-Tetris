using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    // L'interfaccia InterfaceGameState definisce i membri che rappresentano lo stato del gioco Tetris.
    // Questi membri specificano informazioni riguardanti il blocco corrente, la griglia, la coda di blocchi, il punteggio, il blocco tenuto e altre informazioni.
    public interface InterfaceGameState
    {
        InterfaceBlock CurrentBlock { get; }  // Rappresenta il blocco correntemente in gioco.
        InterfaceGrid Grid { get; }  // Rappresenta la griglia di gioco con i blocchi posizionati.
        InterfaceBlockQueue Queue { get; }  // Rappresenta la coda dei prossimi blocchi da visualizzare.
        bool GameOver { get; }  // Indica se il gioco è finito (true) o meno (false).
        int Score { get; }  // Rappresenta il punteggio del giocatore.
        InterfaceBlock HeldBlock { get; }  // Rappresenta il blocco tenuto dal giocatore.
        bool CanHold { get; }  // Indica se il giocatore può tenere un blocco (true) o meno (false).

        // Metodi per gestire le azioni del gioco.
        void HoldBlock();  // Tieni il blocco corrente, se possibile.
        void RotateBlockCW();  // Ruota il blocco corrente in senso orario.
        void RotateBlockCCW();  // Ruota il blocco corrente in senso antiorario.
        void MoveBlockLeft();  // Sposta il blocco corrente verso sinistra.
        void MoveBlockRight();  // Sposta il blocco corrente verso destra.
        void MoveBlockDown();  // Sposta il blocco corrente verso il basso.
        int BlockDropDstance();  // Restituisce la distanza di caduta del blocco corrente.
        void DropBlock();  // Lascia cadere il blocco corrente fino a raggiungere la sua posizione finale.
    }
}
