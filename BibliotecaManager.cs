using System;
using System.Collections.Generic;
using System.Linq;

namespace GestiuneBiblioteca
{
    public class BibliotecaManager
    {
        public List<Carte> Carti = new List<Carte>();
        public List<Persoana> Persoane = new List<Persoana>();

        // Operații de bază (Exemplu pentru Carte)
        public void AdaugaCarte(Carte c) => Carti.Add(c);

        public void StergeCarte(int id) => Carti.RemoveAll(c => c.Id == id);

        public void EditeazaCarte(int id, string nouTitlu)
        {
            var carte = Carti.FirstOrDefault(c => c.Id == id);
            if (carte != null) carte.Titlu = nouTitlu;
        }

        // Cerința 1: Verificare disponibilitate
        public void AfiseazaDisponibilitate(int idCarte)
        {
            var carte = Carti.FirstOrDefault(c => c.Id == idCarte);
            if (carte == null) { Console.WriteLine("Cartea nu există."); return; }

            Console.WriteLine(carte.EsteDisponibila
                ? $"Cartea '{carte.Titlu}' este DISPONIBILĂ."
                : $"Cartea '{carte.Titlu}' NU este disponibilă (toate exemplarele sunt împrumutate).");
        }

        // Cerința 2: Împrumut cu verificare limită
        public void ProceseazaImprumut(int idPersoana, int idCarte)
        {
            var persoana = Persoane.FirstOrDefault(p => p.Id == idPersoana);
            var carte = Carti.FirstOrDefault(c => c.Id == idCarte);

            if (persoana == null || carte == null) return;

            // Verificare număr cărți vs Configurare
            if (persoana.CartiImprumutate.Count >= Configurari.LimitaMaximeImprumuturi)
            {
                Console.WriteLine($"\n[ATENȚIE] Persoana {persoana.Nume} a depășit limita de {Configurari.LimitaMaximeImprumuturi} cărți!");
                Console.WriteLine("Împrumutul a fost REFUZAT.");
                return;
            }

            if (carte.EsteDisponibila)
            {
                carte.ExemplareImprumutate++;
                persoana.CartiImprumutate.Add(carte);
                Console.WriteLine($"Împrumut reușit: {persoana.Nume} a luat '{carte.Titlu}'.");
            }
            else
            {
                Console.WriteLine("Eroare: Nu mai sunt exemplare disponibile.");
            }
        }
    }
}