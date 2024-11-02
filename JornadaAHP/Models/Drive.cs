namespace JornadaAHP.Models
{
    public class Drive
    {
        public int Id { get; set; }
        public string? PartNumber { get; set; } = string.Empty;
        public decimal Preco { get; set; } = 0;
        public List<Motor> Motores { get; set; } = new List<Motor>();
    }
}
