using System;

namespace DevFreela.Core
{
  public interface IAuthService
  {
    string GenerateJwtToken(string email, string role);
  }

}
