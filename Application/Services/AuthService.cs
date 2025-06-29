using Domain.Entities;
using Domain.Interfaces;
using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AuthService(IUserRepository userRepo, IPasswordHasher<User> hasher)
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IPasswordHasher<User> _hasher = hasher;

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var user = (await _userRepo.GetAllAsync())
                .FirstOrDefault(u => u.Email == dto.Email) ?? throw new Exception("User tidak ditemukan");

            var verify = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (verify == PasswordVerificationResult.Failed)
                throw new Exception("Password salah.");

            return new LoginResponseDto
            {
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()), // dummy token
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }
    }
}