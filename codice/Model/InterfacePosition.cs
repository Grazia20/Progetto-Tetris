using System;

namespace Tetris.Model
{
    // L'interfaccia InterfacePosition definisce le proprietà Row e Column per rappresentare una posizione.
    // Questa interfaccia sarà implementata da classi che vogliono fornire funzionalità di posizionamento.
    public interface InterfacePosition
    {
        // La coordinata di riga della posizione.
        int Row { get; set; }

        // La coordinata di colonna della posizione.
        int Column { get; set; }
    }
}