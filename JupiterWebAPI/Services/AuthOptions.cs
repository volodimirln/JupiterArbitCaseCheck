using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JupiterWebAPI.Services
{
    public class AuthOptions
    {
        public const string ISSUER = "JupiterWebAPI";
        public const string AUDIENCE = "JupiterWebAPIClient";
        const string KEY = "abcofbadtastesingkomsomolsk";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
