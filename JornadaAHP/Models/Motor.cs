namespace JornadaAHP.Models
{
    public class Motor
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int? PrecoEscala { get; set; }
        public int Prazo { get; set; } // em dias
        public int? PrazoEscala { get; set; }
        public int Velocidade { get; set; } // em RPM
        public int? VelocidadeEscala { get; set; }
        public int Peso { get; set; } // em Kg
        public int? PesoEscala { get; set; }

        public double Pontuacao { get; set; }
    }
}
