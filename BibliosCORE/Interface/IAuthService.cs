using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orfelin.Core.DTO;

namespace Orfelin.Core.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
