namespace SmartPonto.Api.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string TokenLogin { get; set; }
        public string NomeRedeSocial { get; set; }
        public bool IsLoginRedeSocial { get; set; }
        public Usuario Usuario { get; set; }        
    }
}