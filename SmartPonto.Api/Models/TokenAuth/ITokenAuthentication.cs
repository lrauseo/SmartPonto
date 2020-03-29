using System;
namespace SmartPonto.Api.Models.TokenAuth
{
    public interface ITokenAuthentication
    {
        string GenerateToken(string userName);
    }
}
