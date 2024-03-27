using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;



namespace JwtAuthenticationWithMiddlewares.Helpers.Utils
{
    public class JwtUtils
    {
        static string secret = "3hO4Lash4CzZfkBGa6yQhd48208RGTAu";

        public static string GenerateJwtToken(UserModel user)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);



            List<Claim> claims = new List<Claim>
            {
                new Claim("user_id", user.id.ToString()),
                new Claim("username", user.user_name),
            };

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(jwtToken);
        }

        public static bool ValidateJwtToken(string jwt)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(secret);

                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                };

                tokenHandler.ValidateToken(jwt, validationParameters, out SecurityToken validatedToken);
                JwtSecurityToken validatedJWT = (JwtSecurityToken)validatedToken;

                long user_id = long.Parse(validatedJWT.Claims.First(claim => claim.Type == "user_id").Value);

                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    UserModel? user = context.User.FirstOrDefault(u=> u.id == user_id);

                    if (user == null)
                    {
                        return false;
                    }

                    else
                    {
                        LoginDetailModel loginDetail = context.LoginDetails.Where(Id => Id.user_id == user_id).First();

                        if (loginDetail.token != jwt)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
