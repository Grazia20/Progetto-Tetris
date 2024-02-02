using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tetris.Model
{
    // La classe Login gestisce la registrazione e l'autenticazione degli utenti per il gioco Tetris.
    // Implementa l'interfaccia InterfaceLogin, che fornisce i metodi necessari per queste funzionalità.
    public class Login : InterfaceLogin
    {
        // Nome del file in cui vengono salvati gli utenti registrati con il formato "username:password"
        private const string FileName = "users.txt";

        // Verifica se un utente è già registrato nel sistema.
        public bool IsUserRegistered(string username)
        {
            return GetRegisteredUsers().Any(u => u.Username == username);
        }

        // Registra un nuovo utente nel sistema con un nome utente e una password forniti.
        // Restituisce true se la registrazione è avvenuta con successo, altrimenti false se l'utente è già registrato.
        public bool RegisterUser(string username, string password)
        {
            if (IsUserRegistered(username))
            {
                return false; // Utente già registrato
            }

            // Aggiunge l'utente al file di testo "users.txt"
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine($"{username}:{password}");
            }

            return true; // Registrazione avvenuta con successo
        }

        // Verifica le credenziali dell'utente per l'autenticazione.
        // Restituisce true se le credenziali sono valide, altrimenti false.
        public bool AuthenticateUser(string username, string password)
        {
            var registeredUsers = GetRegisteredUsers();
            return registeredUsers.Any(u => u.Username == username && u.Password == password);
        }

        // Ottiene la lista degli utenti registrati dal file di testo "users.txt".
        private List<User> GetRegisteredUsers()
        {
            List<User> users = new List<User>();

            // Controlla se il file "users.txt" esiste
            if (!File.Exists(FileName))
            {
                return users; // Se il file non esiste, restituisce una lista vuota
            }

            // Legge tutte le righe dal file "users.txt"
            string[] lines = File.ReadAllLines(FileName);

            // Analizza ogni riga e crea un oggetto User per ogni utente registrato
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string username = parts[0];
                    string password = parts[1];
                    users.Add(new User(username, password));
                }
            }

            return users;
        }

        // Classe interna che rappresenta un utente con un nome utente e una password.
        private class User
        {
            public string Username { get; }
            public string Password { get; }

            public User(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }
    }
}
