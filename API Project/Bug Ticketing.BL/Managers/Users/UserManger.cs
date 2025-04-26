using Bug_Ticketing.BL.DTOS.Users;
using Bug_Ticketing.DAL;
using Bug_Ticketing.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.Managers.Users
{
    internal class UserManger : IUserManger
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserManger(IUnitOfWork unitOfWork , IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        public async Task<bool> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var ExistUser = await _unitOfWork.UserRepo.GetByEmailAsynic(userRegisterDto.Email);
            if (ExistUser != null)
                return false;
            
                //return new MessageHandle
                //{
                //    Success = false,
                //    Message = "User already exists"
                //};
            
            var NewUser = new User
            {
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password, 
                Role = userRegisterDto.Role
            };

             _unitOfWork.UserRepo.Add(NewUser);
            await _unitOfWork.SaveChangesAsync();
            return true;
            //return new MessageHandle
            //{
            //    Success = true,
            //    Message = "User registered successfully"
            //};
        }
        public async Task<string> LogInAsync(UserLoginDto userLoginDto)
        {

            var UserFromDB = await _unitOfWork.UserRepo.GetByEmailAsynic(userLoginDto.Email);
            if (UserFromDB == null)
                return null;

            if (UserFromDB.Password != userLoginDto.Password)
                return null;

            return GenerateToken(UserFromDB);
        }

        private string GenerateToken(User userFromDB)
        {
            var claims = new List<Claim>
           {
          new Claim(ClaimTypes.NameIdentifier, userFromDB.Id.ToString()),
          new Claim(ClaimTypes.Email, userFromDB.Email),
          new Claim(ClaimTypes.Role, userFromDB.Role)
          };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
