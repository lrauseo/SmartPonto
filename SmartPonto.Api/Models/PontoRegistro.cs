using System.Collections.Generic;

namespace SmartPonto.Api.Models
{
    public class PontoRegistro
    {
        public int Id { get; set; }
        public IList<Registro> Registros { get; set; }
        public Configuracao Configuracao { get; set; }
    }
}