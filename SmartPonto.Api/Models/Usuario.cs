namespace SmartPonto.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public bool Inativo { get; set; }
        public bool IsAdmin { get; set; } = false;
        public Empresa Empresa { get; set; }
        public Login Login { get; set; }
    }
}