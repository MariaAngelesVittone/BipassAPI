using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUser()
        {
            // Ahora la llamada funciona porque el método existe y devuelve una lista
            var users = _userRepository.GetUser();

            // .Select() ahora funciona correctamente
            return users
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.FirstName // Usamos FirstName del modelo User
                })
                .ToList();
        }
    }
}