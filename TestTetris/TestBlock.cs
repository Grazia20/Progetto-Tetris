using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;
using Tetris.Model.ShapeBlocks;

namespace TestTetris
{
    [TestClass]
    public class TestBlock
    {

        //I-Block
        [TestMethod]
        public void TestIBlockStartOffset()
        {
            // Arrange
            InterfaceBlock iBlock = new IBlock();

            // Act
            InterfacePosition startOffset = iBlock.StartOffset;

            // Assert
            Assert.AreEqual(-1, startOffset.Row);
            Assert.AreEqual(3, startOffset.Column);
        }

        [TestMethod]
        public void TestIBlockId()
        {
            // Arrange
            InterfaceBlock iBlock = new IBlock();

            // Act
            int id = iBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "I".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void TestIBlockTiles()
        {
            // Arrange
            InterfaceBlock iBlock = new IBlock();

            // Act
            InterfacePosition[][] tiles = ((IBlock)iBlock).Tiles;

            // Assert
            InterfacePosition[] expectedFirstRotation = new InterfacePosition[]
            {
                new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(1, 3)
            };
            InterfacePosition[] expectedSecondRotation = new InterfacePosition[]
            {
                new Position(0, 2),new Position(1, 2),new Position(2, 2),new Position(3, 2)
            };
            InterfacePosition[] expectedThirdRotation = new InterfacePosition[]
            {
                new Position(2, 0),new Position(2, 1),new Position(2, 2),new Position(2, 3)
            };
            InterfacePosition[] expectedFourthRotation = new InterfacePosition[]
            {
                new Position(0, 1),new Position(1, 1),new Position(2, 1),new Position(3, 1)
            };

            CollectionAssert.AreEqual(expectedFirstRotation, tiles[0]);
            CollectionAssert.AreEqual(expectedSecondRotation, tiles[1]);
            CollectionAssert.AreEqual(expectedThirdRotation, tiles[2]);
            CollectionAssert.AreEqual(expectedFourthRotation, tiles[3]);
        }


        //J-Block

        [TestMethod]
        public void TestJBlockStartOffset()
        {
            // Arrange
            InterfaceBlock jBlock = new JBlock();

            // Act
            InterfacePosition startOffset = jBlock.StartOffset;

            // Assert
            Assert.AreEqual(0, startOffset.Row);
            Assert.AreEqual(3, startOffset.Column);
        }

        [TestMethod]
        public void TestJBlockId()
        {
            // Arrange
            InterfaceBlock jBlock = new JBlock();

            // Act
            int id = jBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "J".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(2, id);
        }

        [TestMethod]
        public void TestJBlockTiles()
        {
            // Arrange
            InterfaceBlock jBlock = new JBlock();

            // Act
            InterfacePosition[][] tiles = ((JBlock)jBlock).Tiles;

            // Assert
            InterfacePosition[][] expectedTiles = new InterfacePosition[][]
            {
            new InterfacePosition[] { new Position(0, 0), new Position(1, 0), new Position(1, 1), new Position(1, 2) },
            new InterfacePosition[] { new Position(0, 1), new Position(0, 2), new Position(1, 1), new Position(2, 1) },
            new InterfacePosition[] { new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(2, 2) },
            new InterfacePosition[] { new Position(0, 1), new Position(1, 1), new Position(2, 1), new Position(2, 0) }
             };

            for (int i = 0; i < expectedTiles.Length; i++)
            {
                CollectionAssert.AreEqual(expectedTiles[i], tiles[i], $"Discrepanza nella rotazione {i + 1}");
            }
        }


        //L-Block
        [TestMethod]
        public void TestLBlockStartOffset()
        {
            // Arrange
            InterfaceBlock lBlock = new LBlock();

            // Act
            InterfacePosition startOffset = lBlock.StartOffset;

            // Assert
            Assert.AreEqual(0, startOffset.Row);
            Assert.AreEqual(3, startOffset.Column);
        }

        [TestMethod]
        public void TestLBlockId()
        {
            // Arrange
            InterfaceBlock lBlock = new LBlock();

            // Act
            int id = lBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "L".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(3, id);
        }

        [TestMethod]
        public void TestLBlockTiles()
        {
            // Arrange
            InterfaceBlock lBlock = new LBlock();

            // Act
            InterfacePosition[][] tiles = ((LBlock)lBlock).Tiles;

            // Assert
            InterfacePosition[][] expectedTiles = new InterfacePosition[][]
            {
            new InterfacePosition[] { new Position(0, 2), new Position(1, 0), new Position(1, 1), new Position(1, 2) },
            new InterfacePosition[] { new Position(0, 1), new Position(1, 1), new Position(2, 1), new Position(2, 2) },
            new InterfacePosition[] { new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(2, 0) },
            new InterfacePosition[] { new Position(0, 0), new Position(0, 1), new Position(1, 1), new Position(2, 1) }
            };

            for (int i = 0; i < expectedTiles.Length; i++)
            {
                CollectionAssert.AreEqual(expectedTiles[i], tiles[i], $"Discrepanza nella rotazione {i + 1}");
            }
        }

        //O-Block
        [TestMethod]
        public void TestOBlockStartOffset()
        {
            // Arrange
            InterfaceBlock oBlock = new OBlock();

            // Act
            InterfacePosition startOffset = oBlock.StartOffset;

            // Assert
            Assert.AreEqual(0, startOffset.Row);
            Assert.AreEqual(4, startOffset.Column);
        }

        [TestMethod]
        public void TestOBlockId()
        {
            // Arrange
            InterfaceBlock oBlock = new OBlock();

            // Act
            int id = oBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "O".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(4, id);
        }


        [TestMethod]
        public void TestOBlockTiles()
        {
            // Arrange
            InterfaceBlock oBlock = new OBlock();

            // Act
            InterfacePosition[][] tiles = ((OBlock)oBlock).Tiles;

            // Assert
            InterfacePosition[][] expectedTiles = new InterfacePosition[][]
            {
                new InterfacePosition[] { new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(1, 1) }
            };

            for (int i = 0; i < expectedTiles.Length; i++)
            {
                CollectionAssert.AreEqual(expectedTiles[i], tiles[i], $"Discrepanza nella configurazione {i + 1}");
            }
        }

        //S-Block
        [TestMethod]
        public void TestSBlockStartOffset()
        {
            // Arrange
            InterfaceBlock sBlock = new SBlock();

            // Act
            InterfacePosition startOffset = sBlock.StartOffset;

            // Assert
            Assert.AreEqual(0, startOffset.Row);
            Assert.AreEqual(3, startOffset.Column);
        }

        [TestMethod]
        public void TestSBlockId()
        {
            // Arrange
            InterfaceBlock sBlock = new SBlock();

            // Act
            int id = sBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "S".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(5, id);
        }


        [TestMethod]
        public void TestSBlockTiles()
        {
            // Arrange
            InterfaceBlock sBlock = new SBlock();

            // Act
            InterfacePosition[][] tiles = ((SBlock)sBlock).Tiles;

            // Assert
            InterfacePosition[][] expectedTiles = new InterfacePosition[][]
            {
                new InterfacePosition[] { new Position(0, 1), new Position(0, 2), new Position(1, 0), new Position(1, 1) },
                new InterfacePosition[] { new Position(0, 1), new Position(1, 1), new Position(1, 2), new Position(2, 2) },
                new InterfacePosition[] { new Position(1, 1), new Position(1, 2), new Position(2, 0), new Position(2, 1) },
                new InterfacePosition[] { new Position(0, 0), new Position(1, 0), new Position(1, 1), new Position(2, 1) }
            };

            for (int i = 0; i < expectedTiles.Length; i++)
            {
                CollectionAssert.AreEqual(expectedTiles[i], tiles[i], $"Discrepanza nella configurazione {i + 1}");
            }
        }


        //T-Block
        [TestMethod]
        public void TestTBlockStartOffset()
        {
            // Arrange
            InterfaceBlock tBlock = new TBlock();

            // Act
            InterfacePosition startOffset = tBlock.StartOffset;

            // Assert
            Assert.AreEqual(0, startOffset.Row);
            Assert.AreEqual(3, startOffset.Column);
        }

        [TestMethod]
        public void TestTBlockId()
        {
            // Arrange
            InterfaceBlock tBlock = new TBlock();

            // Act
            int id = tBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "T".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(6, id);
        }

        [TestMethod]
        public void TestTBlockTiles()
        {
            // Arrange
            InterfaceBlock tBlock = new TBlock();

            // Act
            InterfacePosition[][] tiles = ((TBlock)tBlock).Tiles;

            // Assert
            InterfacePosition[][] expectedTiles = new InterfacePosition[][]
            {
                new InterfacePosition[] { new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(1, 2) },
                new InterfacePosition[] { new Position(0, 1), new Position(1, 1), new Position(1, 2), new Position(2, 1) },
                new InterfacePosition[] { new Position(1, 0), new Position(1, 1), new Position(1, 2), new Position(2, 1) },
                new InterfacePosition[] { new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(2, 1) }
            };

            for (int i = 0; i < expectedTiles.Length; i++)
            {
                CollectionAssert.AreEqual(expectedTiles[i], tiles[i], $"Discrepanza nella configurazione {i}");
            }
        }

        //Z-Block
        [TestMethod]
        public void TestZBlockStartOffset()
        {
            // Arrange
            InterfaceBlock zBlock = new ZBlock();

            // Act
            InterfacePosition startOffset = zBlock.StartOffset;

            // Assert
            Assert.AreEqual(0, startOffset.Row);
            Assert.AreEqual(3, startOffset.Column);
        }

        [TestMethod]
        public void TestZBlockId()
        {
            // Arrange
            InterfaceBlock zBlock = new ZBlock();

            // Act
            int id = zBlock.Id;

            // Assert
            // Verifica che l'identificatore Id sia correttamente impostato per il blocco "T".
            // Assicurati che il valore sia effettivamente 1.
            Assert.AreEqual(7, id);
        }

        [TestMethod]
        public void TestZBlockTiles()
        {
            // Arrange
            InterfaceBlock zBlock = new ZBlock();

            // Act
            InterfacePosition[][] tiles = ((ZBlock)zBlock).Tiles;

            // Assert
            InterfacePosition[][] expectedTiles = new InterfacePosition[][]
            {
                new InterfacePosition[] { new Position(0, 0), new Position(0, 1), new Position(1, 1), new Position(1, 2) },
                new InterfacePosition[] { new Position(0, 2), new Position(1, 1), new Position(1, 2), new Position(2, 1) },
                new InterfacePosition[] { new Position(1, 0), new Position(1, 1), new Position(2, 1), new Position(2, 2) },
                new InterfacePosition[] { new Position(0, 1), new Position(1, 0), new Position(1, 1), new Position(2, 0) }
            };

            for (int i = 0; i < expectedTiles.Length; i++)
            {
                CollectionAssert.AreEqual(expectedTiles[i], tiles[i], $"Discrepanza nella configurazione {i}");
            }
        }

    }
}