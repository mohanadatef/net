using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Interfaces.Auth
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
