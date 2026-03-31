namespace GestiuneBiblioteca
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public override string ToString() => $"{Nume} (ID: {Id})";
    }
}