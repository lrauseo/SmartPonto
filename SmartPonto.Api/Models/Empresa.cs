using System.Collections.Generic;

namespace SmartPonto.Api.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public int Cpnj { get; set; }    
        public bool Inativo { get; set; }
        public ICollection<Usuario> Funcionarios { get; set; }
        public Login LoginAdm { get; set; }
    }
}