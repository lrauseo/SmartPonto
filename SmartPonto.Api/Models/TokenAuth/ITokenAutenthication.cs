using System;
namespace SmartPonto.Api.Models.TokenAuth
{
    public interface ITokenAutenthication
    {
        string GenerateToken(string userName);
    }
}
