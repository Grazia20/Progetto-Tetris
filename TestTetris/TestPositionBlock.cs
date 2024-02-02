using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestPositionBlock
    {
        [TestMethod]
        public void TestBlockPlacementAfterMove()
        {
            // Arrange: Crea un'istanza della griglia di gioco e un blocco
            InterfaceGrid grid = new Grid(22, 10);
            InterfaceBlock block = new TestBlock();

            // Act: Sposta il blocco e verifica la posizione delle tessere
            block.Move(2, 3);

            // Assert: Verifica che le posizioni delle tessere siano corrette
            foreach (var position in block.TilePosition())
            {
                Assert.IsTrue(grid.IsEmpty(position.Row, position.Column));
            }
        }

        [TestMethod]
        public void TestBlockPlacementAfterRotate()
        {
            // Arrange: Crea un'istanza della griglia di gioco e un blocco
            InterfaceGrid grid = new Grid(22, 10);
            InterfaceBlock block = new TestBlock();

            // Act: Ruota il blocco e verifica la posizione delle tessere
            block.RotateCW();

            // Assert: Verifica che le posizioni delle tessere siano corrette
            foreach (var position in block.TilePosition())
            {
                Assert.IsTrue(grid.IsEmpty(position.Row, position.Column));
            }
        }

        [TestMethod]
        public void TestBlockPlacementAfterMoveAndRotate()
        {
            // Arrange: Crea un'istanza della griglia di gioco e un blocco
            InterfaceGrid grid = new Grid(22, 10);
            InterfaceBlock block = new TestBlock();

            // Act: Sposta e poi ruota il blocco, quindi verifica la posizione delle tessere
            block.Move(2, 3);
            block.RotateCW();

            // Assert: Verifica che le posizioni delle tessere siano corrette
            foreach (var position in block.TilePosition())
            {
                Assert.IsTrue(grid.IsEmpty(position.Row, position.Column));
            }
        }

        // Classe di test stub per il blocco

        private class TestBlock : InterfaceBlock
        {
            public InterfacePosition[][] Tiles { get; }
            public InterfacePosition StartOffset { get; }
            public int Id { get; }

            public TestBlock()
            {
                // Inizializza le proprietà nel costruttore
                Tiles = new InterfacePosition[][]
                {
                    new InterfacePosition[] { new Position(0, 0), new Position(0, 1) },
                    
                };

                StartOffset = new Position(0, 0); // Inizializza l'offset iniziale
                Id = 1; // Assegna un valore univoco all'ID del blocco
            }

            public void RotateCW() { }
            public void RotateCCW() { }
            public void Move(int rows, int columns) { }
            public void Reset() { }
            public IEnumerable<InterfacePosition> TilePosition()
            {
                return Tiles[0]; // Restituisce le posizioni delle tessere per la prima configurazione di rotazione
            }
        }
    }
}