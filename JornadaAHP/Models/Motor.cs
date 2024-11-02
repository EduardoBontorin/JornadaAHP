using JornadaAHP.Enums;

namespace JornadaAHP.Models
{
    public class Motor
    {
        public int Id { get; set; }
        public string? Empresa { get; set; }
        public string PartNumber { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public int Prazo { get; set; } // em dias
        public int RpmMaximo { get; set; } // em RPM
        public int RpmMedio { get; set; } // em RPM
        public decimal Peso { get; set; } // em Kg
        public decimal ForcaMaxima { get; set; }
        public decimal ForcaMedia { get; set; } //Torque na metade da capacidade do motor.
        public Fonte? Fonte { get; set; }
        public int FonteId { get; set; }
        public Drive? Drive { get; set; }
        public int DriveId { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}
