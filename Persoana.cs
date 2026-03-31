using System.Collections.Generic;

namespace GestiuneBiblioteca
{
    public class Persoana
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<Carte> CartiImprumutate { get; set; } = new List<Carte>();

        public override string ToString() => $"{Nume} (ID: {Id}) - Cărți active: {CartiImprumutate.Count}";
    }
}