using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.ShapeBlocks;

namespace Tetris.Model
{
    // La classe BlockQueue rappresenta una coda di blocchi Tetris.
    // Implementa l'interfaccia InterfaceBlockQueue, che fornisce metodi per gestire la coda dei blocchi.
    public class BlockQueue : InterfaceBlockQueue
    {
        // Array di interfaccia InterfaceBlock contenente i vari tipi di blocchi Tetris.
        private readonly InterfaceBlock[] blocks = new InterfaceBlock[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random();

        // Rappresenta il prossimo blocco nella coda.
        public InterfaceBlock NextBlock { get; private set; }

        // Costruttore della classe BlockQueue.
        public BlockQueue()
        {
            // Inizializza il prossimo blocco con un blocco casuale.
            NextBlock = RandomBlock();
        }

        // Ottiene un blocco casuale dalla lista dei blocchi.
        private InterfaceBlock RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // Ottiene il blocco successivo nella coda e aggiorna il prossimo blocco con un blocco casuale,
        // assicurandosi che il blocco successivo sia diverso dal blocco corrente.
        public InterfaceBlock GetAndUpdate()
        {
            // Ottiene il blocco corrente dalla coda.
            InterfaceBlock block = NextBlock;
            Console.WriteLine($"Current block ID: {block.Id}");

            // Continua a ottenere un nuovo blocco casuale fino a quando il nuovo blocco è lo stesso del blocco corrente.
            do
            {
                NextBlock = RandomBlock();
                Console.WriteLine($"Next block ID: {NextBlock.Id}");
            }
            while (block.Id == NextBlock.Id);

            // Restituisce il blocco corrente.
            return block;
        }
    }
}
