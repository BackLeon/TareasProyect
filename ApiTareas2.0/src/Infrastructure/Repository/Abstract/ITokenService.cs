using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Infrastructure.Repository.Abstract
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}