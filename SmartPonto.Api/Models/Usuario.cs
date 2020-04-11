namespace SmartPonto.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public bool Inativo { get; set; }
        public bool IsAdmin { get; set; } = false;        
        public int LoginId { get; set; }
        public Login Login { get; set; }
        public Empresa Empresa { get; set; }    
    }
}