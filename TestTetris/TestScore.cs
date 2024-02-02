using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestScore
    {
        [TestMethod]
        public void TestScoreCalculation()
        {
            // Arrange: Crea un'istanza del gioco e della griglia
            InterfaceGameState gameState = new GameState();

            // Act: Simula la cancellazione di alcune righe e verifica il punteggio
            gameState.Grid[0, 0] = 1;
            gameState.Grid[0, 1] = 1;
            gameState.Grid[1, 0] = 1;
            gameState.Grid[1, 1] = 1;

            int expectedScore = gameState.Grid.ClearFullRows() * 100; // 400 punti attesi

            // Assert: Verifica che il punteggio sia calcolato correttamente
            Assert.AreEqual(expectedScore, gameState.Score);
        }

        [TestMethod]
        public void TestScoreMultipleClears()
        {
            // Arrange: Crea un'istanza del gioco e della griglia
            InterfaceGameState gameState = new GameState();

            // Act: Simula la cancellazione di più righe e verifica il punteggio
            gameState.Grid[0, 0] = 1;
            gameState.Grid[0, 1] = 1;
            gameState.Grid[1, 0] = 1;
            gameState.Grid[1, 1] = 1;

            gameState.Grid[4, 0] = 1;
            gameState.Grid[4, 1] = 1;
            gameState.Grid[5, 0] = 1;
            gameState.Grid[5, 1] = 1;

            int expectedScore = (gameState.Grid.ClearFullRows() * 100) + (gameState.Grid.ClearFullRows() * 100); // 800 punti attesi

            // Assert: Verifica che il punteggio sia calcolato correttamente
            Assert.AreEqual(expectedScore, gameState.Score);
        }
    }
}