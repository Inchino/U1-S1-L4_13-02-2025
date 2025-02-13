using System;
using LoginSystem;

namespace LoginApp
{
    class Program
    {
        static void Main()
        {
            int scelta;
            do
            {
                Console.Clear();
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1.: Login");
                Console.WriteLine("2.: Logout");
                Console.WriteLine("3.: Verifica ora e data di login");
                Console.WriteLine("4.: Lista degli accessi");
                Console.WriteLine("5.: Esci");
                Console.WriteLine("========================================");

                Console.Write("Scelta: ");
                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida, riprova.");
                    Console.ReadKey();
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        EffettuaLogin();
                        break;
                    case 2:
                        Utente.Logout();
                        break;
                    case 3:
                        Utente.VerificaLogin();
                        break;
                    case 4:
                        Utente.MostraStoricoAccessi();
                        break;
                    case 5:
                        Console.WriteLine("Uscita dal programma...");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova.");
                        break;
                }
                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();
            } while (scelta != 5);
        }

        static void EffettuaLogin()
        {
            Console.Write("Inserisci username: ");
            string username = Console.ReadLine();

            Console.Write("Inserisci password: ");
            string password = Console.ReadLine();

            Console.Write("Conferma password: ");
            string confermaPassword = Console.ReadLine();

            Utente.Login(username, password, confermaPassword);
        }
    }
}

