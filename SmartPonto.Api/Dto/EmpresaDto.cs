using System.Collections.Generic;

namespace SmartPonto.Api.Dto
{
    public class EmpresaDto
    {      
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public int Cpnj { get; set; }            
        public IList<UsuarioDto> Funcionarios { get; set; }             
    }
}