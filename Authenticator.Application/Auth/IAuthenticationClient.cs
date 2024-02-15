using Authenticator.Application.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.Auth
{
    public interface IAuthenticationClient
    {
        AuthenticationToken Authenticate(ClientSignIn clientSignIn);
    }
}
