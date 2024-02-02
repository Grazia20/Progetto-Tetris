using System;

namespace Tetris.Model
{
    // L'interfaccia InterfaceLogin definisce un contratto per la gestione degli utenti nel gioco Tetris.
    public interface InterfaceLogin
    {
        // Verifica se un utente è già registrato nel sistema.
        // Restituisce true se l'utente è già registrato, altrimenti false.
        bool IsUserRegistered(string username);

        // Registra un nuovo utente nel sistema con un nome utente e una password forniti.
        // Restituisce true se la registrazione è avvenuta con successo, altrimenti false.
        bool RegisterUser(string username, string password);

        // Verifica le credenziali dell'utente per l'autenticazione.
        // Restituisce true se le credenziali sono valide, altrimenti false.
        bool AuthenticateUser(string username, string password);
    }
}
