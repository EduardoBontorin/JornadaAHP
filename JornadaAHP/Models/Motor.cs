namespace JornadaAHP.Models
{
    public class Motor
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Prazo { get; set; } // em dias
        public int Velocidade { get; set; } // em RPM
        public int Peso { get; set; } // em Kg
    }
}
