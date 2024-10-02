namespace JornadaAHP.Models
{
    public class Motor
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public double PrecoEscala { get; set; }
        public int Prazo { get; set; } // em dias
        public double PrazoEscala { get; set; }
        public int Velocidade { get; set; } // em RPM
        public double VelocidadeEscala { get; set; }
        public int Peso { get; set; } // em Kg
        public double PesoEscala { get; set; }

        public double Pontuacao { get; set; }
    }
}
