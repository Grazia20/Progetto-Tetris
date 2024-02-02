using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestHoldingBlock
    {
        [TestMethod]
        public void TestHoldBlock()
        {
            // Arrange: Crea un'istanza del gioco
            InterfaceGameState gameState = new GameState();

            // Act: Esegui l'azione di "holding" del blocco
            InterfaceBlock currentBlock = gameState.CurrentBlock;
            gameState.HoldBlock();

            // Assert: Verifica che il blocco corrente sia stato sostituito con il blocco tenuto
            Assert.AreNotEqual(currentBlock, gameState.CurrentBlock);
            Assert.AreEqual(currentBlock, gameState.HeldBlock);
        }
    }
}
