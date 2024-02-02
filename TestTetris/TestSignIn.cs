using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model;

namespace TestTetris
{
    [TestClass]
    public class TestSignIn
    {
        [TestMethod]
        public void TestValidAuthentication()
        {
            // Arrange: Crea un'istanza della classe Login e registra un utente
            InterfaceLogin login = new Login();
            login.RegisterUser("testuser", "testpassword");

            // Act: Autentica l'utente con le credenziali corrette
            bool authenticationResult = login.AuthenticateUser("testuser", "testpassword");

            // Assert: Verifica che l'autenticazione sia avvenuta con successo
            Assert.IsTrue(authenticationResult);
        }

        [TestMethod]
        public void TestInvalidAuthentication()
        {
            // Arrange: Crea un'istanza della classe Login e registra un utente
            InterfaceLogin login = new Login();
            login.RegisterUser("testuser", "testpassword");

            // Act: Autentica l'utente con credenziali errate
            bool authenticationResult = login.AuthenticateUser("testuser", "wrongpassword");

            // Assert: Verifica che l'autenticazione fallisca a causa delle credenziali errate
            Assert.IsFalse(authenticationResult);
        }

        [TestMethod]
        public void TestNonExistingUserAuthentication()
        {
            // Arrange: Crea un'istanza della classe Login

            InterfaceLogin login = new Login();

            // Act: Autentica un utente che non è stato registrato
            bool authenticationResult = login.AuthenticateUser("nonexistentuser", "password");

            // Assert: Verifica che l'autenticazione fallisca a causa dell'utente non registrato
            Assert.IsFalse(authenticationResult);
        }
    }
}
