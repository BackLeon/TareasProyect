using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos.AppUserDtos;
using Core.Models;

namespace Infrastructure.Repository.Abstract
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetUserById(int id);

        Task<AppUserLoginResponseDto> Login(AppUserToLoginDto appUserToLoginDto);

        Task<AppUser> Register(AppUserToRegisterDto appUserToRegisterDto);
    }
}