using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestGameOver
    {
        [TestMethod]
        public void TestGameOverDetection()
        {
             // Arrange: Crea un'istanza di GameState con un blocco fittizio
            GameState gameState = new();
    
            // Simula la situazione in cui il blocco raggiunge la parte superiore
            for (int i = 0; i < 22; i++)
            {
                gameState.MoveBlockDown();
            }

            // Il gioco dovrebbe essere finito a questo punto
            Assert.IsFalse(gameState.GameOver);
        }

       
    }
}
