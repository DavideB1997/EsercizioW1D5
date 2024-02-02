namespace EsercizioW1D5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool boolReddito = false;
            bool boolCF = false;
            

            Console.WriteLine("Calcolo della imposta da versare!");
                Console.WriteLine("1. inserisci i tuoi dati:");
                Console.WriteLine("- Nome :");
                string nome = Console.ReadLine();
                Console.WriteLine("-Cognome :");
                string cognome = Console.ReadLine(); 
                Console.WriteLine("Data di nascita (DD/MM/YYYY)");
                string dataNascita = Console.ReadLine();
                Console.WriteLine("Comune di residenza");
                string comuneResidenza = Console.ReadLine();


            string codiceFiscale = "";

            while (!boolCF)
            {
                Console.WriteLine("Codice fiscale");
                codiceFiscale = Console.ReadLine();
                if (codiceFiscale.Length == 16)
                {
                    boolCF = true;
                }
                else
                {
                    Console.WriteLine("Scrivi un codice fiscale valido");
                }
            }




            Console.WriteLine("Sesso M o F");
                string sesso = Console.ReadLine();

            int reddito = 0;

            while (!boolReddito)
            {
                
                Console.WriteLine("Reddito");
                string temp = Console.ReadLine();

                if (int.TryParse(temp, out reddito))
                {
                    boolReddito = true;
                }
                else
                {
                    Console.WriteLine("inserisci un reddito valido");
                }
            }

            Utente.SettaDati(nome, cognome, sesso, comuneResidenza, dataNascita, codiceFiscale, reddito);

            Console.Clear();
            Utente.CheckImposta();
            Utente.StampaDati();
        }
    }


    public class Utente
    {
        static string Nome;
        static string Cognome;
        static string DataNascita;
        static string Sesso;
        static string CodiceFiscale;
        static string ComuneResidenza;
        static int Reddito = 0;

        static string Imposta;
        


        public static void SettaDati(string nome, string cognome, string sesso, string comuneResidenza, string dataNascita, string codiceFiscale , int reddito)
        {
            Nome = nome;
            Cognome = cognome;
            Sesso = sesso;
            ComuneResidenza= comuneResidenza;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Reddito = reddito;
        }


        public static void StampaDati()
        {
            Console.WriteLine($"Nome : {Nome}");
            Console.WriteLine($"Cognome : {Cognome}"); 
            Console.WriteLine($"Data di nascita : {DataNascita}");
            Console.WriteLine($"Sesso: {Sesso}");
            Console.WriteLine($"Comune di residenza : {ComuneResidenza}");
            Console.WriteLine($"Reddito :{Reddito}");
            Console.WriteLine($"CondiceFiscale : {CodiceFiscale}");

            Console.WriteLine($"Quanto devi pagare : {Imposta}");
        }


        public static void CheckImposta()
        {
            if (Reddito >= 0 && Reddito <= 15000)
            {
                Imposta = ((Reddito * 23) / 100).ToString();
            }
            else if (Reddito >= 15001 && Reddito <= 28.000)
            {
                int eccesso = Reddito - 15000;
                Imposta = (3450 + (eccesso * 27) / 100).ToString();
            }
            else if (Reddito >= 28001 && Reddito <= 55000)
            {
                int eccesso = Reddito - 28000;
                Imposta = (6960 + (eccesso * 38) / 100).ToString();
            }
            else if (Reddito >= 55001 && Reddito <= 75000)
            {
                int eccesso = Reddito - 55000;
                Imposta = (17220 + (eccesso * 41) / 100).ToString();
            }
            else if (Reddito >= 75001)
            {
                int eccesso = Reddito - 75000;
                Imposta = (25420 + (eccesso * 43) / 100).ToString();
            }
        }
    }
}
