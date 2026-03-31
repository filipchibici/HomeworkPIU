using System;
using System.Text; // Aceasta linie este necesara pentru Encoding

namespace GestiuneBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINIA MAGICA: Seteaza consola sa recunoasca diacriticele (UTF-8)
            Console.OutputEncoding = Encoding.UTF8;

            BibliotecaManager biblioteca = new BibliotecaManager();

            // Date de test
            Autor autor1 = new Autor { Id = 1, Nume = "Liviu Rebreanu" };
            // Am crescut numarul de exemplare la 5 pentru a vedea cum functioneaza limita de 3 carti/persoana
            Carte carte1 = new Carte { Id = 101, Titlu = "Ion", Autor = autor1, ExemplareTotale = 5, ExemplareImprumutate = 0 };
            Persoana p1 = new Persoana { Id = 1, Nume = "Andrei Vasile" };

            biblioteca.AdaugaCarte(carte1);
            biblioteca.Persoane.Add(p1);

            Console.WriteLine("--- Test Disponibilitate ---");
            biblioteca.AfiseazaDisponibilitate(101);

            Console.WriteLine("\n--- Test Limitare Împrumuturi (Limita este 3) ---");

            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"\nÎncercarea nr. {i}:");
                biblioteca.ProceseazaImprumut(1, 101);
            }

            Console.WriteLine("\nApăsați orice tastă pentru a închide...");
            Console.ReadKey();
        }
    }
}