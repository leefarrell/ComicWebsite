using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ComicWebsite.API.Data;
using ComicWebsite.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComicWebsite.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var returnUsers = _mapper.Map<IEnumerable<UserDto>>(users);
            
            return Ok(returnUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var returnUser = _mapper.Map<UserDetailsDto>(user);
            
            return Ok(returnUser);
        }
        
    }
}