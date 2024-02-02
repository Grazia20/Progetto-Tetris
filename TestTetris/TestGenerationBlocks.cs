using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestGenerationBlocks
    {
        [TestMethod]
        public void TestBlockQueueFunctionality()
        {
            InterfaceBlockQueue blockQueue = new BlockQueue();

            // Verifica la funzionalità generale della coda di blocchi
            VerifyBlockQueueFunctionality(blockQueue);
        }


        private static void VerifyBlockQueueFunctionality(InterfaceBlockQueue blockQueue)
        {
            // Verifica che la coda sia inizializzata con un blocco non nullo come prossimo blocco
            Assert.IsNotNull(blockQueue.NextBlock, "Il prossimo blocco nella coda è nullo.");

            // Verifica che i blocchi estratti siano diversi dal prossimo blocco
            for (int i = 0; i < 10; i++) // Estrarre 10 blocchi per test
            {
                InterfaceBlock extractedBlock = blockQueue.GetAndUpdate();
                Assert.AreNotEqual(blockQueue.NextBlock.Id, extractedBlock.Id, "Il blocco estratto è uguale al prossimo blocco.");
            }

            // Verifica che dopo l'estrazione di 10 blocchi, il prossimo blocco non sia nullo
            Assert.IsNotNull(blockQueue.NextBlock, "Il prossimo blocco nella coda è diventato nullo dopo l'estrazione.");
        }


        [TestMethod]
        public void TestBlockQueueExtractionOrder()
        {
            InterfaceBlockQueue blockQueue = new BlockQueue();

            // Verifica l'estrazione casuale dei blocchi
            VerifyRandomBlockExtraction(blockQueue);
        }


        private static void VerifyRandomBlockExtraction(InterfaceBlockQueue blockQueue)
        {
            HashSet<int> extractedIds = new();

            // Estrai i blocchi in modo casuale e verifica che siano estratti correttamente
            for (int i = 0; i < 10; i++) //  Estrarre 10 blocchi per test
            {
                InterfaceBlock extractedBlock = blockQueue.GetAndUpdate();

                // Aggiungi l'ID del blocco estratto all'HashSet
                extractedIds.Add(extractedBlock.Id);

                // Verifica che il blocco estratto non sia nullo
                Assert.IsNotNull(extractedBlock, "Il blocco estratto è nullo.");
            }

            // Verifica che dopo l'estrazione dei blocchi, il prossimo blocco non sia nullo
            Assert.IsNotNull(blockQueue.NextBlock, "Il prossimo blocco nella coda è diventato nullo dopo l'estrazione.");
        }
    }
}




