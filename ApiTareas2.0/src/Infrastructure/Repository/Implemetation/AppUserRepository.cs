using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos.AppUserDtos;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.Implemetation
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly TareaDbContext _context;
        private readonly ITokenService _token;

        public AppUserRepository(TareaDbContext context, ITokenService token)
        {
            _context = context;
            _token = token;
        }
        public async Task<AppUser> GetUserById(int id)
        {
            var foundUser = await _context.AppUsers.FirstOrDefaultAsync( u => u.Id == id);

            if(foundUser is null) return null!;
        
            return foundUser;

        }

        public async Task<AppUser> Register(AppUserToRegisterDto appUserToRegisterDto)
        {
            var passEncript = Encrypt(appUserToRegisterDto.Password!);

            AppUser appUserNew = new AppUser 
            {
                Name = appUserToRegisterDto.Name,
                LastName = appUserToRegisterDto.LastName,
                Email = appUserToRegisterDto.Email,
                License = appUserToRegisterDto.License,
                Phone = appUserToRegisterDto.Phone,
                Password = passEncript,
                Roles = "USUARIO",
                JobAreaId = 3

            };

            var result = await _context.AddAsync(appUserNew);

            if(result is null) return null!;

            await _context.SaveChangesAsync();
            appUserNew.Password = passEncript;

            return appUserNew;

        }

        public async Task<AppUserLoginResponseDto> Login(AppUserToLoginDto appUserToLoginDto)
        {
            var passEncript = Encrypt(appUserToLoginDto.Password!);
            
            var user = await _context.AppUsers.FirstOrDefaultAsync( u => u.Email == appUserToLoginDto.Email && u.Password == passEncript && u.License == appUserToLoginDto.License);

            if(user is null) return null!;
            var newsesion = new AppUserLoginResponseDto
            {
                Email = user.Email,
                Roles = user.Roles,
                Token = _token.CreateToken(user)
            };

            return newsesion;
        }

        /*
        public static string GetSHA256(string str)
        {
            
                    SHA256 sha256 = SHA256Managed.Create();
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] stream = null!;
                    StringBuilder sb = new StringBuilder();
                    stream = sha256.ComputeHash(encoding.GetBytes(str));
                    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                    return sb.ToString();
        }*/

        public string Encrypt(string valor)
        {
            string hash = "Welcome to the Ñungle o Jungle";
            byte[] data = UTF8Encoding.UTF8.GetBytes(valor);
            
            MD5 md5 = MD5.Create();
            TripleDES tripledes  = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
        byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }


    }
}