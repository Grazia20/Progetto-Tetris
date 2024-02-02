using System;

namespace Tetris.Model
{
    // L'interfaccia InterfaceBlockQueue definisce le operazioni necessarie per gestire una coda di blocchi nel gioco Tetris.
    // La coda tiene traccia del prossimo blocco che verrà generato e fornisce un modo per ottenere e aggiornare il prossimo blocco disponibile.
    public interface InterfaceBlockQueue
    {
        // Proprietà che restituisce l'interfaccia del prossimo blocco nella coda.
        InterfaceBlock NextBlock { get; }

        // Metodo che restituisce l'interfaccia del prossimo blocco e lo aggiorna nella coda.
        InterfaceBlock GetAndUpdate();
    }
}