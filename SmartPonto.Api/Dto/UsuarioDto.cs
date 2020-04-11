namespace SmartPonto.Api.Dto
{

    public class UsuarioDto
    {        
        public string Nome { get; set; }
        public int Cpf { get; set; }        
        public bool IsAdmin { get; set; } = false;
        public int LoginId { get; set; }
        public LoginDto Login { get; set; }
        public EmpresaDto Empresa { get; set; }
    }
}