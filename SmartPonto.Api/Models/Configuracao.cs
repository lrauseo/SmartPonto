using System;
using System.Collections.Generic;

namespace SmartPonto.Api.Models
{
    public class Configuracao
    {
        public int Id { get; set; }
        public TimeSpan PeriodoTrabalho { get; set; }
        public TimeSpan PeriodoIntervalo { get; set; }
        public IList<DayOfWeek> DiasUteis { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public TimeSpan Horaentrada { get; set; }
    }
}