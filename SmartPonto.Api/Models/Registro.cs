using System;
namespace SmartPonto.Api.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }        
        public string Justificativa { get; set; }
        public bool AjusteManual { get; set; }

        public long Logintude { get; set; }
        public long Latitude { get; set; }
        public PontoRegistro PontoRegistro { get; set; }        
    }
}