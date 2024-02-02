using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestSignUp
    {
        [TestMethod]
        public void TestUserRegistration()
        {
            // Arrange: Crea un'istanza della classe Login
            InterfaceLogin login = new Login();

            // Act: Registra un nuovo utente
            bool registrationResult = login.RegisterUser("newuser", "newpassword");

            // Assert: Verifica che la registrazione sia avvenuta con successo
            Assert.IsTrue(registrationResult);
        }

        [TestMethod]
        public void TestDuplicateUserRegistration()
        {
            // Arrange: Crea un'istanza della classe Login
            InterfaceLogin login = new Login();

            // Registra un utente
            login.RegisterUser("existinguser", "password");

            // Act: Tenta di registrare lo stesso utente nuovamente
            bool registrationResult = login.RegisterUser("existinguser", "newpassword");

            // Assert: Verifica che la registrazione fallisca a causa dell'utente già registrato
            Assert.IsFalse(registrationResult);
        }
    }
}
