using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Data;
using DatingApp.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var dto = _mapper.Map<System.Collections.Generic.IEnumerable<UserForListDto>>(users);
            
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _repo.GetUser(id);

            if (user is null) return NotFound();

            var dto = _mapper.Map<UserForDetailDto>(user);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserForUpdateDto dto) {
            
        if (dto.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToString()) return Unauthorized();


            var user = await _repo.GetUser(dto.Id);

            return Ok();
        }

    }
}