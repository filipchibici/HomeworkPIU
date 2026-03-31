namespace GestiuneBiblioteca
{
    public class Carte
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public Autor Autor { get; set; }
        public int ExemplareTotale { get; set; }
        public int ExemplareImprumutate { get; set; }

        // Proprietate calculată pentru disponibilitate
        public bool EsteDisponibila => ExemplareTotale > ExemplareImprumutate;

        public override string ToString() =>
            $"[{Id}] {Titlu} de {Autor.Nume} | Disponibil: {(EsteDisponibila ? "DA" : "NU")} ({ExemplareTotale - ExemplareImprumutate} buc)";
    }
}