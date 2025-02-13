using System;
using System.Collections.Generic;

namespace LoginSystem
{
    public static class Utente
    {
        private static string _username;
        private static DateTime? _dataLogin;
        private static List<LoginEntry> _storicoAccessi = new List<LoginEntry>();

        public static string Username
        {
            get { return _username; }
            private set { _username = value; }
        }

        public static DateTime? DataLogin
        {
            get { return _dataLogin; }
            private set { _dataLogin = value; }
        }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(_username);

        public static void Login(string username, string password, string confermaPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confermaPassword))
            {
                Console.WriteLine("Errore: Tutti i campi sono obbligatori.");
                return;
            }

            if (password != confermaPassword)
            {
                Console.WriteLine("Errore: Le password non coincidono.");
                return;
            }

            Username = username;
            DataLogin = DateTime.Now;
            _storicoAccessi.Add(new LoginEntry(username, DataLogin.Value));

            Console.WriteLine($"Login effettuato con successo! Benvenuto, {Username}.");
        }

        public static void Logout()
        {
            if (!IsLoggedIn)
            {
                Console.WriteLine("Errore: Nessun utente è attualmente loggato.");
                return;
            }

            Console.WriteLine($"Logout effettuato per {Username}.");
            Username = null;
            DataLogin = null;
        }

        public static void VerificaLogin()
        {
            if (!IsLoggedIn)
            {
                Console.WriteLine("Errore: Nessun utente è attualmente loggato.");
                return;
            }

            Console.WriteLine($"Ultimo login effettuato il: {DataLogin}");
        }

        public static void MostraStoricoAccessi()
        {
            if (_storicoAccessi.Count == 0)
            {
                Console.WriteLine("Nessun accesso registrato.");
                return;
            }

            Console.WriteLine("Storico degli accessi:");
            foreach (var entry in _storicoAccessi)
            {
                Console.WriteLine($"Utente: {entry.Username}, Data: {entry.DataOra}");
            }
        }
    }
}

