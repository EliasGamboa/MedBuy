using AutoMapper;
using MedBuy.Api.Responses;
using MedBuy.Domain.DTOs;
using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedBuy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService repository, IMapper mapper)
        {
            _service = repository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _service.GetUsuarios();
            var userDto = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(users);

            var response = new ApiResponse<IEnumerable<UsuarioResponseDto>>(userDto);

            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _service.GetUsuario(id);
            var userDto = _mapper.Map<Usuario, UsuarioResponseDto>(user);

            var response = new ApiResponse<UsuarioResponseDto>(userDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UsuarioRequestDto usuarioDto)
        {
            var user = _mapper.Map<UsuarioRequestDto, Usuario>(usuarioDto);
            await _service.AddUsuario(user);
            var userresponseDto = _mapper.Map<Usuario, UsuarioResponseDto>(user);
            var response = new ApiResponse<UsuarioResponseDto>(userresponseDto);

            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteUsuario(id);

            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put( int id, [FromForm] UsuarioRequestDto usuarioDto)
        {
            var user = _mapper.Map<Usuario>(usuarioDto);
            user.Id = id;

            await _service.UpdateUsuario(user);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
    
    
}