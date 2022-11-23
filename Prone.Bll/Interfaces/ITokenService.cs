using Prone.Dal.Models;

namespace Prone.Bll.Interfaces;

public interface ITokenService
{
    string createToken(AppUser user);
}