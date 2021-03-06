using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.api.Data;
using DatingApp.api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.api.Controllers {
     [Authorize]
    [Route ("api/[controller]")]
    public class UsersController : Controller {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public UsersController (IDatingRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers () {
            var users = await _repo.GetUsers ();
            var userToReturn =  _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok (userToReturn);
        }
        
        [HttpGet ("{Id}")]
        public async Task<IActionResult> GetUser (int id) {
            var user = await _repo.GetUser (id);
            var userToReturn =  _mapper.Map<UserForDetailsDto>(user);
            return Ok (userToReturn);
        }

    }
}