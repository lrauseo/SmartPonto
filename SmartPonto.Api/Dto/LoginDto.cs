namespace SmartPonto.Api.Dto
{
    public class LoginDto
    {         
        public string Email { get; set; }
        public string Senha { get; set; }
        public string TokenLogin { get; set; }             
        public UsuarioDto Usuario { get; set; }    
    }
}